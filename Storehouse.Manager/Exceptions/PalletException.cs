using Storehouse.Manager.Models;

namespace Storehouse.Manager.Exceptions;

public class PalletException : StorehouseException
{
    internal PalletException(string? message) 
        : base(message)
    {
    }

    internal static PalletException BoxSizeError(Box box, Pallet pallet)
    {
        string message = $"Box dimensions exceed the pallet dimensions. Box sizes: width - {box.Width}, depth - {box.Depth}. " +
                         $"Pallet sizes: width - {pallet.Width}, depth - {pallet.Depth}.";
        return new PalletException(message);
    }
}