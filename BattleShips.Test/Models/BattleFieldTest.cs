using BattleShips.Models;
using BattleShips.Utils;
using Moq;

namespace BattleShips.Test.Models;

public class BattleFieldTest
{
    [Fact]
    public void BattleField_ShouldPositionShipCorrectly_PositionsDestroyerCorrectly()
    {
        // Arrange
        Mock<Random> mockRandom = new Mock<Random>();
        mockRandom.Setup(rand => rand.Next(0, 5)).Returns(() => 7);
        mockRandom.Setup(rand => rand.Next(0, 10)).Returns(() => 2);
        mockRandom.Setup(rand => rand.Next(2)).Returns(() => 1);
        var mockRandomGenerator = new RandomGenerator(mockRandom.Object);

        var ship = new Destroyer("Destroyer");
        var ships = new List<Ship> { ship };

        // Act
        var battleField = new BattleField(ships, mockRandomGenerator);

        // Assert: Ensure the ship is placed in expected positions
        var expectedPositions = new List<string> { "C1", "C2", "C3", "C4" }; // Based on mocked values

        foreach (var pos in expectedPositions)
        {
            Assert.True(battleField.OccupiedPositions.ContainsKey(pos), $"Expected position {pos} is missing.");
        }

        Assert.Equal(4, battleField.OccupiedPositions.Count);
    }


    /* 
    Test that RegisterHit works when there's a sink

    */

    [Fact]
    public void RegisterHit_ShouldRegisterASuccessfulHit_WriteCorrectInformationOnConsole()
    {
        // Arrange
        Mock<Random> mockRandom = new Mock<Random>();
        mockRandom.Setup(rand => rand.Next(0, 5)).Returns(() => 7);
        mockRandom.Setup(rand => rand.Next(0, 10)).Returns(() => 2);
        mockRandom.Setup(rand => rand.Next(2)).Returns(() => 1);
        var mockRandomGenerator = new RandomGenerator(mockRandom.Object);

        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Setup test data
        var ship = new Destroyer("Destroyer");
        var ships = new List<Ship> { ship };

        // Act
        var battleField = new BattleField(ships, mockRandomGenerator);
        battleField.RegisterHit("C2");

        // Assert

        Assert.Equal($"That's a successful shot!!! You hit a {ship.ShipType} called {ship.ShipName}" + Environment.NewLine, stringWriter.ToString());
        Assert.Equal(3, battleField.OccupiedPositions["C2"].AvailableHits);
    }

    [Fact]
    public void RegisterHit_ShouldRegisterAnUnsuccessfulHit_WriteCorrectInformationOnConsole()
    {
        // Arrange
        Mock<Random> mockRandom = new Mock<Random>();
        mockRandom.Setup(rand => rand.Next(0, 5)).Returns(() => 7);
        mockRandom.Setup(rand => rand.Next(0, 10)).Returns(() => 2);
        mockRandom.Setup(rand => rand.Next(2)).Returns(() => 1);
        var mockRandomGenerator = new RandomGenerator(mockRandom.Object);

        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Setup test data
        var ship = new Destroyer("Destroyer");
        var ships = new List<Ship> { ship };

        // Act
        var battleField = new BattleField(ships, mockRandomGenerator);
        battleField.RegisterHit("D6");

        // Assert

        Assert.Equal($"Unfortunately, no hit this time!!! Try again" + Environment.NewLine, stringWriter.ToString());

    }

    [Fact]
    public void RegisterHit_ShouldRegisterASuccessfulSinking_WriteCorrectInformationOnConsole()
    {
        // Arrange
        Mock<Random> mockRandom = new Mock<Random>();
        mockRandom.Setup(rand => rand.Next(0, 5)).Returns(() => 7);
        mockRandom.Setup(rand => rand.Next(0, 10)).Returns(() => 2);
        mockRandom.Setup(rand => rand.Next(2)).Returns(() => 1);
        var mockRandomGenerator = new RandomGenerator(mockRandom.Object);

        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Setup test data
        var ship = new Destroyer("Destroyer");
        var ships = new List<Ship> { ship };

        // Act
        var battleField = new BattleField(ships, mockRandomGenerator);
        battleField.OccupiedPositions["C2"].AvailableHits = 1;
        battleField.RegisterHit("C2");

        // Assert

        Assert.Equal($"That's a successful shot!!! You hit a {ship.ShipType} called {ship.ShipName}" + Environment.NewLine
         + $"Congratulations!!! You have successfully sunk a {ship.ShipType} called {ship.ShipName}" + Environment.NewLine, stringWriter.ToString());

    }
}