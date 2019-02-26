using System;
namespace Snake
{
    public class Apple : Food
    {
        //public int X { get; set; }
        //public int Y { get; set; }
        public int HowRotten { get; set; }
        public int MaxWidth { get; set; }
        public int MaxHeight { get; set; }

        public Apple(int width, int height) : base (width, height)
        {
            MakeFood(width, height);
            MaxWidth = width;
            MaxHeight = height;
        }
        public KeyDirection Move(KeyDirection direction)
        {
            switch (direction)
            {
                case KeyDirection.W:
                    if (this.Y > 1)
                    {
                        this.Y--;
                    }
                    break;
                case KeyDirection.S:
                    if (Y < MaxHeight-1)
                    {
                        this.Y++;
                    }
                    break;
                case KeyDirection.A:
                    if (X > 1)
                    {
                        this.X--;
                    }
                    break;
                case KeyDirection.D:
                    if (X < MaxWidth-1)
                    {
                        this.X++;
                    }
                    break;
            }
            return KeyDirection.None;
        }
    }
}
