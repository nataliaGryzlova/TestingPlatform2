using AutoMapper;
using TestingPlatform.Application.Dtos;
using TestingPlatform.Requests.Test;
using TestingPlatform.Responses.Test;

namespace TestingPlatform.Mappings;

public class TestProfile : Profile
{
    public TestProfile()
    {
        CreateMap<TestDto, TestResponse>();
        CreateMap<TestDto, TestForManagerResponse>();
        CreateMap<TestDto, TestForStudentResponse>();

        CreateMap<CreateTestRequest, TestDto>()
            .ForMember(d => d.Id, m => m.Ignore())
            .ForMember(d => d.CreatedAt, m => m.Ignore())
            .ForMember(d => d.IsPublic, m => m.Ignore())
            .ForMember(d => d.Students, m => m.Ignore())
            .ForMember(d => d.Projects, m => m.Ignore())
            .ForMember(d => d.Courses, m => m.Ignore())
            .ForMember(d => d.Groups, m => m.Ignore())
            .ForMember(d => d.Directions, m => m.Ignore())
            .AfterMap((src, dest) =>
            {
                dest.Students = src.Students.Select(id => new StudentDto { Id = id }).ToList();
                dest.Projects = src.Projects.Select(id => new ProjectDto { Id = id }).ToList();
                dest.Courses = src.Courses.Select(id => new CourseDto { Id = id }).ToList();
                dest.Groups = src.Groups.Select(id => new GroupDto { Id = id }).ToList();
                dest.Directions = src.Directions.Select(id => new DirectionDto { Id = id }).ToList();
            });

        CreateMap<UpdateTestRequest, TestDto>()
            .ForMember(d => d.CreatedAt, m => m.Ignore())
            .ForMember(d => d.IsPublic, m => m.Ignore())
            .ForMember(d => d.Students, m => m.Ignore())
            .ForMember(d => d.Projects, m => m.Ignore())
            .ForMember(d => d.Courses, m => m.Ignore())
            .ForMember(d => d.Groups, m => m.Ignore())
            .ForMember(d => d.Directions, m => m.Ignore())
            .AfterMap((src, dest) =>
            {
                dest.Students = src.Students.Select(id => new StudentDto { Id = id }).ToList();
                dest.Projects = src.Projects.Select(id => new ProjectDto { Id = id }).ToList();
                dest.Courses = src.Courses.Select(id => new CourseDto { Id = id }).ToList();
                dest.Groups = src.Groups.Select(id => new GroupDto { Id = id }).ToList();
                dest.Directions = src.Directions.Select(id => new DirectionDto { Id = id }).ToList();
            });
    }
}