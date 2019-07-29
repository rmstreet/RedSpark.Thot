using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RedSpark.Thot.Api.Infra.Data.EF.MapConfig
{
    public class IdentityUserTokenMapConfig : IEntityTypeConfiguration<IdentityUserToken<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserToken<int>> builder)
        {
            // Reference: https://docs.microsoft.com/pt-br/aspnet/core/security/authentication/customize-identity-model?view=aspnetcore-2.2#default-model-configuration

            // Composite primary key consisting of the UserId, LoginProvider and Name
            builder.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });

            // Limit the size of the composite key columns due to common DB restrictions
            builder.Property(t => t.LoginProvider).HasColumnType("varchar(450)");
            builder.Property(t => t.Name).HasColumnType("varchar(450)");
            builder.Property(t => t.Value).HasColumnType("varchar(max)");

            // Maps to UserToken table
            builder.ToTable("UserToken");
        }
    }
}
