using Lab11_MiguelQuispe.Domain.Interfaces;
using Lab11_MiguelQuispe.Infraestructure.Context;

namespace Lab11_MiguelQuispe.Infraestructure.Repositories.Unit;

public class UnitOfWork : IUnitOfWork
{
    private readonly TicketeraDb _context;
    public IUserRepository UserRepository { get; }
    public IRoleRepository RoleRepository { get; }
    public ITicketRepository TicketRepository { get; }


    public UnitOfWork(TicketeraDb context)
    {
        _context = context;
        UserRepository = new UserRepository(_context); 
        RoleRepository = new RoleRepository(_context);
        TicketRepository = new TicketRepository(_context);
    }

    public async Task<int> Complete()
    {
        return await _context.SaveChangesAsync();
    }
    
    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}