using Models.Core;
using Models.Documents;
using Models.Interactions;
using Models.Posts;

namespace Models.Accounts;
public class Account : BaseModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Avatar { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }

    // Vai trò của tài khoản (STAFF, TEACHER, STUDENT)
    public Role Role { get; set; }

    // Trạng thái của tài khoản (ACTIVE, INACTIVE)
    public AccountStatus AccountStatus { get; set; } = AccountStatus.ACTIVE;

    // Relationships
    // Nếu là student sẽ có 1 teacher
    public int? TeacherId { get; set; }
    public Account Teacher { get; set; }

    // Nếu là teacher sẽ có nhiều student
    public ICollection<Account> Students { get; set; }

    // Một người có thể có nhiều hành động
    public ICollection<Interaction> Interactions { get; set; }

    // Một người có thể có nhiều tài liệu
    public ICollection<Document> Documents { get; set; }

    // Một người có thể có nhiều bài viết
    public ICollection<Post> Posts { get; set; }
}
