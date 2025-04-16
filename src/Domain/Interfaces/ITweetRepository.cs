using Domain.Entities;

namespace Domain.Interfaces;
public interface ITweetRepository
{
    Task<Tweet?> GetByIdAsync(int id);
    Task<List<Tweet>> GetTimelineAsync(int userId, int page = 1, int pageSize = 10);
    Task AddAsync(Tweet tweet);
    Task DeleteAsync(Tweet tweet);
}