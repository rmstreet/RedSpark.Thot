
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedSpark.Thot.Api.Domain.Entities.Leads;
using RedSpark.Thot.Api.Infra.Data.EF.MapConfig.Extensions;

namespace RedSpark.Thot.Api.Infra.Data.EF.MapConfig
{
    public class LeadMapConfig : IEntityTypeConfiguration<Lead>
    {

        public void Configure(EntityTypeBuilder<Lead> builder)
        {

            builder.ToTable("Lead");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.Title)
                .HasColumnType("varchar(60)")
                .IsRequired();

            builder.Property(l => l.Status)
               .HasColumnType("varchar(15)")
               //.HasConversion<string>( e => e.ToString(), s => (LeadStatus)Enum.Parse(typeof(LeadStatus), s))
               //.HasConversion(new EnumToStringConverter<LeadStatus>())
               .HasConversion<string>()
               .IsRequired();

            // 1 -> *
            builder
                .HasOne(l => l.CreatedBy)
                .WithMany(p => p.LeadsCreatedByMe) 
                .HasForeignKey(l => l.CreatedById)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            // * -> 1
            //builder
            //    .HasMany(l => l.Coments)
            //    .WithOne(c => c.Lead)
            //    .HasForeignKey(c => c.LeadId);

            builder
                .ConfigMapDefaultFields();

        }
    }

}
