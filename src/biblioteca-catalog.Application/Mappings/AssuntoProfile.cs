using AutoMapper;
using biblioteca_catalog.Application.DTOs.EntityDtos;
using biblioteca_catalog.Domain.Entities;

namespace biblioteca_catalog.Application.Mappings
{
    public class AssuntoProfile : Profile
    {
        public AssuntoProfile()
        {
            CreateMap<Assunto, AssuntoDto>().ReverseMap();
        }
    }
}