using System;
using System.Threading;

namespace Snake
{
    public class Game
    {
        private Snake Snake { get; set; }
        private Food Food { get; set; }
        private Joystick Joystick { get; set; }
        private Board Board { get; set; }

        private int BoardHeight { get; set;}
        private int BoardWidth { get; set; }

        private int Score { get; set; }
        private int Speed { get; }
        private bool IsFoodEaten { get; set; }
        private bool GameRunning { get; set; }
        private KeyDirection Direction { get; set; }





        public Game()
        {
            //Setting the size of the board
            this.BoardHeight = 20;
            this.BoardWidth = 60;

            // Creating Sprites for the game
            this.Food = new Food(this.BoardWidth, this.BoardHeight);
            this.Joystick = new Joystick();
            this.Snake = new Snake(5, 10, 3);
            this.Board = new Board(this.BoardWidth, this.BoardHeight);

            // Changing colors and hiding cursor
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Black;

            // Setting startvariables
            this.Score = 0;
            this.Speed = 5;
            this.IsFoodEaten = false;
            this.Direction = KeyDirection.Right;
            this.GameRunning = true;


        }
        public void Countdown ()
        {

            Console.Clear();
            Snake.Draw();
            Food.Draw();
            Board.Draw();
            ShowLargeNumber(3, BoardWidth);
            Console.Clear();
            Snake.Draw();
            Food.Draw();
            Board.Draw();
            ShowLargeNumber(2, BoardWidth);
            Console.Clear();
            Snake.Draw();
            Food.Draw();
            Board.Draw();
            ShowLargeNumber(1, BoardWidth);
            Console.Clear();
        }


        public void Run() 
        {
            while (GameRunning)
            {
                // Check for collision with tail and board
                if (Snake.CheckBoardCollision(Board))
                {
                    GameRunning = false;
                    break;
                }
                if (Snake.CheckTailCollision())
                {
                    GameRunning = false;
                    break;
                }
                // Getting movement direction
                if (Console.KeyAvailable)
                {
                    Direction = Joystick.SetKeyDirection(Direction);
                }


                IsFoodEaten = Snake.Eat(Food);
                Snake.Move(Direction, IsFoodEaten);

                if (IsFoodEaten)
                {
                    Score++;
                    Food.MakeFood(BoardWidth, BoardHeight);
                }


                // Drawing the graphics
                Snake.Draw();
                Food.Draw();
                Board.Draw();
                ShowScore(Score);




                Thread.Sleep(120 - Speed);
                Console.Clear();
            }
        }
        static public void ShowScore(int score)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(10, 30);
            Console.Write($"Points: {score}");
            Console.ForegroundColor = ConsoleColor.Black;
        }

        static public void ShowLargeNumber(int number, int boardWidth)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            var cursorX = boardWidth / 2 - 7;
            Console.SetCursorPosition(cursorX, 2);

            switch (number)
            {
                case 1:
                    Console.WriteLine("    ▄▄▄▄     ");
                    Console.SetCursorPosition(cursorX, 3);
                    Console.WriteLine("  ▄█░░░░▌    ");
                    Console.SetCursorPosition(cursorX, 4);
                    Console.WriteLine(" ▐░░▌▐░░▌    ");
                    Console.SetCursorPosition(cursorX, 5);
                    Console.WriteLine("  ▀▀ ▐░░▌    ");
                    Console.SetCursorPosition(cursorX, 6);
                    Console.WriteLine("     ▐░░▌    ");
                    Console.SetCursorPosition(cursorX, 7);
                    Console.WriteLine("     ▐░░▌    ");
                    Console.SetCursorPosition(cursorX, 8);
                    Console.WriteLine("     ▐░░▌    ");
                    Console.SetCursorPosition(cursorX, 9);
                    Console.WriteLine("     ▐░░▌    ");
                    Console.SetCursorPosition(cursorX, 10);
                    Console.WriteLine(" ▄▄▄▄█░░█▄▄▄ ");
                    Console.SetCursorPosition(cursorX, 11);
                    Console.WriteLine("▐░░░░░░░░░░░▌");
                    Console.SetCursorPosition(cursorX, 12);
                    Console.WriteLine(" ▀▀▀▀▀▀▀▀▀▀▀ ");
                    break;
                case 2:
                    Console.WriteLine(" ▄▄▄▄▄▄▄▄▄▄▄ ");
                    Console.SetCursorPosition(cursorX, 3);
                    Console.WriteLine("▐░░░░░░░░░░░▌");
                    Console.SetCursorPosition(cursorX, 4);
                    Console.WriteLine(" ▀▀▀▀▀▀▀▀▀█░▌");
                    Console.SetCursorPosition(cursorX, 5);
                    Console.WriteLine("          ▐░▌");
                    Console.SetCursorPosition(cursorX, 6);
                    Console.WriteLine("          ▐░▌");
                    Console.SetCursorPosition(cursorX, 7);
                    Console.WriteLine(" ▄▄▄▄▄▄▄▄▄█░▌");
                    Console.SetCursorPosition(cursorX, 8);
                    Console.WriteLine("▐░░░░░░░░░░░▌");
                    Console.SetCursorPosition(cursorX, 9);
                    Console.WriteLine("▐░█▀▀▀▀▀▀▀▀▀ ");
                    Console.SetCursorPosition(cursorX, 10);
                    Console.WriteLine("▐░█▄▄▄▄▄▄▄▄▄ ");
                    Console.SetCursorPosition(cursorX, 11);
                    Console.WriteLine("▐░░░░░░░░░░░▌");
                    Console.SetCursorPosition(cursorX, 12);
                    Console.WriteLine(" ▀▀▀▀▀▀▀▀▀▀▀ ");
                    break;
                case 3:
                    Console.WriteLine(" ▄▄▄▄▄▄▄▄▄▄▄ ");
                    Console.SetCursorPosition(cursorX, 3);
                    Console.WriteLine("▐░░░░░░░░░░░▌");
                    Console.SetCursorPosition(cursorX, 4);
                    Console.WriteLine(" ▀▀▀▀▀▀▀▀▀█░▌");
                    Console.SetCursorPosition(cursorX, 5);
                    Console.WriteLine("          ▐░▌");
                    Console.SetCursorPosition(cursorX, 6);
                    Console.WriteLine(" ▄▄▄▄▄▄▄▄▄█░▌");
                    Console.SetCursorPosition(cursorX, 7);
                    Console.WriteLine("▐░░░░░░░░░░░▌");
                    Console.SetCursorPosition(cursorX, 8);
                    Console.WriteLine(" ▀▀▀▀▀▀▀▀▀█░▌");
                    Console.SetCursorPosition(cursorX, 9);
                    Console.WriteLine("          ▐░▌");
                    Console.SetCursorPosition(cursorX, 10);
                    Console.WriteLine(" ▄▄▄▄▄▄▄▄▄█░▌");
                    Console.SetCursorPosition(cursorX, 11);
                    Console.WriteLine("▐░░░░░░░░░░░▌");
                    Console.SetCursorPosition(cursorX, 12);
                    Console.WriteLine(" ▀▀▀▀▀▀▀▀▀▀▀ ");
                    break;
            }
            Thread.Sleep(1000);
        }
    }
}
