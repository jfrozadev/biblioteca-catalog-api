using MediatR;

namespace biblioteca_catalog.Application.Commands.Livro.UpdateLivro
{
    public class UpdateLivroCommand : IRequest<Unit>
    {
        public int Codl { get; set; }
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public int Edicao { get; set; }
        public string AnoPublicacao { get; set; }
    }
}