using RedSpark.Thot.Api.Domain.Entities.Leads;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RedSpark.Thot.Api.Domain.Interfaces.Repositories
{
    public interface ILeadRepository : IBaseRepository<Lead>
    {
        IEnumerable<Lead> GetAll(Expression<Func<Lead, bool>> filter);
    }
}
