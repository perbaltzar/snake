using System;
namespace Snake
{
    public class Energy
    {
        public Energy()
        {
        }
        public void Draw (int height, int energy)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(3, height + 2);
            Console.WriteLine("Snake: 0%|                    |100%");
            Console.SetCursorPosition(13, height + 2);


            int NoOfBars = (energy/(150/20));
            Console.BackgroundColor = ConsoleColor.Green;
            for (int i = 0; i < NoOfBars; i++)
            {
                Console.SetCursorPosition(13+i, height + 2);
                Console.Write(" ");
            }
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Black;

        }
    }
}
