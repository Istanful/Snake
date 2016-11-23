using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(Board.Width, Board.Height + 2);
            WaitForStart();
            Game.Start();
            EndScreen();
        }

        static void WaitForStart()
        {
            Console.WriteLine("Press any key to start...");
            Console.ReadKey();
        }

        static void EndScreen()
        {
            Console.Clear();
            Console.WriteLine("You finished with a score of {0}.", ScoreBoard.score);
            Console.ReadKey();
        }
    }
}
