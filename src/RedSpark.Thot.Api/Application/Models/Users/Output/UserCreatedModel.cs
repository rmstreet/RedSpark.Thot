using RedSpark.Thot.Api.Application.Models.Generics.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedSpark.Thot.Api.Application.Models.Users.Output
{
    public class UserCreatedModel : BaseModel
    {
        public string Token { get; set; }
    }
}
