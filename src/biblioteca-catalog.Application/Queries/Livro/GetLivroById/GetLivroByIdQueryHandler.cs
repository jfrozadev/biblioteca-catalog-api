using AutoMapper;
using MediatR;
using biblioteca_catalog.Application.DTOs.EntityDtos;
using biblioteca_catalog.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace biblioteca_catalog.Application.Queries.Livro.GetLivroById
{
    public class GetLivroByIdQueryHandler : IRequestHandler<GetLivroByIdQuery, LivroDto>
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IMapper _mapper;

        public GetLivroByIdQueryHandler(ILivroRepository livroRepository, IMapper mapper)
        {
            _livroRepository = livroRepository;
            _mapper = mapper; // Atribui o mapper injetado à variável de instância
        }

        public async Task<LivroDto> Handle(GetLivroByIdQuery request, CancellationToken cancellationToken)
        {
            var livro = await _livroRepository.GetByIdAsync(request.Codl);

            if (livro == null)
            {
                return null;
            }

            return _mapper.Map<LivroDto>(livro);
        }
    }
}
