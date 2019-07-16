using System;
using System.ComponentModel.DataAnnotations;

namespace RedSpark.Thot.Api.Models
{
    public class LeadSummary
    {
        
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        public LeadStatus Status { get; set; }


        public bool IsFollowing { get; set; }
        public int FollowerAmount { get; set; }
        public int ComentAmount { get; set; }
        public DateTime UpdateDate { get; set; }

        internal bool CanUpdate()
        {
            // TODO: Validação de Update
            return true;
        }
    }
}
