using AutoMapper;
using biblioteca_catalog.Domain.Entities;
using biblioteca_catalog.Application.DTOs.EntityDtos;
using biblioteca_catalog.Application.Commands.Livro.CreateLivro;
using biblioteca_catalog.Application.Commands.Livro.UpdateLivro;

namespace biblioteca_catalog.Application.Mappings
{
    public class LivroProfile : Profile
    {
        public LivroProfile()
        {
            CreateMap<Livro, LivroDto>()
                .ForMember(dest => dest.Autores, opt => opt.MapFrom(src => src.Livros_Autores.Select(la => la.Autor.Nome)))
                .ForMember(dest => dest.Assuntos, opt => opt.MapFrom(src => src.Livros_Assuntos.Select(la => la.Assunto.Nome)));

            CreateMap<CreateLivroCommand, Livro>()
                .ForMember(dest => dest.Livros_Autores, opt => opt.MapFrom(src => src.AutoresIds.Select(id => new Livro_Autor { AutorId = id })))
                .ForMember(dest => dest.Livros_Assuntos, opt => opt.MapFrom(src => src.AssuntosIds.Select(id => new Livro_Assunto { AssuntoId = id })));

            CreateMap<UpdateLivroCommand, Livro>()
                .ForMember(dest => dest.Livros_Autores, opt => opt.MapFrom(src => src.AutoresIds.Select(id => new Livro_Autor { AutorId = id })))
                .ForMember(dest => dest.Livros_Assuntos, opt => opt.MapFrom(src => src.AssuntosIds.Select(id => new Livro_Assunto { AssuntoId = id })));
        }
    }
}
