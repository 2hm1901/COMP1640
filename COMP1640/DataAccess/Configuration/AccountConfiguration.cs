using DataAccess.Configuration.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Accounts;

namespace DataAccess.Configuration;
public sealed class AccountConfiguration : BaseModelConfiguration<Account>
{
    public override void Configure(EntityTypeBuilder<Account> builder)
    {
        base.Configure(builder);

        // Tên bảng trong database
        builder.ToTable("Accounts");

        // Các cột trong bảng
        builder.Property(p => p.LastName).HasMaxLength(50);
        builder.Property(p => p.FirstName).HasMaxLength(50);

        builder.Property(p => p.Email).HasMaxLength(255);
        builder.Property(p => p.Password).HasMaxLength(200);

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
    }
}