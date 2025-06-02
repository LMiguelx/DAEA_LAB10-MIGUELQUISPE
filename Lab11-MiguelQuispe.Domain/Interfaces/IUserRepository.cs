using Lab11_MiguelQuispe.Domain.Models;

namespace Lab11_MiguelQuispe.Domain.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id);
    Task<IEnumerable<User>> GetAllAsync();
    IQueryable<User> GetAll();
    
    Task<List<User>> GetAllWithRolesAsync();

    void Delete(User entity);
    
    void Add(User user);
    
}