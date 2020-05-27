using System;
using System.Collections.Generic;
using System.Linq;
using SudokuSolver.workers;

namespace SudokuSolver.Strategies
{
    public class SudokuSolverEngine
    {
        private readonly SudokuBoardStateManager _sudokuBoardStateManager;
        private readonly SudokuMapper _sudokuMapper;

        public SudokuSolverEngine(SudokuBoardStateManager sudokuBoardStateManager, SudokuMapper sudokuMapper)
        {
            _sudokuBoardStateManager = sudokuBoardStateManager;
            _sudokuMapper = sudokuMapper;

        }

        public bool Solve(int[,] sudokuBoard) 
        {
            List<ISudokuStragedy> stragedies = new List<ISudokuStragedy>()
            {

            };

            var currentState = _sudokuBoardStateManager.GenerateState(sudokuBoard);
            var nextState = _sudokuBoardStateManager.GenerateState(stragedies.First().Solve(sudokuBoard));

            while (!_sudokuBoardStateManager.IsSolved(sudokuBoard) && currentState != nextState)
            {
                currentState = nextState;
                foreach (var strategy in stragedies)
                {
                    nextState = _sudokuBoardStateManager.GenerateState(strategy.Solve(sudokuBoard));
                }
            }
            return _sudokuBoardStateManager.IsSolved(sudokuBoard);
        }
    }
}
