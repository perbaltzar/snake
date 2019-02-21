using System;
namespace Snake
{
    public class Joystick
    {
        public KeyDirection SetKeyDirection(KeyDirection PreviousDirection)
        {
            var direction = Console.ReadKey().Key;

            switch (direction)
            {
                case ConsoleKey.DownArrow:
                    return KeyDirection.Down;
                case ConsoleKey.UpArrow:
                    return KeyDirection.Up;
                case ConsoleKey.LeftArrow:
                    return KeyDirection.Left;
                case ConsoleKey.RightArrow:
                    return KeyDirection.Right;
            }
            return PreviousDirection; 
        }
    }
}
