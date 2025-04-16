using Domain.Exceptions;

namespace Domain.Entities;
public class User
{
    public int Id { get; set; }
    private string _username = null!;
    private string _email = null!;

    public string Username
    {
        get => _username;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainException("Username cannot be empty.");
            if (value.Length > 50)
                throw new DomainException("Username exceeds 50 characters.");
            _username = value.Trim();
        }
    }

    public string Email
    {
        get => _email;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainException("Email cannot be empty.");
            if (!value.Contains('@'))
                throw new DomainException("Invalid email format.");
            _email = value.Trim().ToLower();
        }
    }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public List<Tweet> Tweets { get; set; } = new();
    public List<Follow> Followers { get; set; } = new();
    public List<Follow> FollowedUsers { get; set; } = new();
}