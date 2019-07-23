
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedSpark.Thot.Api.Domain.Models.Leads;

namespace RedSpark.Thot.Api.Infra.Data.EF.MapConfig
{
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
                .WithMany(p => p.ComentsByMe)
                .HasForeignKey(lc => lc.CreatedById);

            builder
                .HasOne(lc => lc.LeadComentFather)
                .WithMany(lcf => lcf.Answers)
                .HasForeignKey(lc => new { lc.AnswerLeadId, lc.AnswerComentId });


            builder
                .Ignore(lc => lc.Id);
        }
    }

}
