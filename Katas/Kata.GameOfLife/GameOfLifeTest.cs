using AwesomeAssertions;

namespace Kata.GameOfLife;

public class GameOfLifeTest
{
    [Fact]
    public void Si_UnaCelulaVivaSinVecinas_Debe_Morir()
    {
        var board = new[,] { { true } };
        var game = new GameOfLife(board);
        
        game.NextGen();
        
        game.Board[0,0].Should().BeFalse();
    }
    
    [Fact]
    public void Si_UnaCelulaVivaConUnVecinas_Debe_Morir()
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
    
    [Fact]
    public void Si_UnaCelulaVivaConDosVecinas_Debe_Sobrevivir()
    {
        var board = new[,] 
        {
            { false, false, false },
            { true, true, true },
            { false, false, false }
        };
        var game = new GameOfLife(board);
        
        game.NextGen();
        
        game.Board[1,1].Should().BeTrue();
    }
}

public class GameOfLife(bool[,] board)
{
    public bool[,] Board { get; private set; } = board;
    
    public void NextGen()
    {
        var rows = Board.GetLength(0);
        var cols = Board.GetLength(1);
        var currentBoard = new bool[rows, cols];
        
        for (var row = 0; row < rows; row++)
        {
            for (var col = 0; col < cols; col++)
            {
                var neighborsCell = CountNeighborsCell(row, col);
                if (Board[row, col])
                    currentBoard[row, col] = neighborsCell > 1;
                else
                    Board[row, col] = false;
            }
        }

        Board = currentBoard;
    }
    
    private int CountNeighborsCell(int row, int col)
    {
        var count = 0;

        for (var rowFindNeighbor = -1; rowFindNeighbor <= 1; rowFindNeighbor++)
        {
            for (var colFindNeighbor = -1; colFindNeighbor <= 1; colFindNeighbor++)
            {
                if (rowFindNeighbor == 0 && colFindNeighbor == 0) 
                    continue;
                
                var positionRow = row + rowFindNeighbor;
                var positionCol = col + colFindNeighbor;
                
                if (positionRow < 0 || positionRow >= Board.GetLength(0) || positionCol < 0 || positionCol >= Board.GetLength(1))
                    continue; 
                
                if (Board[positionRow, positionCol]) 
                    count++;
            }
        }

        return count;
    }
};