using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestingPlatform.Application.Dtos;
using TestingPlatform.Application.Interfaces;
using TestingPlatform.Requests.User;
using TestingPlatform.Responses.User;

namespace TestingPlatform.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserRepository userRepository, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await userRepository.GetAllAsync();

        return Ok(mapper.Map<IEnumerable<UserResponse>>(users));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await userRepository.GetByIdAsync(id);

        return Ok(mapper.Map<UserResponse>(user));
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest user)
    {
        var id = await userRepository.CreateAsync(mapper.Map<UserDto>(user));

        return StatusCode(StatusCodes.Status201Created, new { Id = id });
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest user)
    {
        await userRepository.UpdateAsync(mapper.Map<UserDto>(user));

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        await userRepository.DeleteAsync(id);

        return NoContent();
    }
}