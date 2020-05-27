using System;
namespace SudokuSolver.Strategies
{
    public interface ISudokuStragedy
    {
        int[,] Solve(int[,] sudokuBoard);
    }
}
