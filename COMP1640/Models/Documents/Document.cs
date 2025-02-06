using Models.Accounts;
using Models.Core;

namespace Models.Documents;
public class Document : BaseModel
{
    // Tiêu đề của tài liệu
    public string Title { get; set; }

    // Mô tả về tài liệu
    public string Description { get; set; }

    // Đường dẫn đến tài liệu
    public string Path { get; set; }

    // Relationships
    public int OwnerId { get; set; }
    public Account Owner { get; set; }
}
