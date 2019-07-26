using RedSpark.Thot.Api.Application.Models.Generics.Output;
using System.Collections.Generic;

namespace RedSpark.Thot.Api.Application.Models.Leads.Output
{
    public class LeadDetailsModel : BaseModel
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string CreatedBy { get; set; }
        public string Status { get; set; }
        public bool? IsFollowing { get; set; }
        public int? FollowerAmount { get; set; }
        public int? ComentAmount { get; set; }
        public List<ComentModel> Coments { get; set; }
        public bool? OnNotification { get; set; }
    }
}
