using Microsoft.AspNetCore.Identity;

namespace COMP1640.Models;

public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; }
    public string? TutorId { get; set; }  // Foreign key to ApplicationUser (Tutor)
    public ApplicationUser Tutor { get; set; }
    public int MessageCount { get; set; }
}
