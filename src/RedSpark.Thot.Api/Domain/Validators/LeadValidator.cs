using FluentValidation.Results;
using RedSpark.Thot.Api.Domain.Entities.Leads;
using RedSpark.Thot.Api.Domain.Interfaces.Validators;
using static RedSpark.Thot.Api.Domain.Entities.Leads.Lead.ValidationRules;

namespace RedSpark.Thot.Api.Domain.Validators
{
    public class LeadValidator : ILeadValidator
    {

        private CreationRules _creation;

        public LeadValidator(CreationRules creation)   //  <- Injetando mais abstrações para validação
        {
            _creation = creation;
        }

        public ValidationResult Creation(Lead lead)
        {
            // Mias Validações

            return _creation.Validate(lead);
        }
    }
}
