using MyFirstAPI.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapGet("/", () => "Minha primeira Web API está funcionado");


//cria uma lista já preenchida

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

app.MapGet("/clientes/{id}", (int id) =>
{
    var cliente = clientes.FirstOrDefault(cliente => cliente.Id == id);

    return cliente;
});

var proximoId = 3;

app.MapPost("/clientes", (Cliente cliente) =>
{
    cliente.Id = proximoId;
    proximoId ++;

    clientes.Add(cliente);

    return cliente;
});

app.MapPut("/clientes/{id}", (int id, Cliente clienteAtualizado) =>
{
    var cliente = clientes.FirstOrDefault(cliente => cliente.Id == id);
    if (cliente == null)
    {
        return Results.NotFound();
    }

    cliente.Nome = clienteAtualizado.Nome;
    cliente.Email = clienteAtualizado.Email;

    return Results.Ok(cliente);
});

app.MapDelete("/clientes/{id}", (int id) =>
{
   var cliente = clientes.FirstOrDefault(cliente => cliente.Id == id);

   if (cliente == null)
    {
        return Results.NotFound();
    }

    clientes.Remove (cliente);

    return Results.NoContent();
});

app.MapGet("/clientes", () =>
{
    return clientes;
});


app.Run();

