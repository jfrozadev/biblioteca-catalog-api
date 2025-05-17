using MediatR;

namespace biblioteca_catalog.Application.Commands.Livro.CreateLivro
{
    public class CreateLivroCommand : IRequest<int>
    {
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public int Edicao { get; set; }
        public string AnoPublicacao { get; set; }
    }
}