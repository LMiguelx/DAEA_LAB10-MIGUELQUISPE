using Lab11_MiguelQuispe.Application.UsesCases.Tickets.Commands;
using Lab11_MiguelQuispe.Domain.Interfaces;
using Lab11_MiguelQuispe.Domain.Models;
using MediatR;

namespace Lab11_MiguelQuispe.Application.UsesCases.Tickets.Handlers;

public class AddTicketCommandHandler : IRequestHandler<AddTicketCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddTicketCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(AddTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = new Ticket
        {
            TicketId = Guid.NewGuid(),
            UserId = request.UserId,
            Title = request.Title,
            Description = request.Description,
            Status = "abierto", 
            CreatedAt = DateTime.UtcNow
        };

        await _unitOfWork.TicketRepository.AddAsync(ticket);
        await _unitOfWork.SaveAsync();

        return ticket.TicketId;
    }
}
