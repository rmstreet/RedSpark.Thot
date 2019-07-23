
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedSpark.Thot.Api.Domain.Entities.Leads;
using RedSpark.Thot.Api.Infra.Data.EF.MapConfig.Extensions;

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

            builder
                .HasMany(c => c.Answers)
                .WithOne(a => a.FatherComent)
                .HasForeignKey(a => a.FatherComentId);

            builder
                .HasOne(c => c.CreatedBy)
                .WithMany(p => p.ComentsByMe)
                .HasForeignKey(c => c.CreatedById);

            builder
                .ConfigMapDefaultFields();

        }
    }

}
