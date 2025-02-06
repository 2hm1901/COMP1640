using Models.Accounts;
using Models.Core;

namespace Models.Posts;
public class Post : BaseModel
{
    public string Content { get; set; }

    // Relationships
    public int OwnerId { get; set; }
    public Account Owner { get; set; }
}
