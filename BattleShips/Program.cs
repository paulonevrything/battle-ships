using BattleShips.Models;



Console.WriteLine("Starting Battleship!");

int availableRounds = 15;

var battleShip = new Battleship("battleShip");
var destroyer1 = new Destroyer("destroyer1");
var destroyer2 = new Destroyer("destroyer2");

List<Ship> ships = new List<Ship> { battleShip, destroyer1, destroyer2 };

var battleField = new BattleField(ships);

string shot;

foreach (KeyValuePair<string, Ship> entry in battleField.OccupiedPositions)
{
    Console.WriteLine("{0}, {1}", entry.Key, entry.Value.ShipType);
}


do
{
    Console.WriteLine("Enter the position of your shot: ");
    shot = Console.ReadLine();

    if (shot.ToLower().Equals("exit"))
    {
        break;
    }

    battleField.RegisterHit(shot);
    availableRounds--;

    if (availableRounds == 0)
    {
        Console.WriteLine();
        Console.WriteLine("Game Over!!!");
        Console.WriteLine("Your Score is {0}!!!", battleField.score);
    }

} while (availableRounds != 0);
