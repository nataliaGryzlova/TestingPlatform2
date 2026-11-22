using AutoMapper;
using TestingPlatform.Application.Dtos;
using TestingPlatform.Requests.Question;
using TestingPlatform.Responses.Question;

namespace TestingPlatform.Mappings;

public class QuestionProfile : Profile
{
    public QuestionProfile()
    {
        CreateMap<QuestionDto, QuestionResponse>();
        CreateMap<CreateQuestionRequest, QuestionDto>();
        CreateMap<UpdateQuestionRequest, QuestionDto>();
    }
}