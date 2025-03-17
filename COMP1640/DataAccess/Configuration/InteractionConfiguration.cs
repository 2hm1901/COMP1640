using DataAccess.Configuration.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Interactions;

namespace DataAccess.Configuration;
public class InteractionConfiguration : BaseModelConfiguration<Interaction>
{
    public override void Configure(EntityTypeBuilder<Interaction> builder)
    {
        base.Configure(builder);

        builder.ToTable("Interactions");

        builder.Property(p => p.Description).HasMaxLength(500);

        builder.HasOne(p => p.Owner)
            .WithMany(p => p.Interactions)
            .HasForeignKey(p => p.OwnerId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(p => p.OtherAccount)
            .WithMany()
            .HasForeignKey(p => p.OtherAccountId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasData(
    new Interaction
    {
        Id = 1,
        Description = "User A interacted with User B",
        OwnerId = 1,
        OtherAccountId = 2
    },
    new Interaction
    { 
        Id= 2,
        Description = "User C liked User D's post",
        OwnerId = 3,
        OtherAccountId = 4
    }
 );
    }
}
