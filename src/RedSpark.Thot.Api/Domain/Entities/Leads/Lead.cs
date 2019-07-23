
using RedSpark.Thot.Api.Domain.Core.Entities;
using RedSpark.Thot.Api.Domain.Entities.Persons;
using System.Collections.Generic;

namespace RedSpark.Thot.Api.Domain.Entities.Leads
{
    public class Lead : Entity
    {
        public Lead(string title, int createdById, LeadStatus status)
        {
            // TODO: Validar os dados entrada

            Title = title;
            CreatedById = createdById;
            Status = status;
        }

        public string Title { get; private set; }
        public int CreatedById { get; private set; }
        public Person CreatedBy { get; private set; }
        public LeadStatus Status { get; private set; }

        public List<PersonLead> PersonsFollowing { get; private set; }
        public List<Coment> Coments { get; private set; }
        // hoc setters
        public void Update(string title, LeadStatus status)
        {
            // TODO: Validar as entradas

            Title = title;            
            Status = status;
        }
    }

}
