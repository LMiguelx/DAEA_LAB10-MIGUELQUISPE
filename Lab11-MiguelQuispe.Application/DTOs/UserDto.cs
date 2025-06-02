namespace Lab11_MiguelQuispe.Application.DTOs;

public class UserDto
{
    public Guid UserId { get; set; }
    public string Username { get; set; } = null!;
    public string? Email { get; set; }
}