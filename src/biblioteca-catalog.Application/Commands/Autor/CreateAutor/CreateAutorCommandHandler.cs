using MediatR;
using biblioteca_catalog.Domain.Entities;
using biblioteca_catalog.Infrastructure.Data.Context; // Ajuste a namespace se necessário

namespace biblioteca_catalog.Application.Commands.Autor.CreateAutor
{
    public class CreateAutorCommandHandler : IRequestHandler<CreateAutorCommand, int>
    {
        private readonly biblioteca_catalogDbContext _context;

        public CreateAutorCommandHandler(biblioteca_catalogDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateAutorCommand request, CancellationToken cancellationToken)
        {
            var autor = new Autor
            {
                Nome = request.Nome
            };

            _context.Autores.Add(autor);
            await _context.SaveChangesAsync(cancellationToken);

            return autor.CodAu;
        }
    }
}