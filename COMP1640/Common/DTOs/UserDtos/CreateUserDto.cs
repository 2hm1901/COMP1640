namespace Common.DTOs.UserDtos
{
    public class CreateUserDto
    {
            public required string FirstName { get; set; }
            public required string LastName { get; set; }
            public required string Email { get; set; }
            public required string Password { get; set; }
            public string? Avatar { get; set; }
            public string? RefreshToken { get; set; }
            public string? RefreshTokenExpiryTime { get; set; }
    }
}
