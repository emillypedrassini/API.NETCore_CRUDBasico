using CRUDBasico.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRUDBasico.Domain.Interfaces.Service
{
    public interface IFuncionarioService : IDisposable
    {
        Task<IEnumerable<Funcionario>> GetAll();
        Task<Funcionario> Get(int id);
        Task Put(Funcionario funcionario);
        Task<bool> Post(Funcionario funcionario);
        Task Delete(Funcionario funcionario);
    }
}
