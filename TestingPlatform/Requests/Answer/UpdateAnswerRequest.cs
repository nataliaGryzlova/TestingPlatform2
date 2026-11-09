using System.ComponentModel.DataAnnotations;

namespace TestingPlatform.Requests.Answer;

public class UpdateAnswerRequest
{
    public int Id { get; set; }

    [Required]
    public string Text { get; set; }

    public bool IsCorrect { get; set; }
}