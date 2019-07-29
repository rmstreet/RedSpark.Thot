
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedSpark.Thot.Api.Domain.Entities.Persons;

namespace RedSpark.Thot.Api.Infra.Data.EF.MapConfig
{
    public class UserMapConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            #region Map default identity properties
            // Reference: https://docs.microsoft.com/pt-br/aspnet/core/security/authentication/customize-identity-model?view=aspnetcore-2.2#default-model-configuration
            // Primary key
            builder.HasKey(u => u.Id);

            // Indexes for "normalized" username and email, to allow efficient lookups
            builder.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
            builder.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");

            // Maps to the AspNetUsers table
            // builder.ToTable("AspNetUsers"); // Remover, o nome da tabela será User

            // A concurrency token for use with the optimistic concurrency checking
            builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

            builder.Property(u => u.PasswordHash).HasColumnType("varchar(max)");
            builder.Property(u => u.SecurityStamp).HasColumnType("varchar(max)");
            builder.Property(u => u.ConcurrencyStamp).HasColumnType("varchar(max)");
            builder.Property(u => u.PhoneNumber).HasColumnType("varchar(14)");

            // Limit the size of columns to use efficient database types
            builder.Property(u => u.UserName).HasColumnType("varchar(256)");
            builder.Property(u => u.NormalizedUserName).HasColumnType("varchar(256)");
            builder.Property(u => u.Email).HasColumnType("varchar(256)");
            builder.Property(u => u.NormalizedEmail).HasColumnType("varchar(256)");

            // The relationships between User and other entity types
            // Note that these relationships are configured with no navigation properties

            // Each User can have many UserClaims
            builder.HasMany<IdentityUserClaim<int>>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

            // Each User can have many UserLogins
            builder.HasMany<IdentityUserLogin<int>>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

            // Each User can have many UserTokens
            builder.HasMany<IdentityUserToken<int>>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

            // Each User can have many entries in the UserRole join table
            builder.HasMany<IdentityUserRole<int>>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
            #endregion


            #region Map custom properties
            builder
                .Property(p => p.Active)
                .IsRequired();

            builder
                .HasOne(u => u.Person)
                .WithOne(p => p.User)
                .HasForeignKey<Person>(p => p.UserId);

            builder
                .Property(l => l.CreateDate)
                .HasColumnType("datetime")
                .HasField("_createDate"); // Nome da variavel privada.

            builder
                .Property(l => l.UpdateDate)
                .HasColumnType("datetime")
                .HasField("_updateDate");

            #endregion
        }
    }

}
