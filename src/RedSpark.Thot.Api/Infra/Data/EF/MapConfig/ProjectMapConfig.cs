
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedSpark.Thot.Api.Domain.Entities.Projects;
using RedSpark.Thot.Api.Infra.Data.EF.MapConfig.Extensions;

namespace RedSpark.Thot.Api.Infra.Data.EF.MapConfig
{
    public partial class ProjectMapConfig : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Project");

            builder.HasKey(p => p.Id);

            builder
                .Property(p => p.LogoUrl)
                .HasMaxLength(500);

            builder
                .Property(p => p.Name)
                .IsRequired();

            builder
                .Property(p => p.Company)
                .IsRequired();

            builder
                .Property(p => p.Description)
                .HasMaxLength(1000);

            builder
                .Property(p => p.BeginDate)
                .IsRequired();

            builder
                .Property(p => p.EndDate)
                .IsRequired();

            builder
                .HasOne(p => p.Responsible)
                .WithMany(r => r.ProjectsResponsible)
                .HasForeignKey(p => p.ResponsibleId);

            builder
                .ConfigMapDefaultFields();

        }
    }

}
