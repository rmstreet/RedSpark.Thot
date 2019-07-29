using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RedSpark.Thot.Api.Infra.Data.EF.MapConfig
{
    public class IdentityRoleClaimMapConfig : IEntityTypeConfiguration<IdentityRoleClaim<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityRoleClaim<int>> builder)
        {
            // Reference: https://docs.microsoft.com/pt-br/aspnet/core/security/authentication/customize-identity-model?view=aspnetcore-2.2#default-model-configuration

            // Primary key
            builder.HasKey(rc => rc.Id);

            builder.Property(rc => rc.ClaimType).HasColumnType("varchar(max)");
            builder.Property(rc => rc.ClaimValue).HasColumnType("varchar(max)");

            // Maps to the RoleClaim table
            builder.ToTable("RoleClaim");
        }
    }
}
