using Lab11_MiguelQuispe.Application.DTOs;
using MediatR;

namespace Lab11_MiguelQuispe.Application.UsesCases.UseRol.Queries;

public class GetAllUserRolesQuery : IRequest<List<UserRoleDto>> { }