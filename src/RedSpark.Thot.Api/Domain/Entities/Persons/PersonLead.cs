using RedSpark.Thot.Api.Domain.Core.Entities;
using RedSpark.Thot.Api.Domain.Models.Leads;

namespace RedSpark.Thot.Api.Domain.Entities.Persons
{
    
    public class PersonLead : Entity
    {

        public int PersonId { get; private set; }
        public Person Person { get; private set; }

        public int LeadId { get; private set; }
        public Lead Lead { get; private set; }

    }
}
