using FluentValidation.Results;
using RedSpark.Thot.Api.Domain.Entities.Leads;

namespace RedSpark.Thot.Api.Domain.Interfaces.Validators
{
    public interface ILeadValidator
    {
        bool Creation(Lead lead);
    }
}
