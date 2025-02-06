using Models.Core;

namespace Models.Emails;
public class Email : BaseModel
{
    public string SenderName { get; set; }
    public string SenderEmail { get; set; }
    public string ReceiverEmail { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public EmailStatus Status { get; set; } = EmailStatus.Pending;
    public int Count { get; set; }
}
