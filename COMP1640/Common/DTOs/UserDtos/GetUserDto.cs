namespace Common.DTOs.UserDtos
{
    public class GetUserDto
    {
        public int UserId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }

        //add the below line if u want to get the avatar
        //public string Avatar { get; set; }
    }

}
