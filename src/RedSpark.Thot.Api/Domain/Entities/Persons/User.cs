
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System;

namespace RedSpark.Thot.Api.Domain.Entities.Persons
{
    public class User : IdentityUser<int>
    {

        #region Custom Fields
        private DateTime? _updateDate;
        private DateTime _createDate;
        public DateTime? UpdateDate => _updateDate;
        public DateTime CreateDate => _createDate;
        public bool Active { get; set; }
        public Person Person { get; private set; }
        #endregion

        public static class ValidationRules
        {
            public class CreationRules : AbstractValidator<User>
            {
                public CreationRules()
                {
                    RuleFor(user => user.UserName)
                        .NotEmpty().WithMessage("user.username.is.required");

                    RuleFor(user => user.Email)
                        .NotEmpty().WithMessage("user.email.is.required")
                        .EmailAddress().WithMessage("user.email.invalid");
                }
            }
        }

        internal void SetPerson(Person person)
        {            
            Person = person;
            Person.Actived();
        }
    }
}
