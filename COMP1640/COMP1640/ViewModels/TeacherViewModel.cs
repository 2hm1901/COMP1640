namespace COMP1640.ViewModels;

public class TeacherViewModel
{
    public string Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public int StudentCount { get; set; }
    public int MessageCount { get; set; }
    public List<StudentViewModel> AvailableStudents { get; set; }
}
