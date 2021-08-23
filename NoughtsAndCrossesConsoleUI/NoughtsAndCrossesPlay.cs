using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GridGamesLibrary;

namespace NoughtsAndCrossesConsoleUI
{
    public class NoughtsAndCrossesPlay
    {
        private readonly IGridGames Game = new NoughtsAndCrossesGame();

        public void StartGame()
        {
            Console.WriteLine($"Cell Values 1 to 9");
            DrawGrid();
            PlayGame();
        }

        private void DrawGrid()
        {
            for(int i=1; i<= Game.NumRows; i++)
            {
                DrawRow(i);
            }
        }

        private void DrawRow(int row)
        {
            char[] rowValues = Game.GetRowValues(row);
            for(int i=0; i< rowValues.Length; i++)
            {
                Console.Write($"{rowValues[i]} ");
            }
            Console.WriteLine();
        }

        private void PlayGame()
        {
            //Keep playing until game is over
            while (!Game.IsGameOver)
            {
                GetPlayersChoice();
                DrawGrid();
            }

            //Check if player has won or its a draw
            if (Game.HasPlayerWon())
                Console.WriteLine($"Player {Game.CurrentPlayer} has Won");
            else
                Console.WriteLine($"Game Over - No Winner");
        }

        private void GetPlayersChoice()
        {
            string location = EnterNewMove();

            bool validCell;
            string errorMessage = "";
            do
            {
                //Check entry is a number
                validCell = int.TryParse(location, out int cellNum);
                if (validCell)
                {
                    //Play selected move
                    bool played = Game.PlayMove(cellNum);
                    //Check the played move is valid
                    if (played == false)
                    {
                        errorMessage = Game.ErrorMessage;
                        validCell = false;
                    }
                }
                else
                {
                    errorMessage = "Entry must be a number";
                }

                //if selected move is not valid then enter new move
                if (validCell == false)
                {
                    Console.WriteLine(errorMessage);
                    location = EnterNewMove();
                }

            }
            while (validCell == false);
        }

        private string EnterNewMove()
        {
            Console.WriteLine($"Player {Game.CurrentPlayer} Make Move ({Game.CurrentCellValue})");
            return Console.ReadLine();
        }
    }
}
