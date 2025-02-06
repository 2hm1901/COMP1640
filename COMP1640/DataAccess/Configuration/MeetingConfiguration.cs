using DataAccess.Configuration.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Meetings;

namespace DataAccess.Configuration;
public class MeetingConfiguration : BaseModelConfiguration<Meeting>
{
    public override void Configure(EntityTypeBuilder<Meeting> builder)
    {
        base.Configure(builder);

        builder.ToTable("Meetings");

        builder.Property(p => p.Title).HasMaxLength(200).IsRequired();
        builder.Property(p => p.Description).HasMaxLength(500);
        builder.Property(p => p.StartTime).IsRequired();
        builder.Property(p => p.EndTime).IsRequired();
        builder.Property(p => p.RoomLink).HasMaxLength(255);
        builder.Property(p => p.RecordingLink).HasMaxLength(255);


        builder.HasOne(p => p.Host)
            .WithMany()
            .HasForeignKey(p => p.HostId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(p => p.Guest)
            .WithMany()
            .HasForeignKey(p => p.GuestId)
            .OnDelete(DeleteBehavior.NoAction);


    }
}
