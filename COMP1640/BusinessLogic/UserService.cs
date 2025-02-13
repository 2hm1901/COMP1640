using AutoMapper;
using Common.DTOs.UserDtos;
using Common.ViewModels.UserVMs;
using DataAccess.Repository.Core;
using Models.Accounts;
using Models.Core;

namespace BusinessLogic
{
    public class UserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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

        public async Task CreateUser(CreateUserDto dto)
        {
            var user = _mapper.Map<Account>(dto);
            await _unitOfWork.Accounts.AddAsync(user);
            await _unitOfWork.SaveAsync();
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
    }
}
