using MediatR;

namespace Lab11_MiguelQuispe.Application.UsesCases.Users.Commands;

public class UpdateUserCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
}