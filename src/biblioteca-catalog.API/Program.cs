using biblioteca_catalog.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Reflection;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Configurar Logging para Console
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// Adicionar serviços para Controllers (Configuração do Swagger para os Controllers)
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "biblioteca-catalog.API", Version = "v1" });
});

// Configurar o DbContext com SQL Server
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<biblioteca_catalogDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add Repositories
builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped<IAutorRepository, AutorRepository>();
builder.Services.AddScoped<IAssuntoRepository, AssuntoRepository>();

// Configurar MediatR
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "biblioteca-catalog.API v1");
    c.RoutePrefix = "swagger";
});

app.UseHttpsRedirection();

// Mapear os endpoints das Controllers
app.MapControllers();

app.Run();
