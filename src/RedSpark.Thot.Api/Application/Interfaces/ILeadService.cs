using RedSpark.Thot.Api.Application.Models.Leads.Input;
using RedSpark.Thot.Api.Application.Models.Leads.Output;

namespace RedSpark.Thot.Api.Application.Interfaces
{
    public interface ILeadService
    {
        LeadDetailsModel Creation(LeadCreateModel leadModel);
    }
}
