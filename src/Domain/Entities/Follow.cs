using Domain.Exceptions;

namespace Domain.Entities;
public class Follow
{
    public int FollowerId { get; set; }
    public int FollowedId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public static void Validate(int followerId, int followedId)
    {
        if (followerId == followedId)
            throw new DomainException("A user cannot follow themselves.");
    }

    public User? Follower { get; set; }
    public User? Followed { get; set; }
}