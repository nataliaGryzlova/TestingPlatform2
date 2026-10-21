using TestingPlatform2.Responses.Course;
using TestingPlatform2.Responses.Direction;
using TestingPlatform2.Responses.Project;

namespace practice.Responses.Group;

public class GroupResponse : BaseResponse
{
 
    public DirectionResponse Direction { get; set; }
   
    public CourseResponse Course { get; set; }
  
    public ProjectResponse Project { get; set; }
}