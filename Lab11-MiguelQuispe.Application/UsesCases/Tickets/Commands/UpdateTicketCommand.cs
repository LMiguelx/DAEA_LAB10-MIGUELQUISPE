using MediatR;

namespace Lab11_MiguelQuispe.Application.UsesCases.Tickets.Commands;

public record UpdateTicketCommand : IRequest<bool>
{
    public Guid TicketId { get; init; }
    public string Title { get; init; } = null!;
    public string? Description { get; init; }
    public string Status { get; init; } = null!;
    public DateTime? ClosedAt { get; init; }
}
