using Mediatr.Presentation;

namespace Mediatr.WebApi;

public static class DependencyInjection
{
    /// <summary>
    /// For only API-specific configurations like Swagger, CORS, authentication, etc.
    /// </summary>
    /// <param name="builder"></param>
    public static void AddWebApiServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                policy => policy.AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader());
        });

        builder.Services.AddOpenApi();

        //adds controllers from presentation layer
        builder.Services.AddControllers()
            .AddApplicationPart(typeof(TodoController).Assembly);


    }
}
