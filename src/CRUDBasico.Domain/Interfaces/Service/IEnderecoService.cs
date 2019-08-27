using CRUDBasico.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDBasico.Domain.Interfaces.Service
{
    public interface IEnderecoService : IDisposable
    {
        Task<IEnumerable<Endereco>> GetAll();
        Task<Endereco> Get(int id);
        Task Put(Endereco endereco);
        Task Post(Endereco endereco);
        Task Delete(Endereco endereco);
    }
}
