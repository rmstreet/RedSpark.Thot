using RedSpark.Thot.Api.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RedSpark.Thot.Api.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : Entity
    {
        TEntity Create(TEntity entity);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll(int take = 50, int skip = 0, Expression<Func<TEntity, bool>> filter = null);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
