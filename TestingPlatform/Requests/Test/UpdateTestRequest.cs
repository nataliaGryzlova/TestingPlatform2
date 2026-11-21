using System.ComponentModel.DataAnnotations;
using TestingPlatform.Domain.Enums;

namespace TestingPlatform.Requests.Test;

public class UpdateTestRequest
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    public string Description { get; set; }

    public bool IsRepeatable { get; set; }

    public TestType Type { get; set; }

    public DateTime? PublishedAt { get; set; }

    public DateTime? Deadline { get; set; }

    public int? DurationMinutes { get; set; }

    public int? PassingScore { get; set; }

    public int? MaxAttempts { get; set; }

    public List<int> Students { get; set; } = new();

    public List<int> Projects { get; set; } = new();

    public List<int> Courses { get; set; } = new();

    public List<int> Groups { get; set; } = new();

    public List<int> Directions { get; set; } = new();
}