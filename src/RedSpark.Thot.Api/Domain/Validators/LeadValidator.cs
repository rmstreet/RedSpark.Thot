using RedSpark.Thot.Api.Domain.Core.Notifications;
using RedSpark.Thot.Api.Domain.Entities.Leads;
using RedSpark.Thot.Api.Domain.Interfaces.Validators;
using static RedSpark.Thot.Api.Domain.Entities.Leads.Lead.ValidationRules;

namespace RedSpark.Thot.Api.Domain.Validators
{
    public class LeadValidator : BaseValidator, ILeadValidator
    {

        private CreationRules _creation;
        
        public LeadValidator(CreationRules creation, INotificationHandler notificationHandler) //  <- Injetando mais abstrações para validação, se necessario.
            : base(notificationHandler)
        {
            _creation = creation;
        }

        public bool Creation(Lead lead)
        {
            return IsValid(_creation.Validate(lead));
        }
    }
}
