namespace BattleShips.Models;

public class Battleship : Ship
{
    public Battleship(string shipName)
    {
        NumberOfSquares = 5;
        ShipType = ShipType.Battleship;
        ShipName = shipName;
        AvailableHits = 5;
    }
}
