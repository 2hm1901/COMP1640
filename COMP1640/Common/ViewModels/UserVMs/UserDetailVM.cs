namespace Common.ViewModels.UserVMs
{
    public class UserDetailVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        //add the below line if u want to get the avatar
        //public string Avatar { get; set; }
    }
}
