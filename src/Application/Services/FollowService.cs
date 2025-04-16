using Application.DTOs.User;
using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class FollowService : IFollowService
{
    private readonly IFollowRepository _followRepository;
    private readonly IUserRepository _userRepository;

    public FollowService(
        IFollowRepository followRepository,
        IUserRepository userRepository)
    {
        _followRepository = followRepository;
        _userRepository = userRepository;
    }

    public async Task FollowUserAsync(int followerId, int followedId)
    {
        if (followerId == followedId)
            throw new InvalidOperationException("A user cannot follow themselves.");

        var followedUser = await _userRepository.GetByIdAsync(followedId);
        if (followedUser == null)
            throw new NotFoundException("User to follow not found.");

        var existingFollow = await _followRepository.GetAsync(followerId, followedId);
        if (existingFollow != null)
            throw new InvalidOperationException("Already following this user.");

        var follow = new Follow
        {
            FollowerId = followerId,
            FollowedId = followedId,
            CreatedAt = DateTime.UtcNow
        };

        await _followRepository.AddAsync(follow);
    }

    public async Task UnfollowUserAsync(int followerId, int followedId)
    {
        var follow = await _followRepository.GetAsync(followerId, followedId);
        if (follow == null)
            throw new NotFoundException("Follow relationship not found.");

        await _followRepository.DeleteAsync(follow);
    }

    public async Task<IEnumerable<UserResponse>> GetFollowedUsersAsync(int userId)
    {
        var followedUsers = await _followRepository.GetFollowedUsersAsync(userId);

        return followedUsers.Select(u => new UserResponse(
            Id: u.Id,
            Username: u.Username,
            Email: u.Email,
            CreatedAt: u.CreatedAt
        ));
    }
}