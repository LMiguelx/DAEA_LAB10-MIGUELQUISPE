using Lab11_MiguelQuispe.Application.UsesCases.UseRol.Command;
using Lab11_MiguelQuispe.Domain.Models;
using Lab11_MiguelQuispe.Infraestructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lab11_MiguelQuispe.Application.UsesCases.UseRol.Handler;

public class AssignUserRoleCommandHandler : IRequestHandler<AssignUserRoleCommand, Unit>
{
    private readonly TicketeraDb _context;

    public AssignUserRoleCommandHandler(TicketeraDb context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(AssignUserRoleCommand request, CancellationToken cancellationToken)
    {
        var exists = await _context.UserRoles.AnyAsync(ur =>
            ur.UserId == request.UserId && ur.RoleId == request.RoleId, cancellationToken);

        if (exists)
            throw new Exception("El usuario ya tiene asignado este rol.");

        var userRole = new UserRole
        {
            UserId = request.UserId,
            RoleId = request.RoleId,
            AssignedAt = DateTime.UtcNow
        };

        _context.UserRoles.Add(userRole);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}