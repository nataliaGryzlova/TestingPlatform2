namespace TestingPlatform.Domain.Models;

public class Attempt
{
    public int Id { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime? SubmittedAt { get; set; }
    public int? Score { get; set; }

    public int TestId { get; set; }
    public Test Test { get; set; }

    public int StudentId { get; set; }
    public Student Student { get; set; }

    public List<UserAttemptAnswer> UserAttemptAnswers { get; set; }
}