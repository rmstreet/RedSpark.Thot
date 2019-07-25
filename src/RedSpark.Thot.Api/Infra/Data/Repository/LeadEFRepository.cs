using Microsoft.EntityFrameworkCore;
using RedSpark.Thot.Api.Domain.Entities.Leads;
using RedSpark.Thot.Api.Domain.Interfaces.Repositories;
using RedSpark.Thot.Api.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RedSpark.Thot.Api.Data.Repository
{
    public class LeadEFRepository : BaseRepository<Lead>, ILeadRepository
    {
        public LeadEFRepository(DbSet<Lead> dbSet) : base(dbSet)
        {
        }

        public IEnumerable<Lead> GetAll(Expression<Func<Lead, bool>> filter)
        {
            return _dbSet.Where(filter);
        }
    }
}
