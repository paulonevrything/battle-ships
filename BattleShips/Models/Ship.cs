namespace BattleShips.Models;

public class Ship
{
    public int NumberOfSquares { get; set; }
    public string ShipType { get; set; } = "";
    public string ShipName { get; set; } = "";
    public int AvailableHits { get; set; }
}
