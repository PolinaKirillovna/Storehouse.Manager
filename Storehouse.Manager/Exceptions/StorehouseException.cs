namespace Storehouse.Manager.Exceptions;

public class StorehouseException : Exception
{
    private protected StorehouseException(string? message) 
        : base(message)
    {
    }
}