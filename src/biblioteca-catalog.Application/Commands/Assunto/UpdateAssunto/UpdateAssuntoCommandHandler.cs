using AutoMapper;
using biblioteca_catalog.Application.DTOs.EntityDtos;
using biblioteca_catalog.Domain.Entities;
using biblioteca_catalog.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace biblioteca_catalog.Application.Commands.Assunto.UpdateAssunto
{
    public class UpdateAssuntoCommandHandler : IRequestHandler<UpdateAssuntoCommand, AssuntoDto>
    {
        private readonly IAssuntoRepository _assuntoRepository;
        private readonly IMapper _mapper;

        public UpdateAssuntoCommandHandler(IAssuntoRepository assuntoRepository, IMapper mapper)
        {
            _assuntoRepository = assuntoRepository;
            _mapper = mapper;
        }

        public async Task<AssuntoDto> Handle(UpdateAssuntoCommand request, CancellationToken cancellationToken)
        {
            var assunto = await _assuntoRepository.GetByIdAsync(request.Id);

            if (assunto == null)
            {
                // TODO: Implementar tratamento de erro mais adequado (ex: NotFoundException)
                throw new ApplicationException($"Assunto com Id {request.Id} não encontrado.");
            }

            assunto.Descricao = request.Descricao;

            await _assuntoRepository.UpdateAsync(assunto);

            return _mapper.Map<AssuntoDto>(assunto);
        }
    }
}