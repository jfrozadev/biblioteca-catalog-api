csharp
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using biblioteca_catalog.Infrastructure.Data; // Assumindo o caminho do seu DbContext
using biblioteca_catalog.Application.DTOs; // Assumindo o caminho do seu DTO

namespace biblioteca_catalog.Application.Queries.Livro.GetAllLivros
{
    public class GetAllLivrosQueryHandler : IRequestHandler<GetAllLivrosQuery, List<LivroDto>>
    {
        private readonly ApplicationDbContext _context; // Use o nome do seu DbContext
        private readonly IMapper _mapper;

        public GetAllLivrosQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<LivroDto>> Handle(GetAllLivrosQuery request, CancellationToken cancellationToken)
        {
            var livros = await _context.Livros.ToListAsync(cancellationToken); // Use o nome da sua DbSet para Livro
            var livroDtos = _mapper.Map<List<LivroDto>>(livros);
            return livroDtos;
        }
    }
}