using MyFirstAPI.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapGet("/", () => "Minha primeira Web API está funcionado");


//cria uma lista 
var clientes = new List<Cliente>
{
    new Cliente
    {
        Id = 1,
        Nome = "Vlademir",
        Email = "vlade@email.com"
    },

    new Cliente
    {
        Id = 2,
        Nome = "Maria",
        Email = "maria@email.com"
    }
};
//Foi alocado abaixo pq primeiro foi criado a lista /clientes
//que o endpoint /clientes precisa utilizar
app.MapGet("/clientes", () =>
{
    return clientes;
});


app.Run();

