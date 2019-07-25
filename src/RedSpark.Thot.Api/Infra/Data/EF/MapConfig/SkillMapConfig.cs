
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedSpark.Thot.Api.Domain.Entities.Skills;

namespace RedSpark.Thot.Api.Infra.Data.EF.MapConfig
{
    public class SkillMapConfig : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.ToTable("Skill");

            builder
                .HasKey(s => s.Id);

            builder
                .Property(s => s.Name)
                .HasColumnType("varchar(50)")
                .IsRequired();
        }
    }

}
