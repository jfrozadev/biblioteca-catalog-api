using System.Collections.Generic;

namespace biblioteca_catalog.Domain.Entities
{
    public class Assunto
    {
        public int CodAs { get; set; }
        public required string Descricao { get; set; }

        public ICollection<Livro_Assunto> Livros_Assuntos { get; set; } = new List<Livro_Assunto>();
    }
}
