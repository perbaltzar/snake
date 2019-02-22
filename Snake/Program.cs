using System;
using System.Threading;

namespace Snake
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Black;
           
            // Creating Sprits for the game
            var food = new Food();
            var joystick = new Joystick();
            var snake = new Snake(15, 15, 3);
            var board = new Board(40, 20);


            // Setting start variables
            var score = 0;
            int speed = 5;
            bool IsFoodEaten = false;
            KeyDirection direction = KeyDirection.Up;
            var GameRunning = true;



            ShowStartScreen();
            Console.Clear();
            snake.Draw();
            food.Draw();
            board.Draw();
            Countdown(3);
            Console.Clear();
            snake.Draw();
            food.Draw();
            board.Draw();
            Countdown(2);
            Console.Clear();
            snake.Draw();
            food.Draw();
            board.Draw();
            Countdown(1);
            Console.Clear();


            while (GameRunning)
            {
                if (snake.CheckBoardCollision(board))
                {
                    GameRunning = false;
                    break;
                }

                if (snake.CheckTailCollision())
                {
                    GameRunning = false;
                    break;
                }
                // Getting movEment direction
                if (Console.KeyAvailable)
                {
                    direction = joystick.SetKeyDirection(direction);
                }


                IsFoodEaten = snake.Eat(food);
                snake.Move(direction, IsFoodEaten);

                if (IsFoodEaten)
                {
                    score++;
                    food.MakeFood();
                }


                // Drawing the graphics
                snake.Draw();
                food.Draw();
                board.Draw();
                ShowScore(score);



             
                Thread.Sleep(120-speed);
                Console.Clear();
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("GAME OVER");
            ShowScore(score);

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
        static public void Countdown(int number)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(0, 2);
            switch (number)
            {
                case 1:
                    Console.WriteLine("    ▄▄▄▄     ");
                    Console.WriteLine("  ▄█░░░░▌    ");
                    Console.WriteLine(" ▐░░▌▐░░▌    ");
                    Console.WriteLine("  ▀▀ ▐░░▌    ");
                    Console.WriteLine("     ▐░░▌    ");
                    Console.WriteLine("     ▐░░▌    ");
                    Console.WriteLine("     ▐░░▌    ");
                    Console.WriteLine("     ▐░░▌    ");
                    Console.WriteLine(" ▄▄▄▄█░░█▄▄▄ ");
                    Console.WriteLine("▐░░░░░░░░░░░▌");
                    Console.WriteLine(" ▀▀▀▀▀▀▀▀▀▀▀ ");
                    break;
                case 2:
                    Console.WriteLine(" ▄▄▄▄▄▄▄▄▄▄▄ ");
                    Console.WriteLine("▐░░░░░░░░░░░▌");
                    Console.WriteLine(" ▀▀▀▀▀▀▀▀▀█░▌");
                    Console.WriteLine("          ▐░▌");
                    Console.WriteLine("          ▐░▌");
                    Console.WriteLine(" ▄▄▄▄▄▄▄▄▄█░▌");
                    Console.WriteLine("▐░░░░░░░░░░░▌");
                    Console.WriteLine("▐░█▀▀▀▀▀▀▀▀▀ ");
                    Console.WriteLine("▐░█▄▄▄▄▄▄▄▄▄ ");
                    Console.WriteLine("▐░░░░░░░░░░░▌");
                    Console.WriteLine(" ▀▀▀▀▀▀▀▀▀▀▀ ");
                    break;
                case 3:
                    Console.WriteLine(" ▄▄▄▄▄▄▄▄▄▄▄ ");
                    Console.WriteLine("▐░░░░░░░░░░░▌");
                    Console.WriteLine(" ▀▀▀▀▀▀▀▀▀█░▌");
                    Console.WriteLine("          ▐░▌");
                    Console.WriteLine(" ▄▄▄▄▄▄▄▄▄█░▌");
                    Console.WriteLine("▐░░░░░░░░░░░▌");
                    Console.WriteLine(" ▀▀▀▀▀▀▀▀▀█░▌");
                    Console.WriteLine("          ▐░▌");
                    Console.WriteLine(" ▄▄▄▄▄▄▄▄▄█░▌");
                    Console.WriteLine("▐░░░░░░░░░░░▌");
                    Console.WriteLine(" ▀▀▀▀▀▀▀▀▀▀▀ ");
                    break;
            }
            Thread.Sleep(1000);
        }
        static public void ShowScore(int score)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(10, 30);
            Console.Write($"Points: {score}");
            Console.ForegroundColor = ConsoleColor.Black;
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