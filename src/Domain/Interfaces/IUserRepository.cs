using Domain.Entities;

namespace Domain.Interfaces;
public interface IUserRepository
{
    Task AddAsync(User user);
    Task<User?> GetByIdAsync(int id);
    Task<bool> ExistsAsync(int userId);
}
