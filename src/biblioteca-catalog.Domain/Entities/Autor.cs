using System.Collections.Generic;

namespace biblioteca_catalog.Domain.Entities
{
    public class Autor
    {
        public int CodAu { get; set; }
        public string Nome { get; set; }

        public List<Livro_Autor> LivroAutores { get; set; } = new List<Livro_Autor>();
    }
}