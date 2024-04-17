namespace Domain.Exceptions;

public class DuplicateRankException : Exception
{
    public DuplicateRankException(string message)
        : base(message) { }

    public DuplicateRankException(string message, Exception innerException)
        : base(message, innerException) { }
}