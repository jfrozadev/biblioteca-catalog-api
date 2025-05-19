
using biblioteca_catalog.Application.DTOs.EntityDtos;
using MediatR;

namespace biblioteca_catalog.Application.Queries.Livro.GetLivroById
{
    public class GetLivroByIdQuery : IRequest<LivroDto?>
    {
        public int Codl { get; set; }
    }
}