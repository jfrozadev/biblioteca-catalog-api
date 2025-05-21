using AutoMapper;
using biblioteca_catalog.Application.DTOs.EntityDtos;
using biblioteca_catalog.Domain.Entities;
using biblioteca_catalog.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace biblioteca_catalog.Application.Commands.Assunto.CreateAssunto
{
    public class CreateAssuntoCommandHandler : IRequestHandler<CreateAssuntoCommand, int>
    {
        private readonly IAssuntoRepository _assuntoRepository;
        private readonly IMapper _mapper;

        public CreateAssuntoCommandHandler(IAssuntoRepository assuntoRepository, IMapper mapper)
        {
            _assuntoRepository = assuntoRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateAssuntoCommand request, CancellationToken cancellationToken)
        {
            var assunto = new Assunto
            {
                Nome = request.Nome,
                Descricao = request.Descricao
            };

            var createdAssunto = await _assuntoRepository.CreateAsync(assunto);

            return createdAssunto.Id;
        }
    }
}
