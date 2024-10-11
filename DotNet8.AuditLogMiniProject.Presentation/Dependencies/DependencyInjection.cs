namespace DotNet8.AuditLogMiniProject.Presentation.Dependencies;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services, WebApplicationBuilder builder)
    {
        return services.AddDbContextService(builder).AddDataAccessServices();
    }

    private static IServiceCollection AddDbContextService(this IServiceCollection services, WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
            opt.AddInterceptors(new AuditInterceptor());
        }, ServiceLifetime.Transient, ServiceLifetime.Transient);

        return services;
    }

    private static IServiceCollection AddDataAccessServices(this IServiceCollection services)
    {
        return services.AddScoped<IBlogService, BlogService>();
    }
}
