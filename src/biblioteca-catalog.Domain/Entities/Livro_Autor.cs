using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biblioteca_catalog.Domain.Entities
{
    public class Livro_Autor
    {
        public int Livro_Codl { get; set; }
        public int Autor_CodAu { get; set; }

        // Propriedades de Navegação
        public virtual Livro? Livro { get; set; } // Tornado anulável
        public virtual Autor? Autor { get; set; } // Tornado anulável.....
    }
}
