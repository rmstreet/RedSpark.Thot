using Microsoft.EntityFrameworkCore;
using RedSpark.Thot.Api.Domain.Core.Entities;
using RedSpark.Thot.Api.Domain.Interfaces.Repositories;
using System.Linq;

namespace RedSpark.Thot.Api.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity
    {

        protected DbSet<TEntity> _dbSet;

        public BaseRepository(DbSet<TEntity> dbSet)
        {
            _dbSet = dbSet;
        }

        public TEntity Create(TEntity entity)
        {
            _dbSet.Add(entity);
            return entity;
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
        
        public TEntity GetById(int id)
        {
            return _dbSet.SingleOrDefault(e => e.Id.Equals(id));

        }

        public TEntity Update(TEntity entity)
        {
            _dbSet.Update(entity);
            return entity;
        }
    }
}
