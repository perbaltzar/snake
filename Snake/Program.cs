using System;

namespace Snake
{

    class Program
    {

        static void Main(string[] args)
        {
            // This is what i Want it to look like. 
            bool runGame = true;
            bool TwoPlayerGame;

            while (runGame)
            {
                  TwoPlayerGame = ShowStartScreen();
                  // Set true for two player game
                  var game = new Game(TwoPlayerGame);
                  game.Countdown();
                  game.Run();
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("GAME OVER");
            //ShowScore(score);

        }
       


        static public bool ShowStartScreen()
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