using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestingPlatform.Application.Dtos;
using TestingPlatform.Application.Interfaces;
using TestingPlatform.Requests.Test;
using TestingPlatform.Responses.Test;

namespace TestingPlatform.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestsController(ITestRepository testRepository, IMapper mapper) : ControllerBase
{
    [HttpGet("manage")]
    public async Task<IActionResult> GetAllTests(
        [FromQuery] bool? isPublic,
        [FromQuery] List<int>? groupIds = null,
        [FromQuery] List<int>? studentIds = null)
    {
        var tests = await testRepository.GetAllAsync(
            isPublic,
            groupIds ?? new List<int>(),
            studentIds ?? new List<int>());

        return Ok(mapper.Map<IEnumerable<TestResponse>>(tests));
    }

    [HttpGet("student/{studentId:int}")]
    public async Task<IActionResult> GetAllTestsForStudent(int studentId)
    {
        var tests = await testRepository.GetAllForStudent(studentId);

        return Ok(mapper.Map<IEnumerable<TestForStudentResponse>>(tests));
    }

    [HttpGet("{id:int}/manage")]
    public async Task<IActionResult> GetTestById(int id)
    {
        var test = await testRepository.GetByIdAsync(id);

        return Ok(mapper.Map<TestForManagerResponse>(test));
    }

    [HttpGet("recent")]
    public async Task<IActionResult> GetTopRecent([FromQuery] int count = 5)
    {
        var tests = await testRepository.GetTopRecentAsync(count);

        return Ok(mapper.Map<IEnumerable<TestResponse>>(tests));
    }

    [HttpPost]
    public async Task<IActionResult> CreateTest([FromBody] CreateTestRequest request)
    {
        var id = await testRepository.CreateAsync(mapper.Map<TestDto>(request));

        return StatusCode(StatusCodes.Status201Created, new { Id = id });
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateTest(int id, [FromBody] UpdateTestRequest request)
    {
        request.Id = id;

        await testRepository.UpdateAsync(mapper.Map<TestDto>(request));

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteTest(int id)
    {
        await testRepository.DeleteAsync(id);

        return NoContent();
    }

    [HttpGet("statistics/count-by-type")]
    public async Task<IActionResult> GetTestCountByType()
    {
        return Ok(await testRepository.GetTestCountByTypeAsync());
    }

    [HttpGet("statistics/courses")]
    public async Task<IActionResult> GetCourseStats()
    {
        return Ok(await testRepository.GetCourseStatsAsync());
    }

    [HttpGet("statistics/directions")]
    public async Task<IActionResult> GetDirectionAverages()
    {
        return Ok(await testRepository.GetDirectionAveragesAsync());
    }

    [HttpGet("statistics/timeline")]
    public async Task<IActionResult> GetTestTimeline()
    {
        return Ok(await testRepository.GetTestTimelineByPublicAsync());
    }

    [HttpGet("statistics/top-groups")]
    public async Task<IActionResult> GetTopGroups([FromQuery] int top = 10)
    {
        return Ok(await testRepository.GetTopGroupsByTestCountAsync(top));
    }
}