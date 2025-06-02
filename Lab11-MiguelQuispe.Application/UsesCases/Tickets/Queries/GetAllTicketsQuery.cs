using Lab11_MiguelQuispe.Application.DTOs;
using MediatR;

namespace Lab11_MiguelQuispe.Application.UsesCases.Tickets.Queries;

public record GetAllTicketsQuery() : IRequest<List<TicketDto>>;