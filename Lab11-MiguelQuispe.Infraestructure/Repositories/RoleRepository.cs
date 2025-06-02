using Lab11_MiguelQuispe.Domain.Interfaces;
using Lab11_MiguelQuispe.Domain.Models;
using Lab11_MiguelQuispe.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Lab11_MiguelQuispe.Infraestructure.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly TicketeraDb _context;

    public RoleRepository (TicketeraDb context)
    {
        _context = context;
    }
    
    public async Task AddAsync(Role role)
    {
        await _context.Roles.AddAsync(role);
    }

    public void Add(Role role) => _context.Roles.Add(role);

    public void Update(Role role) => _context.Roles.Update(role);

    public void Delete(Role role) => _context.Roles.Remove(role);

    public async Task<Role?> GetByIdAsync(Guid id) => await _context.Roles.FindAsync(id);

    public async Task<IEnumerable<Role>> GetAllAsync() => await _context.Roles.ToListAsync();
}
