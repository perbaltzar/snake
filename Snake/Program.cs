using System;
using System.Threading;

namespace Snake
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Black;
           
            // Creating Sprits for the game
            var food = new Food();
            var joystick = new Joystick();
            var snake = new Snake(15, 15, 3);
            var board = new Board(50, 20);

            // Setting start variables
            int speed = 30;
            bool IsFoodEaten = false;
            KeyDirection direction = KeyDirection.Up;
            var GameRunning = true;

            while (GameRunning)
            {
                // Getting movment direction
                if (Console.KeyAvailable)
                {
                    direction = joystick.SetKeyDirection(direction);
                }


                IsFoodEaten = snake.Eat(food);
                snake.Move(direction, IsFoodEaten);

                if (IsFoodEaten)
                {
                    food.MakeFood();
                }

                // Drawing the graphics



                snake.Draw();
                food.Draw();
                board.Draw();
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

                Thread.Sleep(100-speed);
                Console.Clear();
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("GAME OVER");

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