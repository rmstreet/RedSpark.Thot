
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedSpark.Thot.Api.Domain.Entities.Skills;
using RedSpark.Thot.Api.Infra.Data.EF.MapConfig.Extensions;

namespace RedSpark.Thot.Api.Infra.Data.EF.MapConfig
{
    public class ProjectSkillMapConfig : IEntityTypeConfiguration<ProjectSkill>
    {
        public void Configure(EntityTypeBuilder<ProjectSkill> builder)
        {
            builder.ToTable("ProjectSkill");

            builder.HasKey(ps => new { ps.ProjectId, ps.SkillId });

            builder
                .HasOne(ps => ps.Project)
                .WithMany(p => p.Skills)
                .HasForeignKey(ps => ps.ProjectId);

            builder
                .HasOne(ps => ps.Skill)
                .WithMany(p => p.ProjectSkills)
                .HasForeignKey(ps => ps.SkillId);

            builder
                .ConfigMapDefaultFields();

        }
    }
}
