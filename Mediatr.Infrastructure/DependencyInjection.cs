
using Microsoft.Extensions.Hosting;

namespace Mediatr.Presentation;

public static class DependencyInjection
{
    /// <summary>
    /// File storage, APIs, caching (Redis), email services, logging, authentication
    /// </summary>
    /// <param name="builder"></param>
    public static void AddInfrastructureServices(this IHostApplicationBuilder builder)
    {

    }
}
