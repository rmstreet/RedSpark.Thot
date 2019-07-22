using RedSpark.Thot.Api.Domain.Core.Entities;
using RedSpark.Thot.Api.Domain.Models.Leads;
using System.Collections.Generic;

namespace RedSpark.Thot.Api.Domain.Entities.Leads
{
    public class Coment : Entity
    {
        public Coment(string description)
        {
            Description = description;
        }

        public string Description { get; private set; }
        public List<LeadComent> LeadComents { get; private set; }
    }
}
