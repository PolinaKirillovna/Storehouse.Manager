using System.Collections.Generic;
using Storehouse.Manager.Exceptions;
using Storehouse.Manager.Models;
using Storehouse.Manager.Services;
using Xunit;

namespace Storehouse.Tests;

public class StorehouseServiceTest
{
    [Fact]
    public void SortPalletsByExpiryDateAndWeight_EmptyCollection_ShouldThrowException()
    {
        var service = new StorehouseService();
        var pallets = new List<Pallet>();
        
        Assert.Throws<StorehouseException>(() => service.SortPalletsByExpiryDateAndWeight(pallets));
    }

    [Fact]
    public void GetPalletsWithLongestExpiryBoxes_EmptyCollection_ShouldThrowException()
    {
        var service = new StorehouseService();
        var pallets = new List<Pallet>();
        
        Assert.Throws<StorehouseException>(() => service.GetPalletsWithLongestExpiryBoxes(pallets));
    }

}