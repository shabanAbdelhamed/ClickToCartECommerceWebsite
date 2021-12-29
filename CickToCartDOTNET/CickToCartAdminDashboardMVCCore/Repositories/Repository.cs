using CickToCart.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CickToCart.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected ContextDataBase Context;
        public Repository(ContextDataBase contextData)
        {
            Context = contextData;
        }


        public async Task AddAsync(TEntity entity) => await Context.Set<TEntity>().AddAsync(entity);

        public async Task AddRangeAsync(IEnumerable<TEntity> entities) => await Context.Set<TEntity>().AddRangeAsync(entities);

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate) => await Context.Set<TEntity>().Where(predicate).ToListAsync();

        public async Task<TEntity> GetAsync(int id) => await Context.Set<TEntity>().FindAsync(id);

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await Context
            .Set<TEntity>()
            
            .ToListAsync();

        public void Remove(TEntity entity) =>  Context.Set<TEntity>().Remove(entity);
        public async Task<TEntity> Update(TEntity entity) {
            Context.Set<TEntity>().Update(entity);
          return entity;      
        }
           
        

        public async Task RemoveRangeAsync(IEnumerable<TEntity> entities) => await Context.Set<TEntity>().AddRangeAsync(entities);

        public void Attach(TEntity entity)
        {
            Context.Set<TEntity>().Attach(entity);
        }
    }
}
