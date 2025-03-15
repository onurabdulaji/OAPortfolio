using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OAPortfolio.Domain.Entities;

namespace OAPortfolio.Persistence.Configurations;

public class ProjectConfiguration : BaseConfiguration<Project>
{
    public override void Configure(EntityTypeBuilder<Project> builder)
    {
        base.Configure(builder);
    }
}
