using System;
namespace Snake
{
    public class TailPosition
    {
        public int X {get; set; }
        public int Y { get; set; }

        public TailPosition(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}

