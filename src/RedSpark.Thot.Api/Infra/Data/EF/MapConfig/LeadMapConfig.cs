
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedSpark.Thot.Api.Domain.Models.Leads;

namespace RedSpark.Thot.Api.Infra.Data.EF.MapConfig
{
    public class LeadMapConfig : IEntityTypeConfiguration<Lead>
    {

        public void Configure(EntityTypeBuilder<Lead> builder)
        {

            builder.ToTable("Lead");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.Title)
                .HasColumnType("varchar")
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(l => l.Status)
               .HasConversion<string>()
               .IsRequired();

            builder
                .HasOne(l => l.CreatedBy)
                .WithMany(p => p.LeadsCreatedByMe) 
                .HasForeignKey(l => l.CreatedById);

        }
    }

}
