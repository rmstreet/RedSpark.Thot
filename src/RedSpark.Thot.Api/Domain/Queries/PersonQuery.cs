using RedSpark.Thot.Api.Domain.Entities.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RedSpark.Thot.Api.Domain.Queries
{
    public static class PersonQuery
    {
        public static Expression<Func<Person, bool>> FindByEmail(string email) => p => p.Email.Equals(email);
    }
}
