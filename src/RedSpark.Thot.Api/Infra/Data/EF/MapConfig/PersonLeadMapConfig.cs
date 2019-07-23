
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedSpark.Thot.Api.Domain.Entities.Persons;

namespace RedSpark.Thot.Api.Infra.Data.EF.MapConfig
{
    public class PersonLeadMapConfig : IEntityTypeConfiguration<PersonLead>
    {
        public void Configure(EntityTypeBuilder<PersonLead> builder)
        {
            builder.ToTable("PersonLead");

            builder.HasKey(pl => new { pl.LeadId, pl.PersonId });

            builder
                .HasOne(pl => pl.Lead)
                .WithMany(l => l.PersonsFollowing)
                .HasForeignKey(pl => pl.LeadId);

            builder
                .HasOne(pl => pl.Person)
                .WithMany(p => p.LeadsFollowedByMe)
                .HasForeignKey(pl => pl.PersonId);


            builder
                .Ignore(pl => pl.Id);
        }
    }

}
