using Lab11_MiguelQuispe.Application.DTOs;
using MediatR;

namespace Lab11_MiguelQuispe.Application.UsesCases.Roles.Queries;

public record GetRolesQuery : IRequest<List<RoleDto>>;