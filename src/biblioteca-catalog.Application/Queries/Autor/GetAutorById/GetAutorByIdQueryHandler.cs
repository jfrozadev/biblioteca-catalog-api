using AutoMapper;
using MediatR;
using biblioteca_catalog.Application.DTOs.EntityDtos;
using biblioteca_catalog.Domain.Interfaces; // Adicionar este using

namespace biblioteca_catalog.Application.Queries.Autor.GetAutorById
{
 public class GetAutorByIdQueryHandler : IRequestHandler<GetAutorByIdQuery, AutorDto>
    {
        private readonly IAutorRepository _autorRepository; // Usar a interface do repositório
        private readonly IMapper _mapper;

        public GetAutorByIdQueryHandler(IAutorRepository autorRepository, IMapper mapper) // Injetar o repositório e o mapper
        {
            _autorRepository = autorRepository;
            _mapper = mapper;
        }

 public async Task<AutorDto> Handle(GetAutorByIdQuery request, CancellationToken cancellationToken)
        {
            var autor = await _autorRepository.GetByIdAsync(request.CodAu); // Buscar o autor usando o repositório
            
            if (autor == null)
            {
                return null;
            }

            var autorDto = _mapper.Map<AutorDto>(autor);
            return autorDto;
        }
    }
}