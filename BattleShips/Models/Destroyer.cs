namespace BattleShips.Models;

public class Destroyer : Ship
{
    public Destroyer(string shipName)
    {
        NumberOfSquares = 4;
        ShipType = "Destroyer";
        ShipName = shipName;
        AvailableHits = 4;
    }
}
