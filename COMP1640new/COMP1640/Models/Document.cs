namespace COMP1640.Models;

public class Document
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string UploadedBy { get; set; } // User ID
    public DateTime CreatedAt { get; set; }
}
