using AutoMapper;
using Dal.Schemas;
using Domain.Dtos;

namespace Core.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ActorDto, Actor>().ReverseMap();
        CreateMap<ActorDetailsDto, Actor>().ReverseMap();
    }
}