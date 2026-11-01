using TestingPlatform.Responses.Course;
using TestingPlatform.Responses.Direction;
using TestingPlatform.Responses.Project;

namespace TestingPlatform.Responses.Group;

public class GroupResponse : BaseResponse
{
 
    public DirectionResponse Direction { get; set; }
   
    public CourseResponse Course { get; set; }
  
    public ProjectResponse Project { get; set; }
}