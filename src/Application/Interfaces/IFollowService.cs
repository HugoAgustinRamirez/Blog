using Application.DTOs.User;

namespace Application.Interfaces;
public interface IFollowService
{
    Task FollowUserAsync(int followerId, int followedId);
    Task UnfollowUserAsync(int followerId, int followedId);
    Task<IEnumerable<UserResponse>> GetFollowedUsersAsync(int userId);
}
