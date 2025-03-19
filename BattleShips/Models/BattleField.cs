using System;

namespace BattleShips.Models;

public class BattleField
{
    public Dictionary<string, string> OccupiedPositions = new Dictionary<string, string>();

    public BattleField(List<Ship> ships)
    {
        char[] xAxis = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
        int gridSize = 10;
        Random rand = new Random();

        foreach (Ship ship in ships)
        {
            bool validPlacement = false;

            do
            {
                bool isHorizontal = rand.Next(2) == 0;
                int startX, startY;

                if (isHorizontal)
                {
                    startX = rand.Next(0, gridSize - ship.NumberOfSquares + 1);
                    startY = rand.Next(0, gridSize);
                }
                else
                {
                    startX = rand.Next(0, gridSize);
                    startY = rand.Next(0, gridSize - ship.NumberOfSquares + 1);
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

                    OccupiedPositions.Add(position, ship.ShipName);
                    validPlacement = true;
                }


            } while (!validPlacement);
        }
    }

}

