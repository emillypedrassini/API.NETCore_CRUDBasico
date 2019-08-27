using CRUDBasico.Domain.Interfaces.Repository;
using CRUDBasico.Domain.Interfaces.Service;
using CRUDBasico.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDBasico.Domain.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public FuncionarioService(IFuncionarioRepository funcionarioRepository,
                                  IEnderecoRepository enderecoRepository)
        {
            _funcionarioRepository = funcionarioRepository;
            _enderecoRepository = enderecoRepository;
        }

        public async Task<Funcionario> Get(int id)
        {
            return await _funcionarioRepository.Get(id);
        }

        public async Task<IEnumerable<Funcionario>> GetAll()
        {
            return await _funcionarioRepository.GetAll();
        }

        public async Task<bool> Post(Funcionario funcionario)
        {
            if (funcionario == null)
                return false;

            if (funcionario.Id != 0 && _funcionarioRepository.Get(funcionario.Id) != null)
                return false;

            await _funcionarioRepository.Post(funcionario);
            return true;
        }

        public async Task Put(Funcionario funcionario)
        {
            if (funcionario == null)
                return;

            await _funcionarioRepository.Put(funcionario);
        }

        public async Task Delete(Funcionario funcionario)
        {
            if (funcionario == null)
                return;

            //var enderecoFuncionario = _funcionarioRepository.GetFuncioanrioEndereco(funcionario.Id);

            //if (enderecoFuncionario != null)
            //{
                //await _enderecoRepository.Delete(funcionario.Endereco);
            //}

            await _funcionarioRepository.Delete(funcionario);
        }

        public void Dispose()
        {
            _funcionarioRepository?.Dispose();
        }

    }
}
