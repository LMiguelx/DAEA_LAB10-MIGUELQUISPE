using AutoMapper;
using Lab11_MiguelQuispe.Application.DTOs;
using Lab11_MiguelQuispe.Domain.Interfaces;
using MediatR;

namespace Lab11_MiguelQuispe.Application.UsesCases.Tickets.Queries;

public class GetAllTicketsQueryHandler : IRequestHandler<GetAllTicketsQuery, List<TicketDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllTicketsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<TicketDto>> Handle(GetAllTicketsQuery request, CancellationToken cancellationToken)
    {
        var tickets = await _unitOfWork.TicketRepository.GetAllAsync();
        return _mapper.Map<List<TicketDto>>(tickets);
    }
}