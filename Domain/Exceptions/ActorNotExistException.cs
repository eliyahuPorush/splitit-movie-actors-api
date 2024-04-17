namespace Domain.Exceptions;

public class ActorNotExistException : Exception
{
    public ActorNotExistException(string message)
        :base(message) { }
    
    public ActorNotExistException(string message, Exception innerException)
        :base(message, innerException) { }
}