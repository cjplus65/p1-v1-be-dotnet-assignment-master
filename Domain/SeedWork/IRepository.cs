using System;
using System.Threading.Tasks;

namespace Domain.SeedWork
{
    public interface IRepository<TEntity> where TEntity : IAggregateRoot
    {
        TEntity Add(TEntity entity);

        void Update(TEntity entity);

        Task<TEntity> GetAsync(Guid id);
    }
}