using RedSpark.Thot.Api.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedSpark.Thot.Api.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : Entity
    {
        TEntity Create(TEntity entity);
        TEntity GetById(int id);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
