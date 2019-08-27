using CRUDBasico.Data.Context;
using CRUDBasico.Domain.Interfaces.Repository;
using CRUDBasico.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDBasico.Data.Repository
{
    public class FuncionarioRepository : RepositoryBase<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(MeuDbContext context) : base(context) { }

        public async Task<Funcionario> GetFuncioanrioEndereco(int id)
        {
            var funcionario = _dbSet.AsNoTracking()
                .Include(x => x.Endereco)
                .FirstOrDefaultAsync(x => x.Id == id);

            return await funcionario;
        }

        public bool FuncionarioExists(int id)
        {
            return _context.Funcionario.Any(x => x.Id == id);
        }
    }
}
