namespace COMP1640.ViewModels;

public class TutorMessageViewModel
{
    public string TutorId { get; set; }
    public string TutorName { get; set; }
    public string LastMessage { get; set; }
    public List<InteractionViewModel> Interactions { get; set; } = new List<InteractionViewModel>();

}

public class InteractionViewModel
{
    public string Type { get; set; }  // "Document Upload", "Message Sent", etc.
    public string TutorName { get; set; }
    public DateTime Timestamp { get; set; }
}
