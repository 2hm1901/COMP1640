using DataAccess.Configuration.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Posts;

namespace DataAccess.Configuration;
public sealed class PostConfiguration : BaseModelConfiguration<Post>
{
    public override void Configure(EntityTypeBuilder<Post> builder)
    {
        base.Configure(builder);
        builder.ToTable("Posts");

        builder.Property(p => p.Content).HasMaxLength(500);

        // Relationship
        builder.HasOne(p => p.Owner)
            .WithMany(o => o.Posts)
            .HasForeignKey(p => p.OwnerId)
            .OnDelete(DeleteBehavior.NoAction);


    }
}
