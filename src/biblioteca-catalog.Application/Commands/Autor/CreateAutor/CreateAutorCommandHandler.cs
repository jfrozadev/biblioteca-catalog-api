using MediatR;
using biblioteca_catalog.Domain.Entities;
using biblioteca_catalog.Domain.Interfaces;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using biblioteca_catalog.Application.DTOs.EntityDtos;

namespace biblioteca_catalog.Application.Commands.Autor.CreateAutor
{
    public class CreateAutorCommandHandler : IRequestHandler<CreateAutorCommand, AutorDto>
    {
        private readonly IAutorRepository _autorRepository;
        private readonly IMapper _mapper;

        public CreateAutorCommandHandler(IAutorRepository autorRepository, IMapper mapper)
        {
            _autorRepository = autorRepository;
            _mapper = mapper;
        }

        public async Task<AutorDto> Handle(CreateAutorCommand request, CancellationToken cancellationToken)
        {
            var autor = new biblioteca_catalog.Domain.Entities.Autor
            {
                Nome = request.Nome
            };

            await _autorRepository.AddAsync(autor);

            return _mapper.Map<AutorDto>(autor);
        }
    }
}
