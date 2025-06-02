using MediatR;

namespace Lab11_MiguelQuispe.Application.UsesCases.Roles.Commands;

public class DeleteRoleCommand : IRequest<bool>
    {
        public Guid RoleId { get; }

        public DeleteRoleCommand(Guid roleId)
        {
            RoleId = roleId;
        }
    }

