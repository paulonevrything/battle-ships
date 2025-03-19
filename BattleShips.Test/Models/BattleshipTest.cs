using System;
using BattleShips.Models;

namespace BattleShips.Test.Models;

public class BattleshipTest
{
    [Fact]
    public void CreateBattleship()
    {
        var battleship = new Battleship();

        Assert.Equal("Battleship", battleship.ShipName);
        Assert.Equal(5, battleship.NumberOfSquares);
    }
}
