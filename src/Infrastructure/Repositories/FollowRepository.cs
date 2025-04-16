using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class FollowRepository(AppDbContext context) : IFollowRepository
{
    public async Task<Follow?> GetAsync(int followerId, int followedId)
        => await context.Follows
            .FirstOrDefaultAsync(f => f.FollowerId == followerId && f.FollowedId == followedId);

    public async Task AddAsync(Follow follow) => await context.Follows.AddAsync(follow);
    public async Task DeleteAsync(Follow follow)
    {
        context.Follows.Remove(follow);
        await context.SaveChangesAsync();
    }

    public async Task<List<User>> GetFollowedUsersAsync(int userId)
        => await context.Follows
            .Where(f => f.FollowerId == userId)
            .Select(f => f.Followed!)
            .ToListAsync();
}