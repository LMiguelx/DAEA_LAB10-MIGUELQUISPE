using Lab11_MiguelQuispe.Application.DTOs;
using MediatR;

namespace Lab11_MiguelQuispe.Application.UsesCases.Roles.Commands;

public class UpdateRoleCommand : IRequest<RoleDto>
{
    public Guid RoleId { get; set; }
    public string RoleName { get; set; } = string.Empty;
}