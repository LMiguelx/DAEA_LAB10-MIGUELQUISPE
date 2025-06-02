using Lab11_MiguelQuispe.Domain.Models;

namespace Lab11_MiguelQuispe.Domain.Interfaces;

public interface IRoleRepository
{
    Task<Role?> GetByIdAsync(Guid id);
    Task<IEnumerable<Role>> GetAllAsync();
    
    Task AddAsync(Role role);
    
    void Add(Role role);
    void Update(Role role);
    void Delete(Role role);
}
