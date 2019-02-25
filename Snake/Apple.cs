using System;
namespace Snake
{
    public class Apple
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int HowRotten {get; set;}

        public Apple()
        {
            var generator = new Random();
            this.X = generator.Next(1, 20);
            this.Y = generator.Next(1, 20);
        }
        public void Move(AppleKeyDirection direction)
        {
            switch (direction)
            {
                case AppleKeyDirection.W:
                    this.Y--;
                    break;
                case AppleKeyDirection.S:
                    this.Y++;
                    break;
                case AppleKeyDirection.A:
                    this.X--;
                    break;
                case AppleKeyDirection.D:
                    this.X++;
                    break;
            }
        }

        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(this.X, this.Y);
            Console.Write("*");
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}
