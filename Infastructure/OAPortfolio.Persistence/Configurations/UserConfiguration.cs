using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OAPortfolio.Domain.Entities;

namespace OAPortfolio.Persistence.Configurations;

public class UserConfiguration : BaseConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);
        builder.Property(u => u.UserFullName)
               .HasMaxLength(255)
               .IsRequired(false);

        builder.Property(u => u.RefreshToken)
               .IsRequired(false);

        builder.Property(u => u.RefreshTokenExpiryTime)
               .IsRequired(false);

        
    }
}
