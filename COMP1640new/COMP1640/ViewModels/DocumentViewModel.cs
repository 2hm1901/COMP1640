namespace COMP1640.ViewModels;

public class DocumentViewModel
{
    public string Author { get; set; }
    public string DocumentName { get; set; }
    public DateTime DateUploaded { get; set; }
    public List<CommentViewModel> Comments { get; set; }
}

public class CommentViewModel
{
    public string Author { get; set; }
    public string Content { get; set; }
}
