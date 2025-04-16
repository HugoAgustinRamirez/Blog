using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class TweetRepository(AppDbContext context) : ITweetRepository
{
    public async Task<Tweet?> GetByIdAsync(int id)
        => await context.Tweets.Include(t => t.User).FirstOrDefaultAsync(t => t.Id == id);

    public async Task<List<Tweet>> GetTimelineAsync(int userId, int page = 1, int pageSize = 10)
    {
        return await context.Tweets
            .Where(t => context.Follows
                .Where(f => f.FollowerId == userId)
                .Select(f => f.FollowedId)
                .Contains(t.UserId))
            .OrderByDescending(t => t.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Include(t => t.User)
            .ToListAsync();
    }

    public async Task AddAsync(Tweet tweet) => await context.Tweets.AddAsync(tweet);
    public async Task DeleteAsync(Tweet tweet)
    {
        context.Tweets.Remove(tweet);
        await context.SaveChangesAsync();
    }
}