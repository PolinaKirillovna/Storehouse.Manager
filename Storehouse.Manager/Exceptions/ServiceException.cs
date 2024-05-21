namespace Storehouse.Manager.Exceptions;

public class ServiceException : StorehouseException
{
    internal ServiceException(string? message) 
        : base(message)
    {
    }

    internal static ServiceException EmptyPallet()
    {
        string message = "Pallet list is empty. Check your data.";
        return new ServiceException(message);
    }
}