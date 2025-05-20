namespace biblioteca_catalog.Application.Commands.Autor.DeleteAutor
{
    public record DeleteAutorCommand(int CodAu) : IRequest<Unit>;
    {
}
}