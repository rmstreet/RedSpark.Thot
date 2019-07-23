
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RedSpark.Thot.Api.Domain.Entities.Leads;
using RedSpark.Thot.Api.Infra.Data.EF.MapConfig.Extensions;
using System;

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
               .HasColumnType("varchar")
               .HasMaxLength(15)
               //.HasConversion<string>( e => e.ToString(), s => (LeadStatus)Enum.Parse(typeof(LeadStatus), s))
               //.HasConversion(new EnumToStringConverter<LeadStatus>())
               .HasConversion<string>()
               .IsRequired();

            // 1 -> *
            builder
                .HasOne(l => l.CreatedBy)
                .WithMany(p => p.LeadsCreatedByMe) 
                .HasForeignKey(l => l.CreatedById);

            // * -> 1
            builder
                .HasMany(l => l.Coments)
                .WithOne(c => c.Lead)
                .HasForeignKey(c => c.LeadId);

            builder
                .ConfigMapDefaultFields();

        }
    }

}
