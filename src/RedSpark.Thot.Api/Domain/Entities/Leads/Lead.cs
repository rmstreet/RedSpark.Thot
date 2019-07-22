
using RedSpark.Thot.Api.Domain.Core.Entities;
using RedSpark.Thot.Api.Domain.Entities.Persons;
using System.Collections.Generic;

namespace RedSpark.Thot.Api.Domain.Models.Leads
{
    public class Lead : Entity
    {
        public Lead(string title, Person createdBy, LeadStatus status)
        {
            // TODO: Validar os dados entrada

            Title = title;
            CreatedBy = createdBy;
            Status = status;
        }

        public string Title { get; private set; }
        public int CreatedById { get; private set; }
        public Person CreatedBy { get; private set; }
        public LeadStatus Status { get; private set; }

        public List<Person> PersonsFollowing { get; private set; }
        public List<LeadComent> Coments { get; private set; }
        
        public void Update(string title, LeadStatus status)
        {
            // TODO: Validar as entradas

            Title = title;            
            Status = status;
        }
    }

}
