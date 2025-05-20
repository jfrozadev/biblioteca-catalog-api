using biblioteca_catalog.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace biblioteca_catalog.Application.Commands.Assunto.DeleteAssunto
{
    public class DeleteAssuntoCommandHandler : IRequestHandler<DeleteAssuntoCommand, Unit>
    {
        private readonly IAssuntoRepository _assuntoRepository;

        public DeleteAssuntoCommandHandler(IAssuntoRepository assuntoRepository)
        {
            _assuntoRepository = assuntoRepository;
        }

        public async Task<Unit> Handle(DeleteAssuntoCommand request, CancellationToken cancellationToken)
        {
            var assunto = await _assuntoRepository.GetByIdAsync(request.Id);

            if (assunto == null)
            {
                // Aqui você pode lançar uma exceção customizada ou retornar algum tipo de erro
                throw new ApplicationException($"Assunto com ID {request.Id} não encontrado.");
            }

            await _assuntoRepository.RemoveAsync(assunto);

            return Unit.Value;
        }
    }
}