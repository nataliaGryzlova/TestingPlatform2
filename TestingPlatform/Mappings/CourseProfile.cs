using AutoMapper;
using TestingPlatform.Application.Dtos;
using TestingPlatform.Responses.Course;
namespace TestingPlatform.Mappings;

public class CourseProfile : Profile
{
    public CourseProfile()
    {
        CreateMap<CourseDto, CourseResponse>();
    }
}