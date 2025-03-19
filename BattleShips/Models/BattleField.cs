using System;
using BattleShips.Utils;

namespace BattleShips.Models;

public class BattleField
{
    public Dictionary<string, Ship> OccupiedPositions = new Dictionary<string, Ship>();

    public BattleField(List<Ship> ships, RandomGenerator rand)
    {
        char[] xAxis = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
        int gridSize = 10;

        foreach (Ship ship in ships)
        {
            bool validPlacement = false;

            do
            {
                bool isHorizontal = rand.GetRandomBool();
                int startX, startY;

                if (isHorizontal)
                {
                    startX = rand.GetRandomInt(0, gridSize - ship.NumberOfSquares + 1);
                    startY = rand.GetRandomInt(0, gridSize);
                }
                else
                {
                    startX = rand.GetRandomInt(0, gridSize);
                    startY = rand.GetRandomInt(0, gridSize - ship.NumberOfSquares + 1);
                }

                for (int i = 0; i < ship.NumberOfSquares; i++)
                {
                    char xLabel = xAxis[startX + (isHorizontal ? i : 0)];
                    int yLabel = startY + (isHorizontal ? 0 : i) + 1;
                    string position = $"{xLabel}{yLabel}";

                    if (OccupiedPositions.ContainsKey(position))
                    {
                        break;
                    }

                    OccupiedPositions.Add(position, ship);
                    validPlacement = true;
                }


            } while (!validPlacement);
        }
    }

    public void RegisterHit(string shotLocation)
    {
        if (OccupiedPositions.ContainsKey(shotLocation))
        {

            var ship = OccupiedPositions[shotLocation];

            Console.WriteLine("That's a successful shot!!! You hit a {0} called {1}", ship.ShipType, ship.ShipName);
            ship.AvailableHits--;

            if (ship.AvailableHits == 0)
            {
                Console.WriteLine("Congratulations!!! You have successfully sunk a {0} called {1}", ship.ShipType, ship.ShipName);
            }
        }
        else
        {
            Console.WriteLine("Unfortunately, no hit this time!!! Try again");
        }
    }
}

