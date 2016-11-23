using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class GameObject
    {
        public int X;
        public int Y;
        public string Name;

        public char Graphic;

        public GameObject(int x, int y, char graphic, string name = "")
        {
            Graphic = graphic;
            X = x;
            Y = y;
            Name = name;
        }
    }
}
