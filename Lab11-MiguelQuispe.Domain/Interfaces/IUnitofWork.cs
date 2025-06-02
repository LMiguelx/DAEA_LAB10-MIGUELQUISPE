namespace Lab11_MiguelQuispe.Domain.Interfaces;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    IRoleRepository RoleRepository { get; }
    ITicketRepository TicketRepository { get; }


    Task<int> Complete();
    Task SaveAsync();
}