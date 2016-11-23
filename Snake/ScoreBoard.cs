using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public static class ScoreBoard
    {
        public static int score = 0;

        public static ConsoleColor scoreBoardColor = ConsoleColor.Blue;
        static ConsoleColor defaultColor = Console.BackgroundColor;

        public static void Print()
        {
            Console.BackgroundColor = scoreBoardColor;
            Console.WriteLine("{0, 5}", score);
            Console.BackgroundColor = defaultColor;
        }

        public static void Init()
        {
            Board.collided += increaseScore;
        }

        static void increaseScore(Board.CollisionInfo collisionInfo)
        {
            if (collisionInfo == Board.CollisionInfo.AteFly)
                score++;
        }
    }
}
