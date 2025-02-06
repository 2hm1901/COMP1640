using DataAccess.Configuration.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Emails;

namespace DataAccess.Configuration;
public sealed class EmailConfiguration : BaseModelConfiguration<Email>
{
    public override void Configure(EntityTypeBuilder<Email> builder)
    {
        base.Configure(builder);

        builder.ToTable("Emails");
    }
}
