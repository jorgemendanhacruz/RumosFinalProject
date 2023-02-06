using Microsoft.EntityFrameworkCore;
using ProjetoPratico.Domain;
using ProjetoPratico.Domain.Core;
using ProjetoPratico.Infraestructure.data.Mapping;
using ProjetoPratico.Infraestructure.data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPratico.Infraestructure.data.UnitOfWork
{
    public class CookUnitOfWork : DbContext, ICookUnitOfWork
    {
        public async Task CommitAsync()
        {
            await base
                .SaveChangesAsync();
        }

        public DbSet<TEntity> CreateSet<TEntity>() 
            where TEntity : AggregateRoot
        {
            return base
                .Set<TEntity>();
        }

        public void SetModified<TEntity>(TEntity item)
            where TEntity : AggregateRoot
        {
            base.Entry<TEntity>(item)
                .State = EntityState.Modified;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=CPU_JORGE_CRUZ\SQLEXPRESS;Initial Catalog=ProjectRecipe;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserMap).Assembly);
        }

        
    }
}
