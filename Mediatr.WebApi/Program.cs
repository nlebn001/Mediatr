using Mediatr.Application;
using Mediatr.Persistence;
using Mediatr.Presentation;
using Mediatr.WebApi;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.AddApplicationServices();
builder.AddPersistenceServices();
builder.AddInfrastructureServices();
builder.AddPresentationServices();
builder.AddWebApiServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    var openApiPath = "/openapi/v1.json";
    app.MapOpenApi();

    //OpenApi gets hosts http(s)://[::]:5000(5001) from docker container and sets servers to openapi
    //its needed to remove it to use with swaggerUI
    app.Use(async (context, next) =>
    {
        if (context.Request.Path == openApiPath)
        {
            var originalBody = context.Response.Body;
            using var ms = new MemoryStream();
            context.Response.Body = ms;

            await next();

            ms.Seek(0, SeekOrigin.Begin);
            var json = await new StreamReader(ms).ReadToEndAsync();
            var doc = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
            doc?.Remove("servers");

            var modifiedJson = JsonSerializer.Serialize(doc);
            var buffer = Encoding.UTF8.GetBytes(modifiedJson);

            context.Response.Body = originalBody;
            context.Response.ContentLength = buffer.Length;
            await context.Response.Body.WriteAsync(buffer);
        }
        else
            await next();
    });

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint(openApiPath, "OpenApi v1");
    });
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
