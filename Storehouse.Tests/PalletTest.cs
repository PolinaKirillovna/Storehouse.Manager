using System;
using Storehouse.Manager.Exceptions;
using Storehouse.Manager.Models;

namespace Storehouse.Tests;
using Xunit;

public class PalletTest
{
    [Fact]
    public void AddBox_ValidBox_ShouldAddBoxToPallet()
    {
        var pallet = new Pallet(10, 10, 10);
        var box = new Box(1, 1, 1, 10.0, DateTime.Now);
        
        pallet.AddBox(box);
        
        Assert.Contains(box, pallet.Boxes);
    }

    [Fact]
    public void AddBox_BoxTooLarge_ShouldThrowException()
    {
        var pallet = new Pallet(1, 1, 1);
        var box = new Box(2, 2, 2, 10.0, DateTime.Now);
        
        Assert.Throws<PalletException>(() => pallet.AddBox(box));
    }
}