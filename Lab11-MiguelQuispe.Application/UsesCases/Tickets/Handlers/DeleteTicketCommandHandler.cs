using Lab11_MiguelQuispe.Application.UsesCases.Tickets.Commands;
using Lab11_MiguelQuispe.Domain.Interfaces;
using MediatR;

namespace Lab11_MiguelQuispe.Application.UsesCases.Tickets.Handlers;

public class DeleteTicketCommandHandler : IRequestHandler<DeleteTicketCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTicketCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = await _unitOfWork.TicketRepository.GetByIdAsync(request.TicketId);

        if (ticket == null)
            return false;

        _unitOfWork.TicketRepository.Delete(ticket);
        await _unitOfWork.SaveAsync();

        return true;
    }
}