
using RedSpark.Thot.Api.Domain.Core.Entities;
using RedSpark.Thot.Api.Domain.Entities.Leads;
using RedSpark.Thot.Api.Domain.Entities.Persons;
using System.Collections.Generic;

namespace RedSpark.Thot.Api.Domain.Models.Leads
{
    public class LeadComent : Entity
    {               
        
        // Em que Lead Foi?
        public int LeadId { get; private set; }
        public Lead Lead { get; private set; }

        // Qual comentario?
        public int ComentId { get; private set; }
        public Coment Coment { get; private set; }

        // Quem Comentou?
        public int CreatedById { get; private set; }
        public Person CreatedBy { get; private set; }


        #region Resposta
        public int? AnswerLeadId { get; private set; }
        public int? AnswerComentId { get; private set; }

        public LeadComent LeadComentFather { get; private set; }

        public List<LeadComent> Answers { get; private set; }
        #endregion
    }

}
