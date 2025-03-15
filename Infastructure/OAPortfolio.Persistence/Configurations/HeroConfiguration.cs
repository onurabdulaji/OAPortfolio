using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OAPortfolio.Domain.Entities;

namespace OAPortfolio.Persistence.Configurations;

public class HeroConfiguration : BaseConfiguration<Hero>
{
    public override void Configure(EntityTypeBuilder<Hero> builder)
    {
        base.Configure(builder);
    }
}
