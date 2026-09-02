using MyFirstAPI.Repository;
using MyFirstAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddControllers();

builder.Services.AddSingleton<ClienteRepository>();

builder.Services.AddSingleton<ClienteService>();

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();

app.UseSwaggerUI( options =>
{
    options.SwaggerEndpoint("/openapi/v1.json", "API v1");
});

app.MapControllers();

app.MapGet("/", () => "Minha primeira Web API está funcionando");



app.Run();

