
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
                .Property(p => p.Email)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder
                .Property(p => p.Job)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder
                .Property(p => p.Phone)
                .HasColumnType("varchar(11)")
                .HasConversion<string>(p => p.Number, s => (Phone)s);
                        
            builder
                .Property(p => p.Active)
                .IsRequired();

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

            // Reference: The child/dependent side could not be determined for the one-to-one relationship between 'User.Person' and 'Person.User'. To identify the child/dependent side of the relationship, configure the foreign key property. If these navigations should not be part of the same relationship configure them without specifying the inverse. See http://go.microsoft.com/fwlink/?LinkId=724062 for more details.
            //builder
            //    .HasOne(p => p.User)
            //    .WithOne(u => u.Person)
            //    .HasForeignKey<Person>(p => p.UserId);

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
