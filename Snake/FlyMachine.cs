using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public static class FlyMachine
    {
        static GameObject fly = new GameObject(10, 10, 'X', "Fly");

        public static void SpawnFly()
        {
            Random rand = new Random();
            fly.X = rand.Next(0, Board.Width - 1);
            fly.Y = rand.Next(0, Board.Height - 1);
        }

        static void CheckCollision(Board.CollisionInfo collisionInfo)
        {
            if (collisionInfo == Board.CollisionInfo.AteFly)
                SpawnFly();
        }
        public static void Init()
        {
            SpawnFly();
            Board.GameObjects.Add(fly);

            Board.collided += CheckCollision;
        }
    }
}
