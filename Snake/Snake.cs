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
        private int Energy { get; set; }
        private int Lenght { get; set; }
        private List<Point> Tail { get; }


        public Snake(int x, int y, int lenght)
        {
            this.X = x;
            this.Y = y;
            this.Tail = new List<Point>();
            this.Energy = 150;

            for (var i = lenght; i >= 1; i--)
            {
                this.Tail.Add(new Point(this.X-i, this.Y));
            }
        }

        public void Move (KeyDirection direction, bool IsFoodEaten)
        {
            if (!IsFoodEaten)
            {
                var EndTailX = this.Tail.ElementAt(0).X;
                var EndTailY = this.Tail.ElementAt(0).Y;
                Console.SetCursorPosition(EndTailX, EndTailY);
                //Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(" ");
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

        //--------------------------------------------
        // Drawing the Snake graphics
        //--------------------------------------------
        public void Draw(string color)
        {
            lock (Program.WriteLock)
            {
                if (color == "Green")
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                }
                else if (color == "Magenta")
                {
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                }
                foreach (var tailposition in this.Tail)
                {

                    Console.SetCursorPosition(tailposition.X, tailposition.Y);
                    Console.Write(" ");
                }
                if (color == "Green")
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                }
                else if (color == "Magenta")
                {
                    Console.BackgroundColor = ConsoleColor.Magenta;
                }
                Console.SetCursorPosition(this.X, this.Y);
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Black;
            }

        }

        //--------------------------------------------
        // Check if Snake hits itself
        //--------------------------------------------
        public bool CheckTailCollision()
        {
            return (this.Tail.Any(k => k.X == this.X && k.Y == this.Y));
        }

        //--------------------------------------------
        // Check if snake hits the walls
        //--------------------------------------------
        public bool CheckBoardCollision(Board board)
        {
            if (this.X <= 1)
            {
                return true;
            }
            if (this.X >= board.Lenght)
            {
                return true;
            }
            if (this.Y <= 1)
            {
                return true;
            }
            if (this.Y >= board.Height)
            {
                return true;
            }
            return false;
        }

        //--------------------------------------------
        // Check collision with food
        //--------------------------------------------
        public bool Eat(Food food)
        {
            if (this.X == food.X && this.Y == food.Y)
            {
                return true;
            }
            return false;
        }

        //--------------------------------------------
        // Makes the snake lose 1 energy point every turn
        //--------------------------------------------
        public void LoseEnergy()
        {
            this.Energy--;
        }

        //--------------------------------------------
        // Add energy from the apple to the snake
        //--------------------------------------------
        public void GetEnergyFromApple(int energy)
        {
            this.Energy += energy;
            if (this.Energy > 150)
            {
                this.Energy = 150;
            }
        }
        //--------------------------------------------
        // Return the energy value in two player mode
        //--------------------------------------------
        public int GetEnergy()
        {
            return this.Energy;
        }
        public KeyDirection TranslateAppleDirectionToSnake(KeyDirection direction, KeyDirection previousDirection)
        {
            switch (direction)
            {
                case KeyDirection.W:
                    if (previousDirection != KeyDirection.Left)
                    {
                        return KeyDirection.Up;
                    }
                    break;
                case KeyDirection.S:
                    if (previousDirection != KeyDirection.Up)
                    {
                        return KeyDirection.Down;
                    }
                    break;
                case KeyDirection.A:
                    if (previousDirection != KeyDirection.Right)
                    {
                        return KeyDirection.Left;
                    }
                    break;
                case KeyDirection.D:
                    if (previousDirection != KeyDirection.Left)
                    {
                        return KeyDirection.Right;
                    }
                    break;
            }
            return previousDirection;
        }
    }
}


