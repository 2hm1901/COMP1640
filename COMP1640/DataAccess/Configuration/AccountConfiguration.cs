using DataAccess.Configuration.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Accounts;
using Models.Core;
using Utility;

namespace DataAccess.Configuration;
public sealed class AccountConfiguration : BaseModelConfiguration<Account>
{
    public override void Configure(EntityTypeBuilder<Account> builder)
    //public override void Configure(EntityTypeBuilder<Account> builder)
    {
        base.Configure(builder);

        // Tên bảng trong database
        builder.ToTable("Accounts");

        // Các cột trong bảng
        builder.Property(p => p.LastName).HasMaxLength(50);
        builder.Property(p => p.FirstName).HasMaxLength(50);

        builder.Property(p => p.Email).HasMaxLength(255);
        builder.Property(p => p.Password).HasMaxLength(200);

        //Token
        builder.Property(p => p.RefreshToken).HasMaxLength(256);
        builder.Property(p => p.RefreshTokenExpiryTime).IsRequired();

        // Mối quan hệ

        // Một học sinh có thể có 1 giáo viên
        builder.HasOne(p => p.Teacher)
            .WithMany(p => p.Students)
            .HasForeignKey(p => p.TeacherId)
            .OnDelete(DeleteBehavior.NoAction);

        // Hoặc một giáo viên có thể có nhiều học sinh
        builder.HasMany(p => p.Students)
            .WithOne(p => p.Teacher)
            .HasForeignKey(p => p.TeacherId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasData(
            new Account
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Password = PasswordUtil.HashPassword("123456"),
                Role = Role.STUDENT,
                AccountStatus = AccountStatus.ACTIVE,
                TeacherId = 2 // Assuming teacher with Id 2 exists
            },
            new Account
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Smith",
                Email = "jane.smith@example.com",
                Password = PasswordUtil.HashPassword("123456"),
                Role = Role.TEACHER,
                AccountStatus = AccountStatus.ACTIVE
            },
            new Account
            {
                Id = 3,
                FirstName = "Alice",
                LastName = "Johnson",
                Email = "alice.johnson@example.com",
                Password = PasswordUtil.HashPassword("123456"),
                Role = Role.STAFF,
                AccountStatus = AccountStatus.ACTIVE
            }
        );
    }
}