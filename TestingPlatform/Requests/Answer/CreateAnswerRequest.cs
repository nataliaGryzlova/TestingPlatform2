using System.ComponentModel.DataAnnotations;

namespace TestingPlatform.Requests.Answer;

public class CreateAnswerRequest
{
    [Required]
    public string Text { get; set; }

    public bool IsCorrect { get; set; }

    public int QuestionId { get; set; }
}