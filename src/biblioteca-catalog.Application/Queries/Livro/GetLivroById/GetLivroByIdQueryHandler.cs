csharp
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using biblioteca_catalog.Application.DTOs.Livro;
using biblioteca_catalog.Infrastructure.Data; // Adjust with your actual DbContext namespace

namespace biblioteca_catalog.Application.Queries.Livro.GetLivroById
{
    public class GetLivroByIdQueryHandler : IRequestHandler<GetLivroByIdQuery, LivroDto?>
    {
        private readonly ApplicationDbContext _context; // Adjust with your actual DbContext class
        private readonly IMapper _mapper;

        public GetLivroByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<LivroDto?> Handle(GetLivroByIdQuery request, CancellationToken cancellationToken)
        {
            var livro = await _context.Livros
                .FirstOrDefaultAsync(l => l.Codl == request.Codl, cancellationToken);

            if (livro == null)
            {
                return null;
            }

            return _mapper.Map<LivroDto>(livro);
        }
    }
}