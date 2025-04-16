using Domain.Entities;

namespace Infrastructure.Persistence.Seed;
public static class SeedData
{
    public static void Initialize(AppDbContext context)
    {
        if (context.Users.Any()) return;

        var users = new List<User>
        {
            new() { Id = 1, Username = "user1", Email = "user1@example.com" },
            new() { Id = 2, Username = "user2", Email = "user2@example.com" }
        };

        var tweets = new List<Tweet>
        {
            new() { Id = 1, Content = "First tweet!", UserId = 1 },
            new() { Id = 2, Content = "Hello world!", UserId = 2 }
        };

        var follows = new List<Follow>
        {
            new() { FollowerId = 1, FollowedId = 2 }
        };

        context.Users.AddRange(users);
        context.Tweets.AddRange(tweets);
        context.Follows.AddRange(follows);
        context.SaveChanges();
    }
}
