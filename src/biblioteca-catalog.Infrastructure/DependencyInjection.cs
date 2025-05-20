using Microsoft.Extensions.DependencyInjection;
using biblioteca_catalog.Domain.Interfaces;
using biblioteca_catalog.Infrastructure.Repositories;
using biblioteca_catalog.Infrastructure.Data.Context;

namespace biblioteca_catalog.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<biblioteca_catalogDbContext>();
            services.AddScoped<IAssuntoRepository, AssuntoRepository>();
            services.AddScoped<IAutorRepository, AutorRepository>();
            services.AddScoped<ILivroRepository, LivroRepository>();

            return services;
        }
    }
}
