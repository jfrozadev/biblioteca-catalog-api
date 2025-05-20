using MediatR;
using biblioteca_catalog.Domain.Interfaces; // Adicionar este using
using biblioteca_catalog.Application.DTOs.EntityDtos;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using System.Collections.Generic; // Adicionar este using para KeyNotFoundException

namespace biblioteca_catalog.Application.Commands.Autor.UpdateAutor
{
    public class UpdateAutorCommandHandler : IRequestHandler<UpdateAutorCommand, AutorDto>
    {
        private readonly IAutorRepository _autorRepository; // Usar a interface do repositório
        private readonly IMapper _mapper;

        public UpdateAutorCommandHandler(IAutorRepository autorRepository, IMapper mapper) // Injetar a interface do repositório e o mapper
        {
            _autorRepository = autorRepository;
            _mapper = mapper;
        }

        public async Task<AutorDto> Handle(UpdateAutorCommand request, CancellationToken cancellationToken)
        {
            var autor = await _autorRepository.GetByIdAsync(request.CodAu); // Buscar o autor usando o repositório

            if (autor == null)
                throw new KeyNotFoundException($"Autor com Id {request.CodAu} não encontrado.");

            // Mapear as propriedades do comando para a entidade
            _mapper.Map(request, autor);
            autor.Nome = request.Nome;

            _autorRepository.Update(autor); // Atualizar o autor usando o repositório
            await _autorRepository.SaveAsync(); // Salvar as mudanças

            return _mapper.Map<AutorDto>(autor); // Retornar o DTO mapeado
        }
    }
}