using System;
namespace Snake
{
    public class Joystick
    {

        //Snake direction
        public KeyDirection SetKeyDirection(KeyDirection PreviousDirection)
        {
            var direction = Console.ReadKey().Key;

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
            }
            return PreviousDirection; 
        }



    }
}
