using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Snake
{
    public static class InputManager
    {
        public delegate void InputHandler(ConsoleKey keyPressed);

        public static event InputHandler keyPressed = delegate {};

        public static void PressKey(ConsoleKey key)
        {
            keyPressed(key);
        }

        public static void StartKeyboardListener()
        {
            var thread = new Thread(() => {
                while (Game.playing)
                {
                    ConsoleKey key = System.Console.ReadKey(true).Key;
                    PressKey(key);
                }
            });

            thread.IsBackground = true;
            thread.Start();
        }
    }
}
