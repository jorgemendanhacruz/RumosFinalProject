using Microsoft.EntityFrameworkCore;
using ProjetoPratico.Domain.Core;

namespace ProjetoPratico.Infraestructure.data.Repository
{
    public interface IQueryableUnitOfWork : IUnitOfWork
    {
        DbSet<TEntity> CreateSet<TEntity>() where TEntity : AggregateRoot;

        void SetModified<TEntity>(TEntity item) where TEntity : AggregateRoot;
    }
}