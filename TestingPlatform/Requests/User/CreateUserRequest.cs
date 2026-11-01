using System.ComponentModel.DataAnnotations;
using TestingPlatform.Domain.Enums;

namespace TestingPlatform.Requests.User;

public class CreateUserRequest
{
    [Required]
    public string Login { get; set; }

    [Required]
    public string Password { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

    [Required]
    public string FirstName { get; set; }

    public string? MiddleName { get; set; }

    [Required]
    public string LastName { get; set; }

    public UserRole Role { get; set; }
}