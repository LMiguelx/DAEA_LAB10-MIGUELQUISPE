using Lab11_MiguelQuispe.Domain.Models;

namespace Lab11_MiguelQuispe.Domain.Interfaces;

public interface ITicketRepository
{
    Task AddAsync(Ticket ticket);
    Task<Ticket?> GetByIdAsync(Guid ticketId);
    Task<IEnumerable<Ticket>> GetAllAsync();
    void Update(Ticket ticket);
    void Delete(Ticket ticket);
}