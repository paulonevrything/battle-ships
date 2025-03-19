namespace BattleShips.Models;

public class Battleship : Ship
{
    public string ShipName { get; set; } = "";
    public Battleship(string shipName)
    {
        NumberOfSquares = 5;
        ShipType = "Battleship";
        ShipName = shipName;
    }
}
