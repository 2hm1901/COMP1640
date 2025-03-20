namespace COMP1640.Models;

public class Interaction
{
    public int Id { get; set; }
    public string TutorId { get; set; }
    public string StudentId { get; set; }
    public string Type { get; set; } // e.g., "Document Upload", "Message Sent"
    public DateTime Timestamp { get; set; }

    public virtual ApplicationUser Tutor { get; set; }
    public virtual ApplicationUser Student { get; set; }
}
