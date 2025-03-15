using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OAPortfolio.Domain.Commons.Abstracts;
using OAPortfolio.Domain.Commons.Concretes;
using System.Security.Principal;

namespace OAPortfolio.Persistence.Configurations;

public class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : class, IEntityBase
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .ValueGeneratedOnAdd();

        builder.Property(x => x.CreatedDate)
               .IsRequired();

        builder.Property(x => x.ModifiedDate)
               .IsRequired();
    }
}
