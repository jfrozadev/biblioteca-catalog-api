using Microsoft.EntityFrameworkCore;
using biblioteca_catalog.Domain.Entities;

namespace biblioteca_catalog.Infrastructure.Data.Context
{
    public class biblioteca_catalogDbContext : DbContext
    {
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Assunto> Assuntos { get; set; }
        public DbSet<Livro_Autor> Livros_Autores { get; set; }
        public DbSet<Livro_Assunto> Livros_Assuntos { get; set; }

        public biblioteca_catalogDbContext(DbContextOptions<biblioteca_catalogDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Livro_Autor>()
                .HasKey(la => new { la.LivroId, la.AutorId });

            modelBuilder.Entity<Livro_Assunto>()
                .HasKey(la => new { la.LivroId, la.AssuntoId });
        }
    }
}
