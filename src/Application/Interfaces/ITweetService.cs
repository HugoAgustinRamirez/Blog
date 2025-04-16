using Application.DTOs.Tweet;

namespace Application.Interfaces;
public interface ITweetService
{
    Task CreateTweetAsync(CreateTweetRequest request, int userId);
    Task<IEnumerable<TweetResponse>> GetTimelineAsync(int userId, int page = 1, int pageSize = 10);
    Task<TweetResponse?> GetTweetByIdAsync(int id);
}
