using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Snake
{ 
    public static class Game
    {
        public static bool playing;
        static Timer update = new Timer(100);

        public delegate void UpdateHandler(ElapsedEventArgs e = null);
        public delegate void GameEventsHandler();

        public static event UpdateHandler updated = delegate { };

        public static event GameEventsHandler gameStarted = delegate { };
        public static event GameEventsHandler gameStopped = delegate { };

        public static void Start()
        {
            Init();

            while (playing)
            {

            }
        }

        public static void Stop()
        {
            gameStopped();
            update.Stop();
            Console.Clear();
            playing = false;
        }

        public static void Update(Object source, ElapsedEventArgs e)
        {
            Console.Clear();
            ScoreBoard.Print();
            Board.Print();
            Board.CheckCollision();
            updated(e);
        }

        static void Init()
        {
            update.Elapsed += Update;
            update.Enabled = true;

            playing = true;
            Board.Init();
            SnakeController.Init();
            FlyMachine.Init();
            ScoreBoard.Init();
            InputManager.StartKeyboardListener();
        }
    }   
}
