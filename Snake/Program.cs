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
            var GameRunning = true;
            var joystick = new Joystick();
            var snake = new Snake(15, 15, 3);
            KeyDirection direction = KeyDirection.Up;
            int speed = 30;
            var food = new Food();
            bool IsFoodEaten = false;
            var board = new Board(50, 20);

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