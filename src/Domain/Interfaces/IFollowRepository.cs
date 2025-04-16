using Domain.Entities;

namespace Domain.Interfaces;
public interface IFollowRepository
{
    Task<Follow?> GetAsync(int followerId, int followedId);
    Task AddAsync(Follow follow);
    Task DeleteAsync(Follow follow);
    Task<List<User>> GetFollowedUsersAsync(int userId);
}