
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedSpark.Thot.Api.Domain.Core.ValueObject;
using RedSpark.Thot.Api.Domain.Entities.Persons;
using RedSpark.Thot.Api.Infra.Data.EF.MapConfig.Extensions;

namespace RedSpark.Thot.Api.Infra.Data.EF.MapConfig
{
    public class PersonMapConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {            
            
            builder
                .Property(p => p.ImageUrl)
                .HasColumnType("varchar(500)");
            
            builder
                .Property(p => p.Name)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder
                .Property(p => p.Resume)
                .HasColumnType("varchar(1000)");

            builder
                .Property(p => p.Job)
                .HasColumnType("varchar(50)");

            builder
                .Property(p => p.Phone)
                .HasColumnType("varchar(11)")
                .HasConversion<string>(p => p.Number, s => (Phone)s);

            builder
                .Property(p => p.UrlGithub)
                .HasColumnType("varchar(500)");

            builder
                .HasMany(p => p.LeadsCreatedByMe)
                .WithOne(l => l.CreatedBy)
                .HasForeignKey(l => l.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            // Projects que o Person é Responsaável
            builder
                .HasMany(p => p.ProjectsResponsible)
                .WithOne(proj => proj.Responsible)
                .HasForeignKey(proj => proj.ResponsibleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .ConfigMapDefaultFields();

            // Skills do Person - Não precisa mapeara qui, porque já é mapeado no PersonSkill
            //builder
            //    .HasMany(p => p.MySkills)
            //    .WithOne(sp => sp.Person)
            //    .HasForeignKey(sp => sp.PersonId);

        }
    }

}
