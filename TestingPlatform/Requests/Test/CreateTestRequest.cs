using System.ComponentModel.DataAnnotations;
using TestingPlatform.Domain.Enums;

namespace TestingPlatform.Requests.Test;

public class CreateTestRequest
{
    [Required]
    public string Title { get; set; }

    [Required]
    public string Description { get; set; }

    public bool IsRepeatable { get; set; }

    public TestType Type { get; set; }

    public DateTimeOffset PublishedAt { get; set; }

    public DateTimeOffset Deadline { get; set; }

    public int? DurationMinutes { get; set; }

    public bool IsPublic { get; set; }

    public int? PassingScore { get; set; }

    public int? MaxAttempts { get; set; }
}