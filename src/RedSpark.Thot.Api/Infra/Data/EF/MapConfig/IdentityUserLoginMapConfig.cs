using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RedSpark.Thot.Api.Infra.Data.EF.MapConfig
{
    public class IdentityUserLoginMapConfig : IEntityTypeConfiguration<IdentityUserLogin<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserLogin<int>> builder)
        {
            // Reference: https://docs.microsoft.com/pt-br/aspnet/core/security/authentication/customize-identity-model?view=aspnetcore-2.2#default-model-configuration
            // Composite primary key consisting of the LoginProvider and the key to use
            // with that provider
            builder.HasKey(l => new { l.LoginProvider, l.ProviderKey });

            // Limit the size of the composite key columns due to common DB restrictions
            builder.Property(l => l.LoginProvider).HasColumnType("varchar(128)");
            builder.Property(l => l.ProviderKey).HasColumnType("varchar(128)");
            builder.Property(l => l.ProviderDisplayName).HasColumnType("varchar(max)");

            // Maps to the UserLogin table
            builder.ToTable("UserLogin");
        }
    }
}
