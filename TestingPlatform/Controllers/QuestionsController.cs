using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestingPlatform.Application.Dtos;
using TestingPlatform.Application.Interfaces;
using TestingPlatform.Requests.Question;
using TestingPlatform.Responses.Question;

namespace TestingPlatform.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuestionsController(IQuestionRepository questionRepository, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllQuestions()
    {
        var questions = await questionRepository.GetAllAsync();

        return Ok(mapper.Map<IEnumerable<QuestionResponse>>(questions));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetQuestionById(int id)
    {
        var question = await questionRepository.GetByIdAsync(id);

        return Ok(mapper.Map<QuestionResponse>(question));
    }

    [HttpPost]
    public async Task<IActionResult> CreateQuestion([FromBody] CreateQuestionRequest request)
    {
        var id = await questionRepository.CreateAsync(mapper.Map<QuestionDto>(request));

        return StatusCode(StatusCodes.Status201Created, new { Id = id });
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateQuestion(int id, [FromBody] UpdateQuestionRequest request)
    {
        request.Id = id;

        await questionRepository.UpdateAsync(mapper.Map<QuestionDto>(request));

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteQuestion(int id)
    {
        await questionRepository.DeleteAsync(id);

        return NoContent();
    }
}