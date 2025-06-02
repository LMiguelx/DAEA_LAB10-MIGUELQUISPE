using MediatR;

namespace Lab11_MiguelQuispe.Application.UsesCases.UseRol.Command;

public class AssignUserRoleCommand : IRequest<Unit>
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
}