namespace Application.DTOs.Tweet;
public record TweetResponse(
    int Id,
    string Content,
    DateTime CreatedAt,
    int UserId
);
