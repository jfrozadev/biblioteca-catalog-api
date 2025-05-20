csharp
using AutoMapper;
using biblioteca_catalog.Application.DTOs.EntityDtos;
using biblioteca_catalog.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace biblioteca_catalog.Application.Queries.Autor.GetAllAutores
{
    public class GetAllAutoresQueryHandler : IRequestHandler<GetAllAutoresQuery, IEnumerable<AutorDto>>
    {
        private readonly IAutorRepository _autorRepository;
        private readonly IMapper _mapper;

        public GetAllAutoresQueryHandler(IAutorRepository autorRepository, IMapper mapper)
        {
            _autorRepository = autorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AutorDto>> Handle(GetAllAutoresQuery request, CancellationToken cancellationToken)
        {
            var autores = await _autorRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AutorDto>>(autores);
        }
    }
}