using Microsoft.EntityFrameworkCore;
using RedSpark.Thot.Api.Domain.Core.CustomEnums;
using RedSpark.Thot.Api.Domain.Core.Entities;
using RedSpark.Thot.Api.Domain.Core.ValueObject;
using RedSpark.Thot.Api.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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

        public IEnumerable<TEntity> GetAll(
            int take = 50,
            int skip = 0, 
            Expression<Func<TEntity, bool>> filter = null
            )
        {
            var query = _dbSet.AsQueryable();

            if(filter != null)
            {
                query = _dbSet.Where(filter);
            }

            return query
                .Take(take)
                .Skip(0);            
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
