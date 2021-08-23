using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGamesLibrary
{
    public class NoughtsAndCrossesGame : IGridGames
    {
        private int TurnsPlayed;
        private readonly int NumCells = 9;
        private readonly char[] Grid;

        public bool IsGameOver { get; private set; }
        public int CurrentPlayer { get; private set; }
        public char CurrentCellValue { get; private set; }
        public int NumRows { get; private set; } = 3;
        public string ErrorMessage { get; private set; }

        public NoughtsAndCrossesGame()
        {
            Grid = new char[NumCells];
            InitialiseGame();
        }

        public void InitialiseGame()
        {
         
            InitialiseGrid();
            TurnsPlayed = 0;
            CurrentPlayer = 1;
            IsGameOver = false;
            CurrentCellValue = CellValue.XCell;
        }

        public void InitialiseGrid()
        {
            for (int i = 0; i < NumCells; i++)
            {
                Grid[i] = CellValue.Blank;                
            }
        }

        public char[] GetRowValues(int row)
        {
            char[] values = new char[3];

            //Check row is 1 to 3
            if ((row > 0) && (row <= NumRows))
            {
                //row 1 is index 0,1,2
                //row 2 is index 3,4,5
                //row 3 is index 6,7,8
                int gridIndex = ((row - 1) * 3);
                for (int i = 0; i < 3; i++)
                {
                    values[i] = Grid[gridIndex + i];
                }
            }
            return values;
        }

        public bool HasPlayerWon()
        {
            //check if on 5th play, can't win prior to this
            if (TurnsPlayed < 5)
                return false;
            //Check rows, columns and diagonals for win
            else if (CheckRowsForWin() || CheckColumnsForWin() || CheckDiagonalsForWin())
            {
                IsGameOver = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckRowsForWin()
        {
            //cell must not be blank and must match other cells in row
            if (((Grid[0] != CellValue.Blank) && (Grid[0] == Grid[1]) && (Grid[1] == Grid[2])) ||
                ((Grid[3] != CellValue.Blank) && (Grid[3] == Grid[4]) && (Grid[4] == Grid[5])) ||
                ((Grid[6] != CellValue.Blank) && (Grid[6] == Grid[7]) && (Grid[7] == Grid[8])))
            {
                return true;
            }
            else
                return false;
        }

        private bool CheckColumnsForWin()
        {
            //cell must not be blank and must match other cells in column
            if (((Grid[0] != CellValue.Blank) && (Grid[0] == Grid[3]) && (Grid[3] == Grid[6])) ||
                ((Grid[1] != CellValue.Blank) && (Grid[1] == Grid[4]) && (Grid[4] == Grid[7])) ||
                ((Grid[2] != CellValue.Blank) && (Grid[2] == Grid[5]) && (Grid[5] == Grid[8])))
            {
                return true;
            }
            else
                return false;
        }

        private bool CheckDiagonalsForWin()
        {
            //cell must not be blank and must match other cells in diagonal
            if (((Grid[0] != CellValue.Blank) && (Grid[0] == Grid[4]) && (Grid[4] == Grid[8])) ||
               ((Grid[2] != CellValue.Blank) && (Grid[2] == Grid[4]) && (Grid[4] == Grid[6])))
            {
                return true;
            }
            else
                return false;
        }

        public bool IsGridCellEmpty(int cell)
        {
            //grid is 0 based, user grid is 1 based
            if (Grid[cell - 1] == CellValue.Blank)
                return true;
            else
                return false;
        }

        public bool IsGridCellValid(int cell)
        {
            //grid is 0 based, user grid is 1 based
            //Valid cells in grid are 0 to 9
            if ((cell - 1 >= 0) && (cell - 1 < NumCells))
                return true;
            else
                return false;
        }

        public bool PlayMove(int cell)
        {
            //grid is zero based, user grid is 1 based
            bool result = CheckValidMove(cell);
            if (result)
            {
                try
                {
                    Grid[cell - 1] = CurrentCellValue;
                    TurnsPlayed += 1;

                    //if player has won or the number of turn played = the number of cells
                    //the game is over
                    if (HasPlayerWon() || (TurnsPlayed == NumCells))
                    {
                        IsGameOver = true;
                    }
                    else
                    {
                        SetNextPlayerCell();
                        //set next player number
                        CurrentPlayer = (CurrentPlayer == 1 ? CurrentPlayer = 2 : CurrentPlayer = 1);
                    }
                }
                catch (Exception e )
                {
                    throw new IndexOutOfRangeException(e.Message);
                }

            }
            return result;
        }

        private void SetNextPlayerCell()
        {
            //if even play X
            if (TurnsPlayed % 2 == 0)
            {
                CurrentCellValue = CellValue.XCell;
            }
            else
            {
                CurrentCellValue = CellValue.ZeroCell;
            }
        }


        //Check the grid cell is a valid cell number
        //Check the grid cell is empty
        private bool CheckValidMove(int cell)
        {
            ErrorMessage = "";
            bool isValid = IsGridCellValid(cell);

            if (isValid == false)
            {
                ErrorMessage = $"Selected cell must be between 1 and {NumCells}";
            }
            else
            {
                isValid = IsGridCellEmpty(cell);
                if (isValid == false)
                {
                    ErrorMessage = "Selected cell has aready been used";
                }
            }
            return isValid;
        }
    }
}
