using System;
using System.Threading;

namespace Snake
{
    public class Joystick
    {
        //--------------------------------------------
        // Reading the Keys for direction
        // Same used in One and Two Player mode
        //--------------------------------------------
        public KeyDirection SetKeyDirection(KeyDirection PreviousDirection)
        {

            var direction = Console.ReadKey(true).Key;

            Thread.Sleep(10);

            switch (direction)
            {
                case ConsoleKey.DownArrow:
                    if (PreviousDirection != KeyDirection.Up)
                    {
                        return KeyDirection.Down;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (PreviousDirection != KeyDirection.Down)
                    {
                        return KeyDirection.Up;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (PreviousDirection != KeyDirection.Right)
                    {
                        return KeyDirection.Left;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (PreviousDirection != KeyDirection.Left)
                    {
                        return KeyDirection.Right;
                    }
                    break;

                case ConsoleKey.W:
                    return KeyDirection.W;

                case ConsoleKey.S:
                    return KeyDirection.S;

                case ConsoleKey.A:
                    return KeyDirection.A;
                  
                case ConsoleKey.D:
                    return KeyDirection.D;
                   
            }
            return PreviousDirection; 

        }



    }
}
