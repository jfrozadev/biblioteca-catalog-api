using AutoMapper;
using MediatR;
using biblioteca_catalog.Application.DTOs.EntityDtos; // Use the correct DTO namespace
using biblioteca_catalog.Domain.Interfaces; // Add this using for repository interface
using System.Threading;
using System.Threading.Tasks;

namespace biblioteca_catalog.Application.Queries.Livro.GetLivroById
{
    public class GetLivroByIdQueryHandler : IRequestHandler<GetLivroByIdQuery, LivroDto>
    {
        private readonly ILivroRepository _livroRepository; // Use the repository interface
        private readonly IMapper _mapper;

        public GetLivroByIdQueryHandler(ILivroRepository livroRepository, IMapper mapper) // Inject repository and mapper
        {
            _livroRepository = livroRepository;
        }

        public async Task<LivroDto> Handle(GetLivroByIdQuery request, CancellationToken cancellationToken)
        {
            var livro = await _livroRepository.GetByIdAsync(request.Codl); // Use the repository to get the livro

            if (livro == null)
            {
                return null;
            }

            return _mapper.Map<LivroDto>(livro);
        }
    }
}