using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestingPlatform.Application.Dtos;
using TestingPlatform.Application.Interfaces;
using TestingPlatform.Domain.Models;
using TestingPlatform.Infrastructure.Data;

namespace TestingPlatform.Infrastructure.Repositories;

public class UserRepository(AppDbContext appDbContext, IMapper mapper) : IUserRepository
{
    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        var users = await appDbContext.Users.AsNoTracking().ToListAsync();
        return mapper.Map<IEnumerable<UserDto>>(users);
    }

    public async Task<UserDto> GetByIdAsync(int id)
    {
        var user = await appDbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(user => user.Id == id);

        if (user == null)
        {
            throw new Exception("Пользователь не найден.");
        }

        return mapper.Map<UserDto>(user);
    }

    public async Task<int> CreateAsync(UserDto userDto)
    {
        if (await appDbContext.Users.AnyAsync(u => u.Login == userDto.Login))
            throw new ArgumentException($"Пользователь с логином {userDto.Login} уже существует.");

        if (await appDbContext.Users.AnyAsync(u => u.Email == userDto.Email))
            throw new ArgumentException($"Пользователь с email {userDto.Email} уже существует.");

        var user = mapper.Map<User>(userDto);
        user.PasswordHash = userDto.Password;

        await appDbContext.Users.AddAsync(user);
        await appDbContext.SaveChangesAsync();

        return user.Id;
    }

    public async Task UpdateAsync(UserDto userDto)
    {
        var user = await appDbContext.Users.FirstOrDefaultAsync(user => user.Id == userDto.Id);

        if (user == null)
        {
            throw new Exception("Пользователь не найден.");
        }

        if (await appDbContext.Users.AnyAsync(u => u.Login == userDto.Login && u.Id != userDto.Id))
            throw new ArgumentException($"Пользователь с логином {userDto.Login} уже существует.");

        if (await appDbContext.Users.AnyAsync(u => u.Email == userDto.Email && u.Id != userDto.Id))
            throw new ArgumentException($"Пользователь с email {userDto.Email} уже существует.");

        user.Login = userDto.Login;
        user.Email = userDto.Email;
        user.FirstName = userDto.FirstName;
        user.LastName = userDto.LastName;
        user.MiddleName = userDto.MiddleName;
        user.Role = userDto.Role;

        await appDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var user = await appDbContext.Users.FirstOrDefaultAsync(user => user.Id == id);

        if (user == null)
        {
            throw new Exception("Пользователь не найден.");
        }

        appDbContext.Users.Remove(user);
        await appDbContext.SaveChangesAsync();
    }
}