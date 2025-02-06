using Models.Accounts;
using Models.Core;

namespace Models.Comments;
public class Comment : BaseModel
{
    // Nội dung bình luận
    public string Content { get; set; }


    // Relationships
    // Bình luận này là cho bài viết hoặc document nào
    public int TargetId { get; set; } // Id của bài viết hoặc document

    // Người bình luận
    public int SenderId { get; set; }
    public Account Sender { get; set; }
}
