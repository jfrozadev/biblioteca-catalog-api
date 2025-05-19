using biblioteca_catalog.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Reflection;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Logging; // Adicionar using para logging

var builder = WebApplication.CreateBuilder(args);

// Configurar Logging para Console
builder.Logging.ClearProviders(); // Limpa os provedores de log existentes
builder.Logging.AddConsole(); // Adiciona o provedor de log para console

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adicionar serviços para Controllers
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "biblioteca-catalog.API", Version = "v1" });
});

// Configurar o DbContext com SQL Server
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection"); // Obtém a string de conexão do appsettings.Development.json

builder.Services.AddDbContext<biblioteca_catalogDbContext>(options =>
    options.UseSqlServer(connectionString)); // Configura o DbContext para usar SQL Server

// Configurar MediatR
builder.Services.AddMediatR(Assembly.GetExecutingAssembly()); // Adiciona MediatR ao container de DI

var app = builder.Build();

// Configure the HTTP request pipeline.
// Mova a configuração do Swagger para fora do if para que esteja sempre habilitado
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "biblioteca-catalog.API v1");
    c.RoutePrefix = string.Empty; // Define a rota raiz para o Swagger UI
});

app.UseHttpsRedirection();

// Mapear os endpoints das Controllers
app.MapControllers();

app.Run();