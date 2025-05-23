using System.Collections.Generic;

namespace biblioteca_catalog.Domain.Entities
{
    public class Livro
    {
        public int Codl { get; set; }
        public required string Titulo { get; set; }
        public required string Editora { get; set; }
        public int Edicao { get; set; }
        public required string AnoPublicacao { get; set; }

        // Propriedades de navegação para as associações
        public ICollection<Livro_Autor> LivroAutores { get; set; } = new List<Livro_Autor>();
        public ICollection<Livro_Assunto> LivroAssuntos { get; set; } = new List<Livro_Assunto>();
    }
}
