using FluentValidation.Results;
using RedSpark.Thot.Api.Domain.Core.Notifications;
using System.Collections.Generic;

namespace RedSpark.Thot.Api.Domain.Validators
{
    public abstract class BaseValidator
    {
        private INotificationHandler _notificationHandler;

        protected BaseValidator(INotificationHandler notificationHandler)
        {
            _notificationHandler = notificationHandler;
        }

        protected bool IsValid(ValidationResult validationResult)
        {
            bool isValid = validationResult.IsValid;
            if (!isValid)
            {
                AddNotifications(validationResult.Errors);
            }
            return isValid;
        }

        protected void AddNotifications(IList<ValidationFailure> validationFailures)
        {
            foreach (var error in validationFailures)
            {
                var notifications = new Notification(error.ErrorMessage);
                _notificationHandler.Handler(notifications);
            }
        }
    }
}
