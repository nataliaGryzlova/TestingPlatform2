using AutoMapper;
using TestingPlatform.Application.Dtos;
using TestingPlatform2.Responses.Direction;
namespace practice.Mappings;

public class DirectionProfile : Profile
{
    public DirectionProfile()
    {
        CreateMap<DirectionDto, DirectionResponse>();
    }
}