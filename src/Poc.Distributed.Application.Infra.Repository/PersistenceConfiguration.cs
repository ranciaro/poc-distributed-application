using Microsoft.Extensions.DependencyInjection;
using Poc.Distributed.Application.Business.Domain.Interfaces;
using Poc.Distributed.Application.Infra.Repository.WriteOnly;

namespace Poc.Distributed.Application.Infra.Repository
{
    public static class PersistenceConfiguration
    {
        public static IServiceCollection AddRepository(this IServiceCollection service)
        {
            service.AddScoped<IUserRepository, UserWriteOnlyRepository>();
            return service;
        }
    }
}
