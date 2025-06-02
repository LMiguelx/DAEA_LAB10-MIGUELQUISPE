using Lab11_MiguelQuispe.Application.UsesCases.Users.Commands;
using Lab11_MiguelQuispe.Domain.Interfaces;
using Lab11_MiguelQuispe.Domain.Models;
using MediatR;

namespace Lab11_MiguelQuispe.Application.UsesCases.Users.handlers;

internal sealed class AddUserCommandHandler : IRequestHandler<AddUserCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddUserCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            UserId = Guid.NewGuid(),
            Username = request.Username,
            PasswordHash = request.PasswordHash,
            Email = request.Email
        };

        _unitOfWork.UserRepository.Add(user);
        await _unitOfWork.Complete();

        return user.UserId;
    }
}