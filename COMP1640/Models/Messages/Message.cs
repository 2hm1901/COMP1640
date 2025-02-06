using Models.Accounts;
using Models.Core;

namespace Models.Messages;
public class Message : BaseModel
{
    public int SenderId { get; set; }
    public Account Sender { get; set; }
    public int ReceiverId { get; set; }
    public Account Receiver { get; set; }
    public string Content { get; set; }
}
