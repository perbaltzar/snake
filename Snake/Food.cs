using System;
namespace Snake
{
    public class Food
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Food(int width, int height)
        {
            MakeFood(width, height);
        }

        //--------------------------------------------
        // Making and placing a new food
        //--------------------------------------------
        public void MakeFood(int width, int height)
        {
            var generator = new Random();
            this.X = generator.Next(1, width);
            this.Y = generator.Next(1, height);
        }

        //--------------------------------------------
        // Drawing the graphics for the food
        //--------------------------------------------
        public void Draw()
        {
            lock (Program.WriteLock)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(this.X, this.Y);
                Console.Write("");
                Console.ForegroundColor = ConsoleColor.Black;
            }
        }
    }
}
