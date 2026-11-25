using AutoMapper;
using TestingPlatform2.Requests.Attempt;
using TestingPlatform.Application.Dtos;

namespace TestingPlatform2.Mappings;

public class AttemptProfile : Profile
{
    public AttemptProfile()
    {
        CreateMap<CreateAttemptRequest, AttemptDto>();
        CreateMap<UpdateAttemptRequest, AttemptDto>();
    }
}