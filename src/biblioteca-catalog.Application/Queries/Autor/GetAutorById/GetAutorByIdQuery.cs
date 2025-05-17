using MediatR;
using biblioteca_catalog.Application.DTOs.EntityDtos; // Verifique se o namespace está correto

namespace biblioteca_catalog.Application.Queries.Autor.GetAutorById
{
    public class GetAutorByIdQuery : IRequest<AutorDto?>
    {
        public int CodAu { get; set; }
    }
}