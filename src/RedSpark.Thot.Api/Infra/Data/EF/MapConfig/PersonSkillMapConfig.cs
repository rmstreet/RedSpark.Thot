
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedSpark.Thot.Api.Domain.Entities.Skills;

namespace RedSpark.Thot.Api.Infra.Data.EF.MapConfig
{
    public class PersonSkillMapConfig : IEntityTypeConfiguration<PersonSkill>
    {
        public void Configure(EntityTypeBuilder<PersonSkill> builder)
        {
            builder.ToTable("PersonSkill");

            builder.HasKey(ps => new { ps.PersonId, ps.SkillId });

            builder
                .HasOne(ps => ps.Person)
                .WithMany(p => p.MySkills)
                .HasForeignKey(ps => ps.PersonId);

            builder
                .HasOne(ps => ps.Skill)
                .WithMany(s => s.PersonSkill)
                .HasForeignKey(ps => ps.SkillId);

        }
    }

}
