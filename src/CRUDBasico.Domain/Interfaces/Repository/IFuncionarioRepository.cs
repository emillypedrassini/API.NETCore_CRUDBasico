using CRUDBasico.Domain.Models;
using System.Threading.Tasks;

namespace CRUDBasico.Domain.Interfaces.Repository
{
    public interface IFuncionarioRepository : IRepositoryBase<Funcionario>
    {
        Task<Funcionario> GetFuncioanrioEndereco(int id);
    }
}
