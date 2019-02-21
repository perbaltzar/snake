using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Snake
{
    public class Snake
    {
        private int X { get; set; }
        private int Y { get; set; }
        public int Lenght { get; set; }
        public List<Point> Tail { get; set; }


        public Snake(int x, int y, int lenght)
        {
            this.X = x;
            this.Y = y;
            //this.Lenght = lenght;
            this.Tail = new List<Point>();

            for (var i = 1; i <= lenght; i++)
            {
                this.Tail.Add(new Point(this.X, this.Y-i));
            }
           

        }

        public void Move (KeyDirection direction, bool IsFoodEaten)
        {
            if (!IsFoodEaten)
            {
                this.Tail.RemoveAt(0);

            }
            this.Tail.Add(new Point(this.X, this.Y));
            switch (direction)
            {
                case KeyDirection.Up:
                    this.Y--;
                    break;
                case KeyDirection.Down:
                    this.Y++;
                    break;
                case KeyDirection.Left:
                    this.X--;
                    break;
                case KeyDirection.Right:
                    this.X++;
                    break;
            }
        }






        public void Draw()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            foreach (var tailposition in this.Tail)
            {
                Console.SetCursorPosition(tailposition.X, tailposition.Y);
                Console.Write(" ");
            }

            Console.SetCursorPosition(this.X, this.Y);
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public bool CheckTailCollision()
        {
            return (this.Tail.Any(k => k.X == this.X && k.Y == this.Y));
        }
        public bool Eat(Food food)
        {
            if (this.X == food.X && this.Y == food.Y)
            {
                return true;
            }
            return false;
        }
    }
}



/*
 *  if (Console.KeyAvailable)
 * CODE FOR CRAB: \ud83e\udd80
                {
                    var key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        case ConsoleKey.UpArrow:
                            direction = "up";
                            break;
                        case ConsoleKey.DownArrow:
                            direction = "down";
                            break; 
                        case ConsoleKey.LeftArrow:
                            direction = "left";
                            break;
                        case ConsoleKey.RightArrow:
                            direction = "right";
                            break;
                    }
                }
*/
