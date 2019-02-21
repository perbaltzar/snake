using System;
namespace Snake
{
    public class Food
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Food()
        {
            MakeFood();
        }
        public void MakeFood()
        {
            var generator = new Random();
            this.X = generator.Next(1, 20);
            this.Y = generator.Next(1, 20);
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
