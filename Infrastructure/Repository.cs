using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Infrastructure
{

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, IAggregateRoot
    {
        public Repository(FlightsContext context)
        {
            Context = context;
        }

        protected FlightsContext Context { get; private set; }

        public TEntity Add(TEntity entity)
        {
            return Context.Add(entity).Entity;
        }

        public void Update(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
        }

        public async Task<TEntity> GetAsync(Guid id)
        {
            return await Context.Set<TEntity>().FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}
