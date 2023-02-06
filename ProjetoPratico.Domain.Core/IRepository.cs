using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPratico.Domain.Core
{
    public interface IRepository<TEntity>
         where TEntity : AggregateRoot
    {
        void Add(TEntity item);

        void Delete(TEntity item);

        IEnumerable<TEntity> GetAll();

        Task<TEntity> GetAsync(int id);

        void Modify(TEntity item);
    }
}
