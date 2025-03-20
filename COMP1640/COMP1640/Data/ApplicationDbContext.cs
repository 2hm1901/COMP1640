using COMP1640.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace COMP1640.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Document> Documents { get; set; }
    public DbSet<Meeting> Meetings { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Interaction> Interactions { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<ApplicationUser>()
           .HasOne(u => u.Tutor)
           .WithMany()
           .HasForeignKey(u => u.TutorId)
           .IsRequired(false); // Make TutorId optional

        // Seed Roles
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = "1", Name = "Student", NormalizedName = "STUDENT" },
            new IdentityRole { Id = "2", Name = "Teacher", NormalizedName = "TEACHER" },
            new IdentityRole { Id = "3", Name = "Staff", NormalizedName = "STAFF" }
        );

        // Seed Users
        var hasher = new PasswordHasher<ApplicationUser>();

        // Giáo viên
        var teacher = new ApplicationUser
        {
            Id = "1001",
            UserName = "teacher@gmail.com",
            NormalizedUserName = "TEACHER@GMAIL.COM",
            Email = "teacher@gmail.com",
            NormalizedEmail = "TEACHER@GMAIL.COM",
            FullName = "Nhu Vinh",
            EmailConfirmed = true
        };
        teacher.PasswordHash = hasher.HashPassword(teacher, "123");

        var teacher2 = new ApplicationUser
        {
            Id = "1002",
            UserName = "teacher2@gmail.com",
            NormalizedUserName = "TEACHER2@GMAIL.COM",
            Email = "teacher2@gmail.com",
            NormalizedEmail = "TEACHER2@GMAIL.COM",
            FullName = "Thanh Tra",
            EmailConfirmed = true
        };
        teacher2.PasswordHash = hasher.HashPassword(teacher2, "123");

        // Nhân viên
        var staff = new ApplicationUser
        {
            Id = "1003",
            UserName = "staff@gmail.com",
            NormalizedUserName = "STAFF@GMAIL.COM",
            Email = "staff@gmail.com",
            NormalizedEmail = "STAFF@GMAIL.COM",
            FullName = "Nathan Json",
            EmailConfirmed = true
        };
        staff.PasswordHash = hasher.HashPassword(staff, "123");

        var staff2 = new ApplicationUser
        {
            Id = "1004",
            UserName = "staff2@gmail.com",
            NormalizedUserName = "STAFF2@GMAIL.COM",
            Email = "staff2@gmail.com",
            NormalizedEmail = "STAFF2@GMAIL.COM",
            FullName = "Ly Tieu Long",
            EmailConfirmed = true
        };
        staff2.PasswordHash = hasher.HashPassword(staff2, "123");

        // Danh sách sinh viên mẫu
        var student1 = new ApplicationUser
        {
            Id = "2001",
            UserName = "student1@gmail.com",
            NormalizedUserName = "STUDENT1@GMAIL.COM",
            Email = "student1@gmail.com",
            NormalizedEmail = "STUDENT1@GMAIL.COM",
            FullName = "Bui Quang Minh",
            TutorId = "1001", // Được hướng dẫn bởi teacher 1
            EmailConfirmed = true,
            MessageCount = 350
        };
        student1.PasswordHash = hasher.HashPassword(student1, "123");

        var student2 = new ApplicationUser
        {
            Id = "2002",
            UserName = "student2@gmail.com",
            NormalizedUserName = "STUDENT2@GMAIL.COM",
            Email = "student2@gmail.com",
            NormalizedEmail = "STUDENT2@GMAIL.COM",
            FullName = "Nguyen Hoang Anh",
            TutorId = "1002", // Được hướng dẫn bởi teacher 2
            EmailConfirmed = true,
            MessageCount = 220
        };
        student2.PasswordHash = hasher.HashPassword(student2, "123");

        var student3 = new ApplicationUser
        {
            Id = "2003",
            UserName = "student3@gmail.com",
            NormalizedUserName = "STUDENT3@GMAIL.COM",
            Email = "student3@gmail.com",
            NormalizedEmail = "STUDENT3@GMAIL.COM",
            FullName = "Tran Bao Ngoc",
            TutorId = null, // Chưa có tutor
            EmailConfirmed = true,
            MessageCount = 100
        };
        student3.PasswordHash = hasher.HashPassword(student3, "123");

        var student4 = new ApplicationUser
        {
            Id = "2004",
            UserName = "student4@gmail.com",
            NormalizedUserName = "STUDENT4@GMAIL.COM",
            Email = "student4@gmail.com",
            NormalizedEmail = "STUDENT4@GMAIL.COM",
            FullName = "Pham Tuan Kiet",
            TutorId = "1001", // Được hướng dẫn bởi teacher 1
            EmailConfirmed = true,
            MessageCount = 75
        };
        student4.PasswordHash = hasher.HashPassword(student4, "123");

        var student5 = new ApplicationUser
        {
            Id = "2005",
            UserName = "student5@gmail.com",
            NormalizedUserName = "STUDENT5@GMAIL.COM",
            Email = "student5@gmail.com",
            NormalizedEmail = "STUDENT5@GMAIL.COM",
            FullName = "Le Hong Phong",
            TutorId = null, // Chưa có tutor
            EmailConfirmed = true,
            MessageCount = 50
        };
        student5.PasswordHash = hasher.HashPassword(student5, "123");

        // Thêm người dùng vào database
        builder.Entity<ApplicationUser>().HasData(teacher, teacher2, staff, staff2, student1, student2, student3, student4, student5);

        // Gán quyền cho giáo viên & nhân viên
        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string> { UserId = "1001", RoleId = "2" }, // Teacher -> Teacher Role
            new IdentityUserRole<string> { UserId = "1002", RoleId = "2" }, // Teacher -> Teacher Role
            new IdentityUserRole<string> { UserId = "1003", RoleId = "3" }, // Staff -> Staff Role
            new IdentityUserRole<string> { UserId = "1004", RoleId = "3" }, // Staff -> Staff Role
            new IdentityUserRole<string> { UserId = "2001", RoleId = "1" }, // Student -> Student Role
            new IdentityUserRole<string> { UserId = "2002", RoleId = "1" },
            new IdentityUserRole<string> { UserId = "2003", RoleId = "1" },
            new IdentityUserRole<string> { UserId = "2004", RoleId = "1" },
            new IdentityUserRole<string> { UserId = "2005", RoleId = "1" }
        );

        builder.Entity<Interaction>().HasData(
               new Interaction { Id = 1, TutorId = "1002", StudentId = "1e64a03d-37b5-4c8c-9985-64383c47a696", Type = "Uploaded a document", Timestamp = DateTime.UtcNow.AddMinutes(-7) },
                new Interaction { Id = 2, TutorId = "1002", StudentId = "1e64a03d-37b5-4c8c-9985-64383c47a696", Type = "Sent you a message", Timestamp = DateTime.UtcNow.AddMinutes(-15) },
                new Interaction { Id = 3, TutorId = "1001", StudentId = "1e64a03d-37b5-4c8c-9985-64383c47a696", Type = "Commented on your document", Timestamp = DateTime.UtcNow.AddMinutes(-30) }
        );
    }
}
