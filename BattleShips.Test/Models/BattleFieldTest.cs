using BattleShips.Models;

namespace BattleShips.Test.Models;

public class BattleFieldTest
{

    /* 
    Test that a battle field can be created given a list of ships
    Test that RegisterHit works when there's a hit
    Test that RegisterHit works when there's a sink
    Test that RegisterHit works when there's no hit

    */


    [Fact]
    public void RegisterHit_ShouldRegisterASuccessfulHit_WriteCorrectInformationOnConsole()
    {
        var battleShip = new Battleship("battleShip");

        List<Ship> ships = new List<Ship> { battleShip };
        var battleField = new BattleField(ships);

        
    }
}
