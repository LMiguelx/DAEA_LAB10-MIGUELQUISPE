using Lab11_MiguelQuispe.Application.DTOs;
using Lab11_MiguelQuispe.Application.UsesCases.Roles.Commands;
using Lab11_MiguelQuispe.Domain.Interfaces;
using Lab11_MiguelQuispe.Domain.Models;
using MediatR;

namespace Lab11_MiguelQuispe.Application.UsesCases.Roles.handlers;

public class CreateRoleCommandHandler : IRequestHandler<AddRoleCommand, RoleDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateRoleCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<RoleDto> Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {
        var role = new Role()
        {
            RoleId = Guid.NewGuid(),
            RoleName = request.RoleName
        };

        await _unitOfWork.RoleRepository.AddAsync(role);
        await _unitOfWork.SaveAsync();

        return new RoleDto { RoleId = role.RoleId, RoleName = role.RoleName };
    }
}