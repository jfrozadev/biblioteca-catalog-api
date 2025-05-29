csharp
namespace biblioteca_catalog.Domain.Entities
{
    public class Autor
    {
        public int CodAu { get; set; }
        public string Nome { get; set; }

        // Propriedade de navegação para a relação muitos-para-muitos com Livro
        public ICollection<LivroAutor> LivroAutores { get; set; }
    }
}
namespace biblioteca_catalog.Domain.Entities
{
    public class Livro
    {
        public int CodL { get; set; }
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public int Edicao { get; set; }
        public string AnoPublicacao { get; set; }

        // Propriedades de navegação para as relações
        public ICollection<LivroAutor> LivroAutores { get; set; }
        public ICollection<LivroAssunto> LivroAssuntos { get; set; }
    }
}
