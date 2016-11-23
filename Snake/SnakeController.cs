using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Threading;

namespace Snake
{
    public static class SnakeController
    {
        static direction currentDirection = direction.down;
        static List<GameObject> body;

        enum direction
        {
            left = 1,
            up = 2, 
            right = 3,
            down = 4
        }

        public static void Movement(ElapsedEventArgs e)
        {
            body.MoveTail();

            switch (currentDirection)
            {
                case direction.down:
                    body[0].Y += 1;
                    break;
                case direction.up:
                    body[0].Y -= 1;
                    break;
                case direction.left:
                    body[0].X -= 1;
                    break;
                case direction.right:
                    body[0].X += 1;
                    break;
            }
        }

        public static void Init()
        {
            body = new List<GameObject>();
            Game.updated += Movement;
            Board.collided += CheckCollision;
            InputManager.keyPressed += updateDirection;
            Grow();
        }

        static void MoveTail(this List<GameObject> body)
        {
            for (int i = body.Count - 1; i >= 1; i--)
            {
                body[i].Y = body[i-1].Y;
                body[i].X = body[i-1].X;
            }
        }

        static void CheckCollision(Board.CollisionInfo collisionInfo)
        {
            if (collisionInfo == Board.CollisionInfo.AteFly)
                Grow();
            else
                Game.Stop();  
        }

        static void Grow()
        {
            GameObject bodyPart;

            if (body.Count >= 1)
            {
                int index = body.Count - 1;
                bodyPart = new GameObject(body[index].X - 1, body[index].Y - 1, 'O', "Snake" + body.Count);
                body.Add(bodyPart);
                Board.GameObjects.Add(bodyPart);
            }
            else
            {
                bodyPart = new GameObject(10, 10, 'O', "Snake" + body.Count);
                body.Add(bodyPart);
                Board.GameObjects.Add(bodyPart);
            }

            Board.GameObjects.Add(body[0]);
        }

        static void updateDirection(ConsoleKey key)
        {
            direction oldDirection = currentDirection;

            switch (key)
            {
                case ConsoleKey.DownArrow:
                    currentDirection = direction.down;
                    break;
                case ConsoleKey.UpArrow:
                    currentDirection = direction.up;
                    break;
                case ConsoleKey.LeftArrow:
                    currentDirection = direction.left;
                    break;
                case ConsoleKey.RightArrow:
                    currentDirection = direction.right;
                    break;
            }

            // If opposite direction revert
            currentDirection = (int)currentDirection == oldDirection.oppositeDirection() ? oldDirection : currentDirection;
        }

        static int oppositeDirection(this direction direction)
        {
            int oppositeDirection = ((int)direction + 2) % 4;
            return oppositeDirection != 0 ? oppositeDirection : 4;
        }
    }
}
