using MediatR;

namespace Lab11_MiguelQuispe.Application.UsesCases.Users.Commands;

public record AddUserCommand : IRequest<Guid>
{
    public string Username { get; init; } = null!;
    public string PasswordHash { get; init; } = null!;
    public string? Email { get; init; }
}
