using MediatR;
using AutoMapper;
using biblioteca_catalog.Domain.Interfaces;
using biblioteca_catalog.Domain.Exceptions;

namespace biblioteca_catalog.Application.Commands.Livro.UpdateLivro
{
    public class UpdateLivroCommandHandler : IRequestHandler<UpdateLivroCommand, Unit>
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IMapper _mapper;

        public UpdateLivroCommandHandler(ILivroRepository livroRepository, IMapper mapper)
        {
            _livroRepository = livroRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLivroCommand request, CancellationToken cancellationToken)
        {
            var livro = await _livroRepository.GetByIdAsync(request.Id, cancellationToken);

            if (livro == null)
            {
                throw new NotFoundException($"Livro com ID {request.Id} não encontrado.");
            }

            _mapper.Map(request, livro);

            _livroRepository.Update(livro);
            await _livroRepository.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
