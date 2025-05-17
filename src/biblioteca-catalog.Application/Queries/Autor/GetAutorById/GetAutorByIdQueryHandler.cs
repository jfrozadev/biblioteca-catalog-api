using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using biblioteca_catalog.Application.DTOs.EntityDtos;
using biblioteca_catalog.Infrastructure.Data.Context; // Verifique a namespace do seu DbContext

namespace biblioteca_catalog.Application.Queries.Autor.GetAutorById
{
    public class GetAutorByIdQueryHandler : IRequestHandler<GetAutorByIdQuery, AutorDto?>
    {
        private readonly biblioteca_catalogDbContext _context;
        private readonly IMapper _mapper;

        public GetAutorByIdQueryHandler(biblioteca_catalogDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AutorDto?> Handle(GetAutorByIdQuery request, CancellationToken cancellationToken)
        {
            var autor = await _context.Autores
                .FirstOrDefaultAsync(a => a.CodAu == request.CodAu, cancellationToken);

            if (autor == null)
            {
                return null;
            }

            var autorDto = _mapper.Map<AutorDto>(autor);
            return autorDto;
        }
    }
}