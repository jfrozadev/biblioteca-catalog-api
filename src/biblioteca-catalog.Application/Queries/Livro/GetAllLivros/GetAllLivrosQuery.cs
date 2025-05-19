using MediatR;
using System.Collections.Generic;
using biblioteca_catalog.Application.DTOs;
using biblioteca_catalog.Application.DTOs.EntityDtos;

namespace biblioteca_catalog.Application.Queries.Livro.GetAllLivros
{
    public class GetAllLivrosQuery : IRequest<List<LivroDto>>
    {
        // Esta query não precisa de propriedades, pois retornará todos os livros.
    }
}