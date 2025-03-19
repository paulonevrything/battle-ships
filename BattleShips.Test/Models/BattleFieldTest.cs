using BattleShips.Models;
using BattleShips.Utils;
using Moq;

namespace BattleShips.Test.Models;

public class BattleFieldTest
{

    private Mock<Random> _mockRandom;
    private RandomGenerator _mockRandomGenerator;
    private StringWriter _stringWriter;

    public BattleFieldTest()
    {
        _mockRandom = new Mock<Random>();
        _mockRandom.Setup(rand => rand.Next(0, 5)).Returns(() => 7);
        _mockRandom.Setup(rand => rand.Next(0, 10)).Returns(() => 2);
        _mockRandom.Setup(rand => rand.Next(2)).Returns(() => 1);
        _mockRandomGenerator = new RandomGenerator(_mockRandom.Object);

        _stringWriter = new StringWriter();
        Console.SetOut(_stringWriter);
    }

    public void Dispose()
    {
        _stringWriter.Dispose();
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
    }


    [Fact]
    public void BattleField_ShouldPositionShipCorrectly_PositionsDestroyerCorrectly()
    {
        // Arrange
        var ship = new Destroyer("Destroyer");
        var ships = new List<Ship> { ship };

        // Act
        var battleField = new BattleField(ships, _mockRandomGenerator);

        // Assert
        var expectedPositions = new List<string> { "C1", "C2", "C3", "C4" };

        foreach (var pos in expectedPositions)
        {
            Assert.True(battleField.OccupiedPositions.ContainsKey(pos), $"Expected position {pos} is missing.");
        }

        Assert.Equal(4, battleField.OccupiedPositions.Count);
    }


    [Fact]
    public void RegisterHit_ShouldRegisterASuccessfulHit_WriteCorrectInformationOnConsole()
    {
        // Arrange
        var ship = new Destroyer("Destroyer");
        var ships = new List<Ship> { ship };

        // Act
        var battleField = new BattleField(ships, _mockRandomGenerator);
        battleField.RegisterHit("C2");

        // Assert

        Assert.Equal($"That's a successful shot!!! You hit a {ship.ShipType} called {ship.ShipName}" + Environment.NewLine, _stringWriter.ToString());
        Assert.Equal(3, battleField.OccupiedPositions["C2"].AvailableHits);
    }

    [Fact]
    public void RegisterHit_ShouldRegisterAnUnsuccessfulHit_WriteCorrectInformationOnConsole()
    {

        // Arrange
        var ship = new Destroyer("Destroyer");
        var ships = new List<Ship> { ship };

        // Act
        var battleField = new BattleField(ships, _mockRandomGenerator);
        battleField.RegisterHit("D6");

        // Assert
        Assert.Equal($"Unfortunately, no hit this time!!! Try again" + Environment.NewLine, _stringWriter.ToString());

    }

    [Fact]
    public void RegisterHit_ShouldRegisterASuccessfulSinking_WriteCorrectInformationOnConsole()
    {

        // Arrange
        var ship = new Destroyer("Destroyer");
        var ships = new List<Ship> { ship };

        // Act
        var battleField = new BattleField(ships, _mockRandomGenerator);
        battleField.OccupiedPositions["C2"].AvailableHits = 1;
        battleField.RegisterHit("C2");

        // Assert

        Assert.Equal($"That's a successful shot!!! You hit a {ship.ShipType} called {ship.ShipName}" + Environment.NewLine
         + $"Congratulations!!! You have successfully sunk a {ship.ShipType} called {ship.ShipName}" + Environment.NewLine, _stringWriter.ToString());

    }
}
