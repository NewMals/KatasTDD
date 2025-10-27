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
    
    [Fact]
    public void Si_UnaCelulaVivaConUnVecino_Debe_Morir()
    {
        var board = new[,] 
        {
            { false, false, false },
            { false, true, true },
            { false, false, false }
        };
        var game = new GameOfLife(board);
        
        game.NextGen();
        
        game.Board[1,1].Should().BeFalse();
    }
}

public class GameOfLife(bool[,] board)
{
    public bool[,] Board { get; private set; } = board;
    
    public void NextGen()
    {
        for (int row = 0; row < Board.GetLength(0); row++)
        {
            for (int colum = 0; colum < Board.GetLength(1); colum++)
            {
                if(Board[row, colum])
                    Board[row, colum] = false;
            }
        }
        
        
    }
};