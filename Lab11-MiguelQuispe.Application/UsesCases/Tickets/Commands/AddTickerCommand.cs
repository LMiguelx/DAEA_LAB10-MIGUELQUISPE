using MediatR;

namespace Lab11_MiguelQuispe.Application.UsesCases.Tickets.Commands;

public record AddTicketCommand : IRequest<Guid>
{
    public Guid UserId { get; init; }
    public string Title { get; init; } = null!;
    public string? Description { get; init; }
}