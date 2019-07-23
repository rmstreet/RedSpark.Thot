
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedSpark.Thot.Api.Domain.Core.ValueObject;
using RedSpark.Thot.Api.Domain.Entities.Persons;

namespace RedSpark.Thot.Api.Infra.Data.EF.MapConfig
{
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

            // Projects que o Person é Responsaável
            builder
                .HasMany(p => p.ProjectsResponsible)
                .WithOne(pj => pj.Responsible)
                .HasForeignKey(pj => pj.ResponsibleId);


            // Skills do Person - Não precisa mapeara qui, porque já é mapeado no PersonSkill
            //builder
            //    .HasMany(p => p.MySkills)
            //    .WithOne(sp => sp.Person)
            //    .HasForeignKey(sp => sp.PersonId);




        }
    }

}
