namespace COMP1640.ViewModels;

public class MessageViewModel
{
    public string Id { get; set; }
    public string OtherUserName { get; set; } // The name of the other user
    public string LastMessage { get; set; } // The latest message text
}
