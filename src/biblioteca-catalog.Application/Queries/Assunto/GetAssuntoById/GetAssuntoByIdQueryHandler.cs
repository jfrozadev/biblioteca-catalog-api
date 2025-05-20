using AutoMapper;
using biblioteca_catalog.Application.DTOs.EntityDtos;
using biblioteca_catalog.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace biblioteca_catalog.Application.Queries.Assunto.GetAssuntoById
{
    public class GetAssuntoByIdQueryHandler : IRequestHandler<GetAssuntoByIdQuery, AssuntoDto>
    {
        private readonly IAssuntoRepository _assuntoRepository;
        private readonly IMapper _mapper;

        public GetAssuntoByIdQueryHandler(IAssuntoRepository assuntoRepository, IMapper mapper)
        {
            _assuntoRepository = assuntoRepository;
            _mapper = mapper;
        }

        public async Task<AssuntoDto> Handle(GetAssuntoByIdQuery request, CancellationToken cancellationToken)
        {
            var assunto = await _assuntoRepository.GetByIdAsync(request.Id);
            return _mapper.Map<AssuntoDto>(assunto);
        }
    }
}