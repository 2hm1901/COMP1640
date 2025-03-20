namespace COMP1640.ViewModels;

public class StudentViewModel
{
    public string Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string TutorName { get; set; }
    public string TutorId { get; set; }
    public int MessageCount { get; set; }
    public List<TeacherViewModel> AvailableTeachers { get; set; }
    public bool IsSelected { get; set; }  // For multi-select
}
