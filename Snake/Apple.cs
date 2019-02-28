using System;
namespace Snake
{
    public class Apple : Food
    {
        //--------------------------------------------
        // Additional variables for the Playable Apple
        //--------------------------------------------
        private int Rotten { get; set; }
        private int MaxWidth { get; }
        private int MaxHeight { get; }
        private int Lifes { get; set; } = 20;

        public Apple(int width, int height) : base(width, height)
        {
            MakeFood(width, height);
            MaxWidth = width;
            MaxHeight = height;
            Rotten = 0;
        }

        //--------------------------------------------
        // Setting new values for the coordinates of 
        // the apple
        //--------------------------------------------
        public KeyDirection Move(KeyDirection direction)
        {
           
            switch (direction)
            {
                case KeyDirection.W:
                    if (this.Y > 1)
                    {
                        this.Rotten--;
                        this.Y--;
                    }
                    break;
                case KeyDirection.S:
                    if (Y < MaxHeight - 1)
                    {
                        this.Rotten--;
                        this.Y++;
                    }
                    break;
                case KeyDirection.A:
                    if (X > 1)
                    {
                        this.Rotten--;
                        this.X--;
                    }
                    break;
                case KeyDirection.D:
                    if (X < MaxWidth - 1)
                    {
                        this.Rotten--;
                        this.X++;
                    }
                    break;
            }
            return KeyDirection.None;
        }
        //--------------------------------------------
        // UnDraw the apple
        //--------------------------------------------
        public void EraseOldApple()
        {
            Console.SetCursorPosition(this.X, this.Y);
            Console.Write(" ");
        }

        //--------------------------------------------
        // Making the apple enery less and less each turn
        //--------------------------------------------
        public void RottTheApple()
        {
            this.Rotten++;
        }

        //--------------------------------------------
        // Return the apple's energuy
        //--------------------------------------------
        public int GetEnergy()
        {
            var energyLeft = 90 - Rotten;
            this.Rotten = 0;
            return energyLeft;

        }
        //--------------------------------------------
        // Return the apple's lives
        //--------------------------------------------
        public int GetLifes()
        {
            return this.Lifes;
        }

        public void LoseLife()
        {
            this.Lifes--;
        }
        public void DrawLifes(int height)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(3, height + 3);
            Console.Write("Apple: ");
            for (int i = 0; i < this.Lifes; i++)
            {
               
                    Console.SetCursorPosition(13+i, height + 3);
                    Console.Write("");
            }
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}
