namespace IRibeiroAPI.Infrastructure.Crosscutting.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string message) : base(message) { }
}