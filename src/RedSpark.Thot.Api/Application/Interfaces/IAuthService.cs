using RedSpark.Thot.Api.Application.Models.Users.Input;
using RedSpark.Thot.Api.Application.Models.Users.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedSpark.Thot.Api.Application.Interfaces
{
    public interface IAuthService
    {
        Task<UserCreatedModel> Register(UserCreateModel newUser);
    }
}
