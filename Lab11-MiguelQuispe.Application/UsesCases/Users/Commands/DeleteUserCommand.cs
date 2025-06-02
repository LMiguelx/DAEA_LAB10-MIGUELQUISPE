using MediatR;

namespace Lab11_MiguelQuispe.Application.UsesCases.Users.Commands;

public record DeleteUserCommand(Guid Id) : IRequest<bool>;