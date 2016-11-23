using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    static class Board
    {
        public enum CollisionInfo
        {
            AteFly,
            AteTail
        }

        public delegate void CollisionHandler(CollisionInfo collision);

        public static event CollisionHandler collided = delegate { };

        public static void CheckCollision()
        {
            foreach(GameObject gameObject in GameObjects)
            {
                bool anyCollision = GameObjects.Any(g => g.X == gameObject.X && g.Y == gameObject.Y && g.Name != gameObject.Name);
                if (anyCollision)
                {
                    string collidedObject = GameObjects.Find(g => g.X == gameObject.X && g.Y == gameObject.Y && g.Name != gameObject.Name).Name;
                    string collided = gameObject.Name;

                    CollisionInfo collision;

                    if ((collided.Contains("Snake") && !collidedObject.Contains("Snake")) || (collided.Contains("Fly") && !collidedObject.Contains("Fly")))
                        collision = CollisionInfo.AteFly;
                    else
                        collision = CollisionInfo.AteTail;

                    Board.collided(collision);
                    return;
                }
            }
        }

        public const int Width = 32;
        public const int Height = 18;
        
        public static List<GameObject> GameObjects = new List<GameObject>();

        public static void Print()
        {
            bool outOfBounds = GameObjects.Any(g => g.X >= Width || g.X < 0 || g.Y > Height || g.Y < 0);

            if (outOfBounds)
            {
                Game.Stop();
                return;
            }
                
 
            for (int y = 0; y <= Height - 1; y++)
            {
                char[] line = new char[Width];

                // Fill with emptiness
                for (int x = 0; x <= Width - 1; x++)
                    line[x] = ' ';

                // Fill with gameobejcts
                foreach (GameObject gameObject in GameObjects)
                    if (gameObject.Y == y)
                        line[gameObject.X] = gameObject.Graphic;

                Console.WriteLine(line);
            }
        }

        public static void Init()
        {
            GameObjects = new List<GameObject>();
        }
    }
}
