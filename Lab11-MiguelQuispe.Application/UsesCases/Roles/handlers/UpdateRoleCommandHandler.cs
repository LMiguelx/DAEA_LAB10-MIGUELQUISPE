using Lab11_MiguelQuispe.Application.DTOs;
using Lab11_MiguelQuispe.Application.UsesCases.Roles.Commands;
using Lab11_MiguelQuispe.Domain.Interfaces;
using MediatR;

namespace Lab11_MiguelQuispe.Application.UsesCases.Roles.handlers;

public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, RoleDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRoleCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<RoleDto> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await _unitOfWork.RoleRepository.GetByIdAsync(request.RoleId);
        if (role == null)
            throw new Exception("Role not found");

        role.RoleName = request.RoleName;

        _unitOfWork.RoleRepository.Update(role);
        await _unitOfWork.SaveAsync();

        return new RoleDto
        {
            RoleId = role.RoleId,
            RoleName = role.RoleName
        };
    }
}