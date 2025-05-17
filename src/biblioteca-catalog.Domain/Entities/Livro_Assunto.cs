using System.Collections.Generic;

namespace biblioteca_catalog.Domain.Entities
{
    public class Livro_Assunto
    {
        public int Livro_Codl { get; set; }
        public int Assunto_codAs { get; set; }

        // Propriedades de navegação
        public Livro Livro { get; set; }
        public Assunto Assunto { get; set; }
    }
}