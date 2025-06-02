using MediatR;

namespace Lab11_MiguelQuispe.Application.UsesCases.Tickets.Commands;

public record DeleteTicketCommand(Guid TicketId) : IRequest<bool>;