using System.Reflection.Metadata;
using EBOS.Audit.Domain.Interfaces.Repositories;
using EBOS.Audit.Infrastructure.Persistence;
using EBOS.Audit.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EBOS.Audit.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // DbContext registration
        services.AddDbContext<AuditDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("AuditConnection")));

        // Repositories base (AddScoped for per-request lifetime)
        services.AddScoped<IActivityLogRepository, ActivityLogRepository>();
        services.AddScoped<IAuditChangeRepository, AuditChangeRepository>();
        services.AddScoped<IDomainEventLogRepository, DomainEventLogRepository>();

        // Register Handlers or Infrastructure-specific services (if any, e.g. messaging services, file storage, etc.)
        //services.AddMediatR(cfg =>
        //    cfg.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly));

        return services;
    }
}