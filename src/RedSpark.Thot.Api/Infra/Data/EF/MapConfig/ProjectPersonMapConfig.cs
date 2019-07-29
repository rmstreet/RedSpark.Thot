
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedSpark.Thot.Api.Domain.Entities.Projects;
using RedSpark.Thot.Api.Infra.Data.EF.MapConfig.Extensions;

namespace RedSpark.Thot.Api.Infra.Data.EF.MapConfig
{
       
   public class ProjectPersonMapConfig : IEntityTypeConfiguration<ProjectPerson>
   {
        public void Configure(EntityTypeBuilder<ProjectPerson> builder)
        {
            builder.ToTable("ProjectPerson");

            builder.HasKey(pp => new { pp.ProjectId, pp.PersonId });

            builder
                .HasOne(pp => pp.Project)
                .WithMany(p => p.Members)
                .HasForeignKey(pp => pp.ProjectId);

            builder
                .HasOne(pp => pp.Person)
                .WithMany(p => p.ProjectsMember)
                .HasForeignKey(pp => pp.PersonId);

            builder
                .ConfigMapDefaultFields();

        }
   }   

}
