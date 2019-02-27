using System;

namespace Snake
{

    class Program
    {

        static void Main(string[] args)
        {

            bool runGame = true;
            bool TwoPlayerGame;

            while (runGame)
            {
                  TwoPlayerGame = ShowStartScreenAndChoosePlayers();
                  // Set true for two player game
                  var game = new Game(TwoPlayerGame);
                  game.Countdown();
                game.Run();
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("GAME OVER");


        }
       


        static public bool ShowStartScreenAndChoosePlayers()
        {
            bool TwoPlayerGame = false;
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("   ▄████████ ███▄▄▄▄      ▄████████    ▄█   ▄█▄    ▄████████ ");
            Console.WriteLine("  ███    ███ ███▀▀▀██▄   ███    ███   ███ ▄███▀   ███    ███ ");
            Console.WriteLine("  ███    █▀  ███   ███   ███    ███   ███▐██▀     ███    █▀  ");
            Console.WriteLine("  ███        ███   ███   ███    ███  ▄█████▀     ▄███▄▄▄     ");
            Console.WriteLine("▀███████████ ███   ███ ▀███████████ ▀▀█████▄    ▀▀███▀▀▀     ");
            Console.WriteLine("         ███ ███   ███   ███    ███   ███▐██▄     ███    █▄  ");
            Console.WriteLine("   ▄█    ███ ███   ███   ███    ███   ███ ▀███▄   ███    ███ ");
            Console.WriteLine(" ▄████████▀   ▀█   █▀    ███    █▀    ███   ▀█▀   ██████████ ");
            Console.WriteLine("                                      ▀                      ");
            Console.SetCursorPosition(25, 12);
            Console.WriteLine("> 1 Player");
            Console.SetCursorPosition(27, 14);
            Console.WriteLine("2 Player");
            while (true)
            {
                var key = Console.ReadKey().Key;
                if (key == ConsoleKey.DownArrow)
                {
                    TwoPlayerGame = true;
                    Console.SetCursorPosition(25, 12);
                    Console.WriteLine("  1 Player");
                    Console.SetCursorPosition(25, 14);
                    Console.WriteLine("> 2 Player");
                }
                if (key == ConsoleKey.UpArrow)
                {
                    TwoPlayerGame = false;
                    Console.SetCursorPosition(25, 12);
                    Console.WriteLine("> 1 Player");
                    Console.SetCursorPosition(25, 14);
                    Console.WriteLine("  2 Player");
                }
                if (key == ConsoleKey.Enter)
                {
                    break;
                }
            }

            return TwoPlayerGame;

        }
    }
}


/*
 * Clear.Console()
                direction = GetKeyDirection();
                snake.Move(direction);


                food.Write();
                Snake.Write();
                board.Write();



                food.CheckForFood(Snake snake);
                if (CheckForCollision)
                {
                    Die();
                    break();
                }
*/