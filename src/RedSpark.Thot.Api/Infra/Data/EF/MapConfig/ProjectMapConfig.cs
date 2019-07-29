
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedSpark.Thot.Api.Domain.Entities.Projects;
using RedSpark.Thot.Api.Infra.Data.EF.MapConfig.Extensions;

namespace RedSpark.Thot.Api.Infra.Data.EF.MapConfig
{
    public class ProjectMapConfig : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Project");

            builder.HasKey(p => p.Id);

            builder
                .Property(p => p.LogoUrl)
                .HasColumnType("varchar(500)");

            builder
                .Property(p => p.Name)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder
                .Property(p => p.Company)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder
                .Property(p => p.Description)
                .HasColumnType("varchar(1000)");

            builder
                .Property(p => p.BeginDate)
                .HasColumnType("datetime")
                .IsRequired();

            builder
                .Property(p => p.EndDate)
                .HasColumnType("datetime")
                .IsRequired();

            builder
                .HasOne(p => p.Responsible)
                .WithMany(r => r.ProjectsResponsible)
                .HasForeignKey(p => p.ResponsibleId)
                .IsRequired();

            builder
                .ConfigMapDefaultFields();

        }
    }

}
