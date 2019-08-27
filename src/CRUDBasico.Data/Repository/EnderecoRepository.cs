using CRUDBasico.Data.Context;
using CRUDBasico.Domain.Interfaces.Repository;
using CRUDBasico.Domain.Models;

namespace CRUDBasico.Data.Repository
{
    public class EnderecoRepository : RepositoryBase<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(MeuDbContext context) : base(context) { }
    }
}
