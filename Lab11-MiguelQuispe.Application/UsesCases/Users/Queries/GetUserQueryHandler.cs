using AutoMapper;
using Lab11_MiguelQuispe.Application.DTOs;
using Lab11_MiguelQuispe.Domain.Interfaces;
using MediatR;

namespace Lab11_MiguelQuispe.Application.UsesCases.Users.Queries;

internal sealed class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetUsersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _unitOfWork.UserRepository.GetAllWithRolesAsync();

        return users.Select(user => new UserDto
        {
            UserId = user.UserId,
            Username = user.Username,
            Email = user.Email,
        }).ToList();
    }

}