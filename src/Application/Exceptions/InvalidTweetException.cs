namespace Application.Exceptions;
public class InvalidTweetException : Exception
{
    public InvalidTweetException(string message) : base(message) { }
}
