using System;
using BattleShips.Models;

namespace BattleShips.Test.Models;

public class DestroyerTest
{
    [Fact]
    public void CreateDestroyer()
    {
        var destroyer = new Destroyer("destroyer1");

        Assert.Equal(ShipType.Destroyer, destroyer.ShipType);
        Assert.Equal(4, destroyer.NumberOfSquares);
        Assert.Equal("destroyer1", destroyer.ShipName);
    }
}
