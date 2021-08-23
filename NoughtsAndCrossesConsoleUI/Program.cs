using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoughtsAndCrossesConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            NoughtsAndCrossesPlay Play = new NoughtsAndCrossesPlay();
            Play.StartGame();

            Console.ReadLine();
        }
    }
}
