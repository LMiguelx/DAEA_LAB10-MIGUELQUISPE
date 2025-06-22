using Hangfire;
using Hangfire.MySql;
using Lab11_MiguelQuispe.Domain.Interfaces;
using Lab11_MiguelQuispe.Infraestructure.Context;
using Lab11_MiguelQuispe.Infraestructure.Repositories;
using Lab11_MiguelQuispe.Infraestructure.Repositories.Unit;
using Lab11_MiguelQuispe.Infraestructure.Services;
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
        
        services.AddHangfire(config =>
            config.UseStorage(new MySqlStorage(connectionString, new MySqlStorageOptions
            {
                QueuePollInterval = TimeSpan.FromSeconds(15)
            })));
        
        services.AddHangfireServer();
        
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        
        services.AddScoped<IDataCleanupService, DataCleanupService>();
        
        var serviceProvider = services.BuildServiceProvider();
        var dataCleanupService = serviceProvider.GetService<IDataCleanupService>();
        

        return services;
    }
}