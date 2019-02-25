using System;

namespace Snake
{

    class Program
    {

        static void Main(string[] args)
        {
            // This is what i Want it to look like. 
            bool runGame = true;
            //var game = new Game();

            while (runGame)
            {
                  ShowStartScreen();
                  var game = new Game();
                  game.Countdown();
                  game.Run();
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("GAME OVER");
            //ShowScore(score);

        }
       


        static public void ShowStartScreen()
        {
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
            Console.WriteLine("Press any key!");
            Console.ReadKey();

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