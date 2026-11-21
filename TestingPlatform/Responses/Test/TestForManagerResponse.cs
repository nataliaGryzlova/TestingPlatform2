using TestingPlatform.Responses.Course;
using TestingPlatform.Responses.Direction;
using TestingPlatform.Responses.Group;
using TestingPlatform.Responses.Project;
using TestingPlatform.Responses.Student;

namespace TestingPlatform.Responses.Test;

public class TestForManagerResponse : TestResponse
{
    public List<StudentForTestResponse> Students { get; set; }

    public List<ProjectResponse> Projects { get; set; }

    public List<CourseResponse> Courses { get; set; }

    public List<GroupResponse> Groups { get; set; }

    public List<DirectionResponse> Directions { get; set; }
}