using AutoMapper;
using biblioteca_catalog.Domain.Entities;
using biblioteca_catalog.Application.DTOs.EntityDtos;

namespace biblioteca_catalog.Application.Mappings
{
    public class LivroProfile : Profile
    {
        public LivroProfile()
        {
            CreateMap<Livro, LivroDto>();
            CreateMap<Autor, AutorDto>();
            CreateMap<Assunto, AssuntoDto>();
        }
    }
}