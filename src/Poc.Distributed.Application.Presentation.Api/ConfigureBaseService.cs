using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Poc.Distributed.Application.Business.Application;
using Poc.Distributed.Application.Infra.Bootstrap;
using Poc.Distributed.Application.Infra.Repository;
using System.Collections.Generic;

namespace Poc.Distributed.Application.Presentation.Api
{
    public static class ConfigureBaseService
    {
        private static IList<string> LocalEnvironments = new List<string> { "Local", "Dev" };
        public static IServiceCollection ConfigureBaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(InsertUserCommandHandler));
            services.AddSwaggerGen();
            services.AddRepository();
            services.AddKafka();
            return services;
        }
    }
}