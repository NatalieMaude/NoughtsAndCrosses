using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGamesLibrary
{
    public interface IGridGames
    {
        bool IsGameOver { get; }
        int CurrentPlayer { get; }
        char CurrentCellValue { get; }
        int NumRows { get; }
        string ErrorMessage { get; }

        void InitialiseGame();
        void InitialiseGrid();
        bool HasPlayerWon();
        bool PlayMove(int cell);
        char[] GetRowValues(int row);
        bool IsGridCellValid(int cell);
        bool IsGridCellEmpty(int cell);

    }
}
