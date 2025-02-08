using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Mediatr.Domain;

namespace Mediatr.Persistence;

public static class DependencyInjection
{
    /// <summary>
    /// Adds all the dependency injections within db communictaion
    /// </summary>
    /// <param name="builder"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public static void AddPersistenceServices(this IHostApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
            throw new ArgumentNullException($"Connection string is not found");

        builder.Services.AddDbContext<AppDbContext>((sp, options) =>
        {
            options.UseNpgsql(connectionString, opt =>
            {
                opt.MigrationsAssembly(typeof(AppDbContext).Assembly);
            });
        });

        builder.Services.AddScoped<ITodoRepository, TodoRepository>();
        builder.Services.AddScoped<IUnitOfWork>(factory => factory.GetRequiredService<AppDbContext>());

        builder.Services.AddHostedService<DbMigrationAgent>();
    }
}
