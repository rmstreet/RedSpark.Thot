using RedSpark.Thot.Api.Domain.Core.Entities;
using RedSpark.Thot.Api.Domain.Entities.Leads;

namespace RedSpark.Thot.Api.Domain.Entities.Persons
{
    
    public class PersonLead : Entity
    {
        public PersonLead(int personId, int leadId)
        {
            PersonId = personId;
            LeadId = leadId;
        }

        public int PersonId { get; private set; }
        public Person Person { get; private set; }

        public int LeadId { get; private set; }
        public Lead Lead { get; private set; }

    }
}
