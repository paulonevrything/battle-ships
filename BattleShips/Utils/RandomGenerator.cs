using System;

namespace BattleShips.Utils;

public class RandomGenerator
{
    private readonly Random random;

    public RandomGenerator(Random? random = default)
    {
        this.random = random ?? new Random();
    }

    public int GetRandomInt(int min, int max)
    {
        return random.Next(min, max);
    }

    public bool GetRandomBool()
    {
        return random.Next(2) == 0;
    }
}
