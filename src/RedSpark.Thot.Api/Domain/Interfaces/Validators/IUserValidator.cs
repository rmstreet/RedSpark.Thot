
using RedSpark.Thot.Api.Domain.Entities.Persons;

namespace RedSpark.Thot.Api.Domain.Interfaces.Validators
{
    public interface IUserValidator
    {
        bool Creation(User user);
    }
}
