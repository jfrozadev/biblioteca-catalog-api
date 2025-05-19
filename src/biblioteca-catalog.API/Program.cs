using biblioteca_catalog.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using MediatR; // Adicionar using para MediatR
using System.Reflection; // Adicionar using para usar Assembly

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adicionar serviços para Controllers
builder.Services.AddControllers();

// Configurar o DbContext com SQL Server
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection"); // Obtém a string de conexão do appsettings.Development.json

builder.Services.AddDbContext<biblioteca_catalogDbContext>(options =>
    options.UseSqlServer(connectionString)); // Configura o DbContext para usar SQL Server

// Configurar MediatR
builder.Services.AddMediatR(Assembly.GetExecutingAssembly()); // Adiciona MediatR ao container de DI

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Mapear os endpoints das Controllers
app.MapControllers();

app.Run();
