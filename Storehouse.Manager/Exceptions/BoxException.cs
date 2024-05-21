namespace Storehouse.Manager.Exceptions;

public class BoxException : StorehouseException
{
    internal BoxException(string? message) 
        : base(message)
    {
    }

    internal static BoxException MissingProductionOrExpiryDate()
    {
        string message = "Production date or Expiration date must be specified.";
        return new BoxException(message);
    }
}