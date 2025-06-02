using AutoMapper;
using Lab11_MiguelQuispe.Application.DTOs;
using Lab11_MiguelQuispe.Domain.Interfaces;
using MediatR;

namespace Lab11_MiguelQuispe.Application.UsesCases.Roles.Queries;

public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, List<RoleDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetRolesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<RoleDto>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        var roles = await _unitOfWork.RoleRepository.GetAllAsync();

        return roles.Select(role => new RoleDto
        {
            RoleId = role.RoleId,
            RoleName = role.RoleName
        }).ToList();
    }
}