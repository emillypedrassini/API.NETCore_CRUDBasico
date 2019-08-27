using CRUDBasico.Data.Context;
using CRUDBasico.Domain.Interfaces.Repository;
using CRUDBasico.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDBasico.Data.Repository
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class, new ()
    {
        protected readonly MeuDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        protected RepositoryBase(MeuDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> Get(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task Put(TEntity entity)
        {
            _dbSet.Update(entity);
            await SaveChanges();
        }

        public async Task Post(TEntity entity)
        {
            _dbSet.Add(entity);
            await SaveChanges();
        }

        public async Task Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            await SaveChanges();
        }
        
        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
