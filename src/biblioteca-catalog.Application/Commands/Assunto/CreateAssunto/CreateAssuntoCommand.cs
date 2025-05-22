namespace biblioteca_catalog.Application.Commands.Assunto.CreateAssunto
{
    public class CreateAssuntoCommand : IRequest<int>
    {
        public string Nome { get; set; } = null!;
        public string Descricao { get; set; } = null!;
    }
}
