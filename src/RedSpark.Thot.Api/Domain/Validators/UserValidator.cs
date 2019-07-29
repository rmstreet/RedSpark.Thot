
using RedSpark.Thot.Api.Domain.Core.Notifications;
using RedSpark.Thot.Api.Domain.Entities.Persons;
using RedSpark.Thot.Api.Domain.Interfaces.Repositories;
using RedSpark.Thot.Api.Domain.Interfaces.Validators;
using RedSpark.Thot.Api.Domain.Queries;
using System.Linq;
using static RedSpark.Thot.Api.Domain.Entities.Persons.User.ValidationRules;

namespace RedSpark.Thot.Api.Domain.Validators
{
    public class UserValidator : BaseValidator, IUserValidator
    {
        private CreationRules _creation;
        private IPersonRepository _personRepository;

        public UserValidator(CreationRules creation, IPersonRepository personRepository, INotificationHandler notificationHandler) 
            : base(notificationHandler)
        {
            _creation = creation;
            _personRepository = personRepository;
        }

        public bool Creation(User user)
        {
            var isValid = IsValid(_creation.Validate(user));

            if (isValid && FindPerson(user) == null)
            {                
                AddNotification("user.email.not.person.register");
            }
            return isValid;
        }

        private Person FindPerson(User user)
        {
            return _personRepository.GetAll(1, default(int), PersonQuery.FindByEmail(user.Email)).SingleOrDefault();
        }
    }
}
