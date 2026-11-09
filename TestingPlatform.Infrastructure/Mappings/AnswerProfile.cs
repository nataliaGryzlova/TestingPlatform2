using AutoMapper;
using TestingPlatform.Application.Dtos;
using TestingPlatform.Domain.Models;

namespace TestingPlatform.Infrastructure.Mappings;

public class AnswerProfile : Profile
{
    public AnswerProfile()
    {
        CreateMap<Answer, AnswerDto>();

        CreateMap<AnswerDto, Answer>()
            .ForMember(d => d.Question, o => o.Ignore())
            .ForMember(d => d.UserSelectedOptions, o => o.Ignore());
    }
}