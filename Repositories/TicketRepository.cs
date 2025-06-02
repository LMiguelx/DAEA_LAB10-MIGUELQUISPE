using Lab11_MiguelQuispe.Domain.Interfaces;
using Lab11_MiguelQuispe.Domain.Models;
using Lab11_MiguelQuispe.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Lab11_MiguelQuispe.Infraestructure.Repositories;

public class TicketRepository : ITicketRepository
{
    private readonly TicketeraDb _context;

    public TicketRepository(TicketeraDb context)
    {
        _context = context;
    }

    public async Task AddAsync(Ticket ticket)
    {
        await _context.Tickets.AddAsync(ticket);
    }

    public async Task<Ticket?> GetByIdAsync(Guid ticketId)
    {
        return await _context.Tickets
            .Include(t => t.Responses)
            .FirstOrDefaultAsync(t => t.TicketId == ticketId);
    }

    public async Task<IEnumerable<Ticket>> GetAllAsync()
    {
        return await _context.Tickets
            .Include(t => t.Responses)
            .ToListAsync();
    }

    public void Update(Ticket ticket)
    {
        _context.Tickets.Update(ticket);
    }

    public void Delete(Ticket ticket)
    {
        _context.Tickets.Remove(ticket);
    }
}