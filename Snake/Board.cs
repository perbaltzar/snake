using System;
namespace Snake
{
    public class Board
    {
        public int Lenght { get; }
        public int Height { get; }
        public Board(int lenght, int height)
        {
            this.Lenght = lenght;
            this.Height = height;
        }
        public void Draw()
        {
            lock (Program.WriteLock)
            {
                //Top Row
                for (var i = 0; i <= this.Lenght; i++)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.SetCursorPosition(i, 0);
                    Console.Write(" ");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                //Left Row
                for (var j = 1; j <= this.Height; j++)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.SetCursorPosition(0, j);
                    Console.Write(" ");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                //Right Row
                for (var k = 1; k <= this.Height; k++)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.SetCursorPosition(this.Lenght, k);
                    Console.Write(" ");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                //Bottom Row
                for (var l = 0; l <= this.Lenght; l++)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.SetCursorPosition(l, this.Height);
                    Console.Write(" ");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }
        }
    }
}
