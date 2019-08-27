using AutoMapper;
using CRUDBasico.API.ViewModels;
using CRUDBasico.Domain.Models;

namespace CRUDBasico.API.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Funcionario, FuncionarioViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
        }
    }
}
