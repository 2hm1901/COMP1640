namespace COMP1640.Models;

public class Meeting
{
    public int Id { get; set; }
    public string Topic { get; set; }
    public DateTime ScheduledTime { get; set; }
    public string OrganizerId { get; set; } // User ID
}
