using Domain.Exceptions;

namespace Domain.Entities;
public class Tweet
{
    public int Id { get; set; }
    private string _content = null!;

    public string Content
    {
        get => _content;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidTweetException("Tweet content cannot be empty.");
            if (value.Length > 280)
                throw new InvalidTweetException("Tweet exceeds 280 characters.");
            _content = value.Trim();
        }
    }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int UserId { get; set; }
    public User? User { get; set; }
}