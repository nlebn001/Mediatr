using Mediatr.Application;
using Mediatr.Persistence;
using Mediatr.Presentation;
using Mediatr.WebApi;

var builder = WebApplication.CreateBuilder(args);

builder.AddApplicationServices();
builder.AddPersistenceServices();
builder.AddInfrastructureServices();
builder.AddPresentationServices();
builder.AddWebApiServices();
builder.Services.AddControllers()
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
