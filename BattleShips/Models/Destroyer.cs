namespace BattleShips.Models;

public class Destroyer : Ship
{
    public string ShipName { get; set; } = "";

    public Destroyer(string shipName)
    {
        NumberOfSquares = 4;
        ShipType = "Destroyer";
        ShipName = shipName;
    }
}
