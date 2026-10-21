using AutoMapper;
using TestingPlatform.Application.Dtos;
using TestingPlatform2.Responses.Course;
namespace practice.Mappings;

public class CourseProfile : Profile
{
    public CourseProfile()
    {
        CreateMap<CourseDto, CourseResponse>();
    }
}