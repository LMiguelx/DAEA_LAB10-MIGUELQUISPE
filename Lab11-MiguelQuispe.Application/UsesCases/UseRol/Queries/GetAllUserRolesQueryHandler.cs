using AutoMapper;
using AutoMapper.QueryableExtensions;
using Lab11_MiguelQuispe.Application.DTOs;
using Lab11_MiguelQuispe.Infraestructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lab11_MiguelQuispe.Application.UsesCases.UseRol.Queries;

public class GetAllUserRolesQueryHandler : IRequestHandler<GetAllUserRolesQuery, List<UserRoleDto>>
{
    private readonly TicketeraDb _context;
    private readonly IMapper _mapper;

    public GetAllUserRolesQueryHandler(TicketeraDb context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<UserRoleDto>> Handle(GetAllUserRolesQuery request, CancellationToken cancellationToken)
    {
        return await _context.UserRoles
            .Include(ur => ur.User)
            .Include(ur => ur.Role)
            .ProjectTo<UserRoleDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}