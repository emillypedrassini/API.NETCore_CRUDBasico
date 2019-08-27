using CRUDBasico.Data.Context;
using CRUDBasico.Data.Repository;
using CRUDBasico.Domain.Interfaces.Repository;
using CRUDBasico.Domain.Interfaces.Service;
using CRUDBasico.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CRUDBasico.API.Configuration
{
    public static class DependencyInjectionsConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();

            services.AddScoped<IFuncionarioService, FuncionarioService>();
            services.AddScoped<IEnderecoService, EnderecoService>();

            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();

            return services;
        }
    }
}
