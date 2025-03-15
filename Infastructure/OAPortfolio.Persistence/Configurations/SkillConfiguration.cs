using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OAPortfolio.Domain.Entities;

namespace OAPortfolio.Persistence.Configurations;

public class SkillConfiguration : BaseConfiguration<Skill>
{
    public override void Configure(EntityTypeBuilder<Skill> builder)
    {
        base.Configure(builder);
    }
}
