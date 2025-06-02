using Lab11_MiguelQuispe.Application.DTOs;
using MediatR;

namespace Lab11_MiguelQuispe.Application.UsesCases.Roles.Commands;

public class AddRoleCommand : IRequest<RoleDto>
{
    public string RoleName { get; set; }
}
