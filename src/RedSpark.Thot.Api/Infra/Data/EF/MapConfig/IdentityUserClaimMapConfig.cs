using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RedSpark.Thot.Api.Infra.Data.EF.MapConfig
{
    public class IdentityUserClaimMapConfig : IEntityTypeConfiguration<IdentityUserClaim<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserClaim<int>> builder)
        {            
            // Reference: https://docs.microsoft.com/pt-br/aspnet/core/security/authentication/customize-identity-model?view=aspnetcore-2.2#default-model-configuration

            // Primary key
            builder.HasKey(uc => uc.Id);

            builder.Property(uc => uc.ClaimType).HasColumnType("varchar(max)");
            builder.Property(uc => uc.ClaimValue).HasColumnType("varchar(max)");

            // Maps to the UserClaim table
            builder.ToTable("UserClaim");
        }
    }
}
