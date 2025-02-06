using Models.Accounts;
using Models.Core;

namespace Models.Interactions;
/// <summary>
/// Hành động của người dùng - thí dụ: nhắn tin, đăng tài liệu, ....
/// </summary>
public class Interaction : BaseModel
{
    // Nội dung của hành động 
    // ví dụ:
    // Bùi Minh vừa gửi một tin nhắn đến Thanh Trà,
    // Bùi Minh vừa đăng một tài liệu cho Như Vĩnh,
    // Thanh Trà vừa trả lời một bình luận của Bùi Minh
    public string Description { get; set; }

    // Relationships
    // Người thực hiện hành động - Bùi Minh vừa ....
    public int OwnerId { get; set; }
    public Account Owner { get; set; }

    // Hành động này liên quan người nào
    public int? OtherAccountId { get; set; }
    public Account OtherAccount { get; set; }
}
