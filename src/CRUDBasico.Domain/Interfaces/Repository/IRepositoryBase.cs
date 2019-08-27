using CRUDBasico.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRUDBasico.Domain.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Get(int id);
        Task Put(TEntity entity);
        Task Post(TEntity entity);
        Task Delete(TEntity entity);

        Task<int> SaveChanges();
    }
}
