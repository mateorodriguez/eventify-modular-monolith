using Eventify.Modules.Events.Application.Abstractions;
using Eventify.Modules.Events.Domain.Events;
using Eventify.Modules.Events.Infrastructure.Data;
using Eventify.Modules.Events.Infrastructure.Database;
using Eventify.Modules.Events.Infrastructure.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Npgsql;

namespace Eventify.Modules.Events.Infrastructure;

public static class EventsModule
{
    public static IServiceCollection AddEventsModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureApplicationLayer(configuration);
        services.ConfigureEventsDatabase(configuration);
        
        return services;
    }

    private static void ConfigureApplicationLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Application.AssemblyReference.Assembly);
        });
        
        services.AddValidatorsFromAssembly(Application.AssemblyReference.Assembly);
    }
    
    private static void ConfigureEventsDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("Database")!;
        
        NpgsqlDataSource npgsqlDataSource = new NpgsqlDataSourceBuilder(connectionString).Build();
        services.TryAddSingleton(npgsqlDataSource);

        services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();

        services.AddDbContext<EventsDbContext>(options =>
            options
                .UseNpgsql(
                    connectionString,
                    npgsqlOptions => npgsqlOptions
                        .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Events))
                .UseSnakeCaseNamingConvention());

        services.AddScoped<IEventRepository, EventRepository>();

        services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<EventsDbContext>());
    }
}