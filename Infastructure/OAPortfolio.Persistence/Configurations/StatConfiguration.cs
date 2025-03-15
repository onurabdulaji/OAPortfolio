using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OAPortfolio.Domain.Entities;

namespace OAPortfolio.Persistence.Configurations;

public class StatConfiguration : BaseConfiguration<Stat>
{
    public override void Configure(EntityTypeBuilder<Stat> builder)
    {
        base.Configure(builder);
    }
}
