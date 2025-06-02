using Lab11_MiguelQuispe.Domain.Interfaces;
using Lab11_MiguelQuispe.Domain.Models;
using Lab11_MiguelQuispe.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Lab11_MiguelQuispe.Infraestructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly TicketeraDb _context;

    public UserRepository(TicketeraDb context)
    {
        _context = context;
    }
    
    public void Add(User user)
    {
        _context.Users.Add(user);
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }
    
    public async Task<List<User>> GetAllWithRolesAsync()
    {
        return await _context.Users
            .Include(u => u.UserRoles)
            .ThenInclude(ur => ur.Role)
            .ToListAsync();
    }
    
    public IQueryable<User> GetAll()
    {
        return _context.Users.AsQueryable();
    }
    
    public void Delete(User entity)
    {
        _context.Users.Remove(entity);
    }

}