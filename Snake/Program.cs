using System;

namespace Snake
{

    class Program
    {
        public static object WriteLock = new object();

        static void Main(string[] args)
        {

            //bool runGame = true;
            GameMode GameMode;
            while (true)
            {
                // Set true for two player game
                bool runGame = true;
                GameMode = ShowStartScreenAndChoosePlayers();
                if (GameMode == GameMode.Exit)
                {
                    runGame = false;
                    Console.Clear();
                    break;
                }
                while (runGame)
                {
                    var game = new Game(GameMode);
                    game.Countdown();
                    runGame = game.Run();
                }
            }



        }
       


        static public GameMode ShowStartScreenAndChoosePlayers()
        {
            var gameMode = GameMode.SinglePlayer;
            var position = 1;
            lock (Program.WriteLock)
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
                Console.WriteLine("> 1 Player");
                Console.SetCursorPosition(25, 14);
                Console.WriteLine("  2 Player");
                Console.SetCursorPosition(25, 16);
                Console.WriteLine("  Exit");

                while (true)
                {
                    var key = Console.ReadKey().Key;

                    if (key == ConsoleKey.DownArrow && position < 3)
                    {
                        position++;
                    }
                    if (key == ConsoleKey.UpArrow && position > 1)
                    {
                        position--;
                    }
                    if (key == ConsoleKey.Enter)
                    {
                        break;
                    }

                    if (position == 1)
                    {
                        gameMode = GameMode.SinglePlayer;
                        Console.SetCursorPosition(25, 12);
                        Console.WriteLine("> 1 Player");
                        Console.SetCursorPosition(25, 14);
                        Console.WriteLine("  2 Player");
                        Console.SetCursorPosition(25, 16);
                        Console.WriteLine("  Exit");
                    }
                    if (position == 2)
                    {
                        gameMode = GameMode.SnakeVsApple;
                        Console.SetCursorPosition(25, 12);
                        Console.WriteLine("  1 Player");
                        Console.SetCursorPosition(25, 14);
                        Console.WriteLine("> 2 Player");
                        Console.SetCursorPosition(25, 16);
                        Console.WriteLine("  Exit");

                    }
                    if (position == 3)
                    {
                        gameMode = GameMode.Exit;
                        Console.SetCursorPosition(25, 12);
                        Console.WriteLine("  1 Player");
                        Console.SetCursorPosition(25, 14);
                        Console.WriteLine("  2 Player");
                        Console.SetCursorPosition(25, 16);
                        Console.WriteLine("> Exit");
                    }
                }
                if (position == 2)
                {
                    gameMode = ChooseTwoPlayerMode();
                }
            }
            return gameMode;

        }
        static public GameMode ChooseTwoPlayerMode()
        {
            Console.SetCursorPosition(25, 12);
            Console.WriteLine("> Snake vs Snake");
            Console.SetCursorPosition(25, 14);
            Console.WriteLine("  Snake vs Apple");
            Console.SetCursorPosition(25, 16);
            Console.WriteLine("  Back");
            int position = 1;
            GameMode gameMode = GameMode.SnakeVsSnake;
            while (true)
            {
                var key = Console.ReadKey().Key;
                if (key == ConsoleKey.DownArrow && position < 3)
                {
                    position++;
                }
                if (key == ConsoleKey.UpArrow && position > 1)
                {
                    position--;
                }
                if (key == ConsoleKey.Enter)
                {
                    return gameMode;
                }
                if (position == 1)
                {
                    gameMode = GameMode.SnakeVsSnake;
                    Console.SetCursorPosition(25, 12);
                    Console.WriteLine("> Snake vs Snake");
                    Console.SetCursorPosition(25, 14);
                    Console.WriteLine("  Snake vs Apple");
                    Console.SetCursorPosition(25, 16);
                    Console.WriteLine("  Back");
                }
                if (position == 2)
                {
                    gameMode = GameMode.SnakeVsApple;
                    Console.SetCursorPosition(25, 12);
                    Console.WriteLine("  Snake vs Snake");
                    Console.SetCursorPosition(25, 14);
                    Console.WriteLine("> Snake vs Apple");
                    Console.SetCursorPosition(25, 16);
                    Console.WriteLine("  Back");

                }
                if (position == 3)
                {
                    gameMode = GameMode.SinglePlayer;
                    Console.SetCursorPosition(25, 12);
                    Console.WriteLine("  Snake vs Snake");
                    Console.SetCursorPosition(25, 14);
                    Console.WriteLine("  Snake vs Apple");
                    Console.SetCursorPosition(25, 16);
                    Console.WriteLine("> Back");

                }
            }
        }
    }
}