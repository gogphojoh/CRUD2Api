using Microsoft.EntityFrameworkCore;
using CRUD2Api.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("TiendaDatabase");
// Configurar el contexto de Entity Framework para usar MySQL
builder.Services.AddDbContext<TiendaContext>(options =>
    options.UseMySQL(connectionString));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();