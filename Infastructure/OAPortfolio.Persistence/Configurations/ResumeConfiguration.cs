using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OAPortfolio.Domain.Entities;

namespace OAPortfolio.Persistence.Configurations;

public class ResumeConfiguration : BaseConfiguration<Resume>
{
    public override void Configure(EntityTypeBuilder<Resume> builder)
    {
        base.Configure(builder);
    }
}
