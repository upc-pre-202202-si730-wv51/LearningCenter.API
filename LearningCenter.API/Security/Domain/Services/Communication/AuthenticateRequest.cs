using System.ComponentModel.DataAnnotations;

namespace LearningCenter.API.Security.Domain.Services.Communication;

public class AuthenticateRequest
{
    [Required]
    public string Username { get; set; }
    public string Password { get; set; }
}