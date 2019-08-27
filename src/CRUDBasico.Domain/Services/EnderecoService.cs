using CRUDBasico.Domain.Interfaces.Repository;
using CRUDBasico.Domain.Interfaces.Service;
using CRUDBasico.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRUDBasico.Domain.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public async Task<Endereco> Get(int id)
        {
            return await _enderecoRepository.Get(id);
        }

        public async Task<IEnumerable<Endereco>> GetAll()
        {
            return await _enderecoRepository.GetAll();
        }

        public async Task Post(Endereco endereco)
        {
            await _enderecoRepository.Post(endereco);
        }

        public async Task Put(Endereco endereco)
        {
            await _enderecoRepository.Put(endereco);
        }

        public async Task Delete(Endereco endereco)
        {
            await _enderecoRepository.Delete(endereco);
        }

        public void Dispose()
        {
            _enderecoRepository?.Dispose();
        }

    }
}
