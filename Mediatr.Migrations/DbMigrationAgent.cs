using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Mediatr.Persistence;


/// <summary>
/// Agent which migrates DB while starting the app
/// </summary>
public class DbMigrationAgent : IHostedService
{
    private readonly IServiceProvider _serviceProvider;

    public DbMigrationAgent(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    /// <summary>
    /// On application startup, this method creates a scope, resolves your ApplicationDbContext,
    /// and applies any pending migrations to ensure that the database schema is up-to-date.
    /// </summary>
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        await context.Database.MigrateAsync(cancellationToken);
        scope.Dispose();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
