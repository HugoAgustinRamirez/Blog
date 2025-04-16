namespace Domain.Exceptions;
public class InvalidTweetException : DomainException
{
    public InvalidTweetException(string message) : base($"Invalid tweet: {message}") { }
}