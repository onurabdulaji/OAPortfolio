using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OAPortfolio.Domain.Entities;

namespace OAPortfolio.Persistence.Configurations;

public class SocialMediaConfiguration : BaseConfiguration<SocialMedia>
{
    public override void Configure(EntityTypeBuilder<SocialMedia> builder)
    {
        base.Configure(builder);
    }
}
