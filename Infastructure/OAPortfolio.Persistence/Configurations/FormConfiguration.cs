using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OAPortfolio.Domain.Entities;

namespace OAPortfolio.Persistence.Configurations;

public class FormConfiguration : BaseConfiguration<Form>
{
    public override void Configure(EntityTypeBuilder<Form> builder)
    {
        base.Configure(builder);
    }
}
