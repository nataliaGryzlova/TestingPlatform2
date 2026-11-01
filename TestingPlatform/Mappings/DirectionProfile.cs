using AutoMapper;
using TestingPlatform.Application.Dtos;
using TestingPlatform.Responses.Direction;
namespace TestingPlatform.Mappings;

public class DirectionProfile : Profile
{
    public DirectionProfile()
    {
        CreateMap<DirectionDto, DirectionResponse>();
    }
}