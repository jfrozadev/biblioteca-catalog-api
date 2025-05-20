using AutoMapper;
using biblioteca_catalog.Application.DTOs.EntityDtos;
using biblioteca_catalog.Domain.Interfaces;
using MediatR;

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
            var assuntos = await _assuntoRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<AssuntoDto>>(assuntos);
        }
    }
}
