using AutoMapper;
using biblioteca_catalog.Application.DTOs.EntityDtos;
using biblioteca_catalog.Domain.Entities;
using biblioteca_catalog.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace biblioteca_catalog.Application.Commands.Assunto.CreateAssunto
{
    public class CreateAssuntoCommandHandler : IRequestHandler<CreateAssuntoCommand, AssuntoDto>
    {
        private readonly IAssuntoRepository _assuntoRepository;
        private readonly IMapper _mapper;

        public CreateAssuntoCommandHandler(IAssuntoRepository assuntoRepository, IMapper mapper)
        {
            _assuntoRepository = assuntoRepository;
            _mapper = mapper;
        }

        public async Task<AssuntoDto> Handle(CreateAssuntoCommand request, CancellationToken cancellationToken)
        {
            var assunto = _mapper.Map<Domain.Entities.Assunto>(request);

            var createdAssunto = await _assuntoRepository.CreateAsync(assunto);

            return _mapper.Map<AssuntoDto>(createdAssunto);
        }
    }
}