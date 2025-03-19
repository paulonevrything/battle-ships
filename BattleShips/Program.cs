using BattleShips.Models;
using BattleShips.Utils;



Console.WriteLine("Starting Battleship!");
Console.WriteLine("You can exit the game at any time by typing 'exit'");

int availableRounds = 15;

var battleShip = new Battleship("Battleship");
var destroyer1 = new Destroyer("Destroyer 1");
var destroyer2 = new Destroyer("Destroyer 2");

List<Ship> ships = new List<Ship> { battleShip, destroyer1, destroyer2 };

RandomGenerator rand = new RandomGenerator();
var battleField = new BattleField(ships, rand);

string shot = "";

foreach (KeyValuePair<string, Ship> entry in battleField.OccupiedPositions)
{
    Console.WriteLine("{0}, {1}", entry.Key, entry.Value.ShipType);
}


do
{
    do
    {
        Console.WriteLine("Enter the position of your shot in the format 'A5': ");
        shot = Console.ReadLine();

    } while (string.IsNullOrEmpty(shot));


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
    }

} while (availableRounds != 0);
