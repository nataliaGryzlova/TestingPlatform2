using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestingPlatform.Application.Dtos;
using TestingPlatform.Application.Interfaces;
using TestingPlatform.Domain.Models;
using TestingPlatform.Infrastructure.Data;

namespace TestingPlatform.Infrastructure.Repositories;

public class TestRepository(AppDbContext appDbContext, IMapper mapper) : ITestRepository
{
    public async Task<IEnumerable<TestDto>> GetAllAsync()
    {
        var tests = await appDbContext.Tests
            .AsNoTracking()
            .ToListAsync();

        return mapper.Map<IEnumerable<TestDto>>(tests);
    }

    public async Task<TestDto> GetByIdAsync(int id)
    {
        var test = await appDbContext.Tests
            .AsNoTracking()
            .FirstOrDefaultAsync(test => test.Id == id);

        if (test == null)
        {
            throw new Exception("Тест не найден.");
        }

        return mapper.Map<TestDto>(test);
    }

    public async Task<int> CreateAsync(TestDto testDto)
    {
        if (testDto.Deadline <= testDto.PublishedAt)
            throw new ArgumentException("Срок выполнения должен быть позже даты публикации.");

        var test = mapper.Map<Test>(testDto);
        test.CreatedAt = DateTimeOffset.UtcNow;

        await appDbContext.Tests.AddAsync(test);
        await appDbContext.SaveChangesAsync();

        return test.Id;
    }

    public async Task UpdateAsync(TestDto testDto)
    {
        var test = await appDbContext.Tests.FirstOrDefaultAsync(test => test.Id == testDto.Id);

        if (test == null)
        {
            throw new Exception("Тест не найден.");
        }

        if (testDto.Deadline <= testDto.PublishedAt)
            throw new ArgumentException("Срок выполнения должен быть позже даты публикации.");

        test.Title = testDto.Title;
        test.Description = testDto.Description;
        test.IsRepeatable = testDto.IsRepeatable;
        test.Type = testDto.Type;
        test.PublishedAt = testDto.PublishedAt;
        test.Deadline = testDto.Deadline;
        test.DurationMinutes = testDto.DurationMinutes;
        test.IsPublic = testDto.IsPublic;
        test.PassingScore = testDto.PassingScore;
        test.MaxAttempts = testDto.MaxAttempts;

        await appDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var test = await appDbContext.Tests.FirstOrDefaultAsync(test => test.Id == id);

        if (test == null)
        {
            throw new Exception("Тест не найден.");
        }

        appDbContext.Tests.Remove(test);
        await appDbContext.SaveChangesAsync();
    }
}