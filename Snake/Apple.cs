using System;
namespace Snake
{
    public class Apple : Food
    {
        //--------------------------------------------
        // Additional variables for the Playable Apple
        //--------------------------------------------
        public int Rotten { get; set; }
        public int MaxWidth { get; set; }
        public int MaxHeight { get; set; }

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
        // Making the apple enery less and less each turn
        //--------------------------------------------
        public void RottTheApple()
        {
            this.Rotten++;
        }

        //--------------------------------------------
        // Return the apple inclues
        //--------------------------------------------
        public int GetEnergy()
        {
            var energyLeft = 90 - Rotten;
            this.Rotten = 0;
            return energyLeft;
        }
    }
}
