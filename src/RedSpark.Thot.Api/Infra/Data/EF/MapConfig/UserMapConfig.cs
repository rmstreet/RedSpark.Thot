
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedSpark.Thot.Api.Domain.Entities.Persons;
using RedSpark.Thot.Api.Infra.CrossCutting.Extensions;
using RedSpark.Thot.Api.Infra.Data.EF.MapConfig.Extensions;

namespace RedSpark.Thot.Api.Infra.Data.EF.MapConfig
{
    public class UserMapConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Person");

            builder
                .HasKey(p => p.Id);

            builder
               .Property(p => p.Username)
               .HasColumnType("varchar(50)");

            builder
                .Property(p => p.Password)
                .HasColumnType("varchar(50)")
                .HasConversion<string>(
                    p => p.ToUnsecuredString(),
                    s => s.ToSecuredString()
                );

            builder
                .ConfigMapDefaultFields();
        }
    }

}
