using RedSpark.Thot.Api.Domain.Core.Entities;
using RedSpark.Thot.Api.Domain.Entities.Persons;
using System.Collections.Generic;

namespace RedSpark.Thot.Api.Domain.Entities.Leads
{
    public class Coment : Entity
    {
        public Coment(string description, int? fatherComentId)
        {
            Description = description;
            FatherComentId = fatherComentId;
        }

        public string Description { get; private set; }
        
        public int LeadId { get; private set; }
        public Lead Lead { get; private set; }

        public int? FatherComentId { get; private set; }
        public Coment FatherComent { get; private set; }
                
        public int CreatedById { get; private set; }
        public Person CreatedBy { get; private set; }

        public List<Coment> Answers { get; private set; }
    }
}
