using AwesomeAssertions;

namespace Kata.GameOfLife;

public class GameOfLifeTest
{
    [Fact]
    public void Si_UnaCelulaVivaSinVecinos_Debe_Morir()
    {
        var board = new[,] { { true } };
        var game = new GameOfLife(board);
        
        game.NextGen();
        
        game.Board[0,0].Should().BeFalse();
    }
}

public class GameOfLife
{
    public bool[,] Board { get; private set; }
    
    public GameOfLife(bool[,] board)
    {
        Board = board;
    }


    public void NextGen()
    {
        Board[0, 0] = false;
    }
};