using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
namespace Mediatr.Presentation;

public static class DependencyInjection
{
    public static void AddPresentationServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        //builder.Services.AddHttpContextAccessor();
    }
}
