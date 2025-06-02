using Lab11_MiguelQuispe.Domain.Interfaces;
using Lab11_MiguelQuispe.Infraestructure.Context;
using Lab11_MiguelQuispe.Infraestructure.Repositories;
using Lab11_MiguelQuispe.Infraestructure.Repositories.Unit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lab11_MiguelQuispe.Infraestructure.configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection")
                               ?? throw new InvalidOperationException("Missing connection string 'DefaultConnection'");

        services.AddDbContext<TicketeraDb>(options =>
            options.UseMySQL(connectionString));
        
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        

        return services;
    }
}