using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OAPortfolio.Domain.Entities;

namespace OAPortfolio.Persistence.Configurations;

public class AboutConfiguration : BaseConfiguration<About>
{
    public override void Configure(EntityTypeBuilder<About> builder)
    {
        base.Configure(builder);
    }
}
