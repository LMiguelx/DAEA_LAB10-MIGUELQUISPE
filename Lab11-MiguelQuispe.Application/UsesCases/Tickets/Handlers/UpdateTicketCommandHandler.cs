using Lab11_MiguelQuispe.Application.UsesCases.Tickets.Commands;
using Lab11_MiguelQuispe.Domain.Interfaces;
using MediatR;

namespace Lab11_MiguelQuispe.Application.UsesCases.Tickets.Handlers;

public class UpdateTicketCommandHandler : IRequestHandler<UpdateTicketCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTicketCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = await _unitOfWork.TicketRepository.GetByIdAsync(request.TicketId);

        if (ticket == null)
            return false;

        ticket.Title = request.Title;
        ticket.Description = request.Description;
        ticket.Status = request.Status;
        ticket.ClosedAt = request.ClosedAt;

        _unitOfWork.TicketRepository.Update(ticket);
        await _unitOfWork.SaveAsync();

        return true;
    }
}