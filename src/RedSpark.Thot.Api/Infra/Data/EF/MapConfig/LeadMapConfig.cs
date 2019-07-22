
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedSpark.Thot.Api.Domain.Core.ValueObject;
using RedSpark.Thot.Api.Domain.Entities.Leads;
using RedSpark.Thot.Api.Domain.Entities.Persons;
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

            // TODO: Completar
            //builder
            //    .HasMany(l => l.PersonsFollowing);


        }
    }


    public class LeadComentMapConfig : IEntityTypeConfiguration<LeadComent>
    {
        public void Configure(EntityTypeBuilder<LeadComent> builder)
        {
            builder.ToTable("LeadComent");
            
            builder.HasKey(lc => new { lc.LeadId, lc.ComentId });

            builder
                .HasOne(lc => lc.Lead)
                .WithMany(l => l.Coments)
                .HasForeignKey(lc => lc.LeadId);

            builder
                .HasOne(lc => lc.Coment)
                .WithMany(c => c.LeadComents)
                .HasForeignKey(lc => lc.ComentId);

            builder
                .HasOne(lc => lc.CreatedBy)
                .WithMany(p => p.Coments)
                .HasForeignKey(lc => lc.CreatedById);

            builder
                .HasOne(lc => lc.LeadComentFather)
                .WithMany(lcf => lcf.Answers)
                .HasForeignKey(lc => new { lc.AnswerLeadId, lc.AnswerComentId });


            builder
                .Ignore(lc => lc.Id);
        }
    }


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

    public class PersonMapConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");

            builder.HasKey(p => p.Id);

            builder
                .Property(p => p.ImageUrl)
                .HasMaxLength(500);

            builder
                .Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(p => p.Resume)
                .HasMaxLength(1000)
                .IsRequired();

            builder
                .Property(p => p.Job)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(p => p.Phone)
                .HasConversion<string>(p => p.Number, s => (Phone)s)
                .IsRequired();

            builder
                .Property(p => p.UrlGithub)
                .HasMaxLength(500);

            builder
                .HasMany(p => p.LeadsCreatedByMe)
                .WithOne(l => l.CreatedBy)
                .HasForeignKey(l => l.CreatedById);

        }
    }

}
