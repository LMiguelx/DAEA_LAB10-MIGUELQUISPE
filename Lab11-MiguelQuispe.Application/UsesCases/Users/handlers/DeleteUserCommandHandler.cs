using Lab11_MiguelQuispe.Application.UsesCases.Users.Commands;
using Lab11_MiguelQuispe.Domain.Interfaces;
using MediatR;

namespace Lab11_MiguelQuispe.Application.UsesCases.Users.handlers;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.UserRepository.GetByIdAsync(request.Id);
        if (user is null)
            return false;

        _unitOfWork.UserRepository.Delete(user);
        await _unitOfWork.SaveAsync();

        return true;
    }
}