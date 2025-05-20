using AutoMapper;
using MediatR;
using biblioteca_catalog.Application.DTOs.EntityDtos;
using biblioteca_catalog.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace biblioteca_catalog.Application.Queries.Livro.GetAllLivros
{
    public class GetAllLivrosQueryHandler : IRequestHandler<GetAllLivrosQuery, List<LivroDto>>
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IMapper _mapper;

        public GetAllLivrosQueryHandler(ILivroRepository livroRepository, IMapper mapper)
        {
            _mapper = mapper;
            _livroRepository = livroRepository;
        }

        public async Task<List<LivroDto>> Handle(GetAllLivrosQuery request, CancellationToken cancellationToken)
        {
            var livros = await _livroRepository.GetAllAsync();
            return _mapper.Map<List<LivroDto>>(livros);
        }
    }
}
