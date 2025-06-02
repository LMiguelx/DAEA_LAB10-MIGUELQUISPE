using Lab11_MiguelQuispe.Application.DTOs;
using MediatR;

namespace Lab11_MiguelQuispe.Application.UsesCases.Users.Queries;

public record GetUsersQuery : IRequest<List<UserDto>>;