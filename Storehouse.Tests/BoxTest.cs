using System;
using Storehouse.Manager.Exceptions;
using Storehouse.Manager.Models;
using Xunit;

namespace Storehouse.Tests;

public class BoxTest
{
    [Fact]
    public void CreateBox_ValidParameters_ShouldSetProperties()
    {
        var productionDate = DateTime.Now;
        var weight = 10.0;
        
        var box = new Box(1, 1, 1, weight, productionDate);
        
        Assert.Equal(productionDate, box.ProductionDate);
        Assert.Equal(weight, box.Weight);
    }

    [Fact]
    public void CreateBox_WithNullProductionDateAndDefaultExpiryDate_ShouldThrowException()
    {
        Assert.Throws<BoxException>(() => new Box(1, 1, 1, 10.0, null, default(DateTime)));
    }
}