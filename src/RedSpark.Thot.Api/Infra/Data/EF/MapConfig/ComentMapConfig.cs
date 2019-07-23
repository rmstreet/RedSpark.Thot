
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedSpark.Thot.Api.Domain.Entities.Leads;

namespace RedSpark.Thot.Api.Infra.Data.EF.MapConfig
{
    public class ComentMapConfig : IEntityTypeConfiguration<Coment>
    {
        public void Configure(EntityTypeBuilder<Coment> builder)
        {
            builder.ToTable("Coment");

            builder.HasKey(c => c.Id);

            builder
                .Property(c => c.Description)
                .HasMaxLength(500);

        }
    }

}
