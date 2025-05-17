csharp
using Microsoft.EntityFrameworkCore;
using biblioteca_catalog.Domain.Entities;

namespace biblioteca_catalog.Infrastructure.Data.Context
{
    public class biblioteca_catalogDbContext : DbContext
    {
        public biblioteca_catalogDbContext(DbContextOptions<biblioteca_catalogDbContext> options)
            : base(options)
        {
        }

        public DbSet<Livro> Livros { get; set; }

        // Adicione DbSets para Autor, Assunto, Livro_Autor, Livro_Assunto aqui quando as entidades forem criadas.

        // Opcionalmente, sobrescreva o método OnModelCreating para configurar relacionamentos e outras propriedades do modelo
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     // Configurações de modelo aqui
        //     base.OnModelCreating(modelBuilder);
        // }
    }
}