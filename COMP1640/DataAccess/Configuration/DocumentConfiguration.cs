using DataAccess.Configuration.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Documents;

namespace DataAccess.Configuration;
public sealed class DocumentConfiguration : BaseModelConfiguration<Document>
{
    public override void Configure(EntityTypeBuilder<Document> builder)
    {
        base.Configure(builder);

        // Tên bảng
        builder.ToTable("Documents");

        // Tiêu đề tối đa 255 ký tự
        builder.Property(p => p.Title).HasMaxLength(255);

        // Mô tả tối đa 500 ký tự
        builder.Property(p => p.Description).HasMaxLength(500);

        // Mối quan hệ
        builder.HasOne(p => p.Owner)
            .WithMany(p => p.Documents)
            .HasForeignKey(p => p.OwnerId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
