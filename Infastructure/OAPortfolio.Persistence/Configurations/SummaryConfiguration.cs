using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OAPortfolio.Domain.Entities;

namespace OAPortfolio.Persistence.Configurations;

public class SummaryConfiguration : BaseConfiguration<Summary>
{
    public override void Configure(EntityTypeBuilder<Summary> builder)
    {
        base.Configure(builder);
    }
}
