using AutoMapper;
using biblioteca_catalog.Domain.Interfaces;
using biblioteca_catalog.Application.DTOs.EntityDtos;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace biblioteca_catalog.Application.Queries.Assunto.GetAllAssuntos
{
    public class GetAllAssuntosQueryHandler : IRequestHandler<GetAllAssuntosQuery, IEnumerable<AssuntoDto>>
    {
        private readonly IAssuntoRepository _assuntoRepository;
        private readonly IMapper _mapper;

        public GetAllAssuntosQueryHandler(IAssuntoRepository assuntoRepository, IMapper mapper)
        {
            _assuntoRepository = assuntoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AssuntoDto>> Handle(GetAllAssuntosQuery request, CancellationToken cancellationToken)
        {
            var assuntos = await _assuntoRepository.GetAssuntosAsync();
            return _mapper.Map<IEnumerable<AssuntoDto>>(assuntos);
        }
    }
}