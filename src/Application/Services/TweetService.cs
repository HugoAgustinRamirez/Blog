using Application.DTOs.Tweet;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;
public class TweetService : ITweetService
{
    private readonly ITweetRepository _tweetRepository;
    private readonly IUserRepository _userRepository;

    public TweetService(ITweetRepository tweetRepository, IUserRepository userRepository)
    {
        _tweetRepository = tweetRepository;
        _userRepository = userRepository;
    }

    public async Task CreateTweetAsync(CreateTweetRequest request, int userId)
    {
        var tweet = new Tweet
        {
            Content = request.Content,
            UserId = userId,
            CreatedAt = DateTime.UtcNow
        };

        await _tweetRepository.AddAsync(tweet);
    }

    public async Task<IEnumerable<TweetResponse>> GetTimelineAsync(int userId, int page = 1, int pageSize = 10)
    {
        var tweets = await _tweetRepository.GetTimelineAsync(userId, page, pageSize);

        return tweets.Select(t => new TweetResponse(
            Id: t.Id,
            Content: t.Content,
            CreatedAt: t.CreatedAt,
            UserId: t.UserId
        ));
    }

    public async Task<TweetResponse?> GetTweetByIdAsync(int id)
    {
        var tweet = await _tweetRepository.GetByIdAsync(id);
        if (tweet == null) return null;

        return new TweetResponse(
            Id: tweet.Id,
            Content: tweet.Content,
            CreatedAt: tweet.CreatedAt,
            UserId: tweet.UserId
        );
    }
}