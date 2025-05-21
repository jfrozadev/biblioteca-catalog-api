namespace biblioteca_catalog.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
                typeof(DependencyInjection).Assembly,
                typeof(CreateLivroCommandHandler).Assembly));

            services.AddDbContext<biblioteca_catalogDbContext>(options =>
                options.UseSqlServer("Server=.;Database=biblioteca_catalog;Trusted_Connection=True;"));

            services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IAssuntoRepository, AssuntoRepository>();
            services.AddScoped<IAutorRepository, AutorRepository>();
            services.AddScoped<ILivroRepository, LivroRepository>();

            return services;
        }
    }
}
