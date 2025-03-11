using AutoMapper;
using Common.DTOs.UserDtos;
using Common.ViewModels.Authenticate;
using Common.ViewModels.UserVMs;
using DataAccess.Repository.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Models.Accounts;
using Models.Core;
using Models.Emails;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BusinessLogic
{
    public class UserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ILogger<UserService> _logger;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration, ILogger<UserService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<IEnumerable<UserVM>> GetAllUsers(GetAllUsersDto dto)
        {
            var users = await _unitOfWork.Accounts.GetAllAsync();
            return _mapper.Map<IEnumerable<UserVM>>(users);
        }

        public async Task<UserDetailVM> GetUserById(int id)
        {
            var user = await _unitOfWork.Accounts.GetByIdAsync(id);
            return _mapper.Map<UserDetailVM>(user);
        }

        public async Task<bool> CreateUser(CreateUserDto dto)
        {
            // Check if user already existed
            var existingUser = await _unitOfWork.Accounts.GetAsync(u => u.Email == dto.Email);

            if (existingUser != null)
            {
                return false;
            } 

            var user = _mapper.Map<Account>(dto);
            user.Password = HashPassword(dto.Password);
            user.Role = Role.STUDENT;
            await _unitOfWork.Accounts.AddAsync(user);
            await _unitOfWork.SaveAsync();

            return true;
        }

        public async Task UpdateUser(UpdateUserDto dto)
        {
            var user = await _unitOfWork.Accounts.GetByIdAsync(dto.Id);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            _mapper.Map(dto, user);
            await _unitOfWork.Accounts.UpdateAsync(user); // Changed to UpdateAsync
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteUser(DeleteUserDto dto)
        {
            var user = await _unitOfWork.Accounts.GetByIdAsync(dto.Id);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            await _unitOfWork.Accounts.UpdateAsync(user);
            await _unitOfWork.SaveAsync();
        }

        //For Log In
        public async Task<Account> AuthenticateUser(string email, string password)
        {
            var user = await _unitOfWork.Accounts.GetAsync(u => u.Email == email);
            if (user == null || !VerifyPasswordHash(password, user.Password))
            {
                _logger.LogWarning("Authentication failed for email: {Email}", email);
                return null;
            }

            _logger.LogInformation("User authenticated successfully: {Email}", email);
            return user;
        }

        private string HashPassword(string password)
        {
            var key = _configuration["Jwt:Key"];
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key), "Jwt:Key configuration value is missing.");
            }

            using (var hmac = new HMACSHA512(Encoding.UTF8.GetBytes(key)))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hash);
            }
        }

        private bool VerifyPasswordHash(string password, string storedHash)
        {
            var key = _configuration["Jwt:Key"];
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key), "Jwt:Key configuration value is missing.");
            }

            using (var hmac = new HMACSHA512(Encoding.UTF8.GetBytes(key)))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return storedHash == Convert.ToBase64String(computedHash);
            }
        }

        public async Task SaveRefreshToken(int userId, string refreshToken)
        {
            var user = await _unitOfWork.Accounts.GetByIdAsync(userId);
            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task<AuthenticatedResponse> RefreshToken(AuthenticatedResponse request)
        {
            var principal = GetPrincipalFromExpiredToken(request.Token);
            var email = principal.Identity.Name;

            var user = await _unitOfWork.Accounts.GetAsync(u => u.Email == email);
            if (user == null || user.RefreshToken != request.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                return null;
            }

            var newAccessToken = GenerateAccessToken(user);
            var newRefreshToken = GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            await _unitOfWork.SaveAsync();

            return new AuthenticatedResponse
            {
                Token = newAccessToken,
                RefreshToken = newRefreshToken,
                Email = user.Email,
                Password = user.Password,
                Avatar = user.Avatar
            };
        }

        private string GenerateAccessToken(Account user)
        {
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, user.Email)
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(double.Parse(_configuration["Jwt:AccessTokenExpirationMinutes"])),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _configuration["Jwt:Issuer"],
                ValidAudience = _configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]))
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;

            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return principal;
        }
    }
}
