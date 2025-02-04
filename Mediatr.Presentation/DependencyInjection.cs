using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
namespace Mediatr.Presentation;

public static class DependencyInjection
{
    public static void AddPresentationServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        //builder.Services.AddHttpContextAccessor();
    }
}
