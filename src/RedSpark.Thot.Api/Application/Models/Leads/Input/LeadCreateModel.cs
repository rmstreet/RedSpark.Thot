
namespace RedSpark.Thot.Api.Application.Models.Leads.Input
{
    public class LeadCreateModel
    {
        public string Title { get; set; }
        public string Status { get; set; }
        internal int CreatedById { get; set; }
    }
}
