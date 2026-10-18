using Microsoft.AspNetCore.Mvc;
using TestingPlatform.Domain.Models;
using TestingPlatform.Infrastructure.Data;
using TestingPlatform.Infrastructure.Repositories;

namespace TestingPlatform.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GroupsController : ControllerBase
{
    private readonly GroupRepository _repository;

    public GroupsController(AppDbContext appDbContext)
    {
        _repository = new GroupRepository(appDbContext);
    }

    [HttpGet]
    public IActionResult GetAllGroups()
    {
        var groups = _repository.GetAll();
        return Ok(groups);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetGroupById(int id)
    {
        var group = _repository.GetById(id);

        return Ok(group);
    }

    [HttpPost]
    public IActionResult CreateGroup([FromBody] Group group)
    {
        var id = _repository.Create(group);

        return StatusCode(StatusCodes.Status201Created, new { Id = id });
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateGroup([FromBody] Group group)
    {
        _repository.Update(group);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteGroup(int id)
    {
        _repository.Delete(id);

        return NoContent();
    }
}