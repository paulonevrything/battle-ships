using System;
using BattleShips.Models;

namespace BattleShips.Test.Models;

public class BattleshipTest
{
    [Fact]
    public void CreateBattleship()
    {
        var battleship = new Battleship("battleship1");

        Assert.Equal(ShipType.Battleship, battleship.ShipType);
        Assert.Equal(5, battleship.NumberOfSquares);
        Assert.Equal("battleship1", battleship.ShipName);
    }
}
