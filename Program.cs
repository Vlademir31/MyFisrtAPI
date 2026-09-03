using MyFirstAPI.Repository;
using MyFirstAPI.Services;
using MyFirstAPI.Interfaces;
using MyFirstAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddDbContext<MyFirstApiContext>(options =>  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnections")));

builder.Services.AddControllers();

builder.Services.AddSingleton<IClienteRepository, ClienteRepository>();

builder.Services.AddSingleton<IClienteService, ClienteService>();

builder.Services.AddSingleton<IFuncionarioRepository, FuncionarioRepository>();

builder.Services.AddSingleton<IFuncionarioService, FuncionarioService>();


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

