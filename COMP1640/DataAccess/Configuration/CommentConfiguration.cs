using DataAccess.Configuration.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Comments;

namespace DataAccess.Configuration;
public sealed class CommentConfiguration : BaseModelConfiguration<Comment>
{
    public override void Configure(EntityTypeBuilder<Comment> builder)
    {
        base.Configure(builder);

        // Tên bảng
        builder.ToTable("Comments");

        // Nội dung tối đa 255 ký tự
        builder.Property(p => p.Content).HasMaxLength(500);

        // Cột TargetId không được null
        builder.Property(f => f.TargetId).IsRequired();

        // Mối quan hệ
        // Một bình luận thuộc về một người dùng
        builder.HasOne(f => f.Sender)
           .WithMany()
           .HasForeignKey(f => f.SenderId)
           .OnDelete(DeleteBehavior.NoAction);

    }
}
