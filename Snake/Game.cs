using System;
using System.Threading;

namespace Snake
{
    public class Game
    {
        //--------------------------------------------
        // 
        //--------------------------------------------
        private Snake Snake { get; set; }
        private Apple Apple { get; set; }
        private Food Food { get; set; }
        private Joystick Joystick { get; set; }
        private Board Board { get; set; }
        private Energy Energybar { get; set; }

        private int BoardHeight { get; set;}
        private int BoardWidth { get; set; }


        private int Energy { get; set; }
        private int SnakeEnergy { get; set; }


        private int Score { get; set; }
        private int Speed { get; }
        private bool IsFoodEaten { get; set; }
        private bool GameRunning { get; set; }
        private string Winner { get; set; }
        private bool TwoPlayer { get; set; }
        private KeyDirection Direction { get; set; }
        private KeyDirection AppleDirection { get; set; }
        private KeyDirection SnakeDirection { get; set; }


        public Game(bool twoPlayerGame)
        {
            //--------------------------------------------
            //Setting the size of the board
            //--------------------------------------------
            this.BoardHeight = 20;
            this.BoardWidth = 60;

            //--------------------------------------------
            // Creating Sprites for the game
            //--------------------------------------------
            this.Food = new Food(this.BoardWidth, this.BoardHeight);
            this.Joystick = new Joystick();
            this.Snake = new Snake(5, 10, 3);
            this.Board = new Board(this.BoardWidth, this.BoardHeight);
            this.Apple = new Apple(this.BoardWidth, this.BoardHeight);
            this.Energybar = new Energy();

            //--------------------------------------------
            // Changing colors and hiding cursor
            //--------------------------------------------
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Black;

            //--------------------------------------------
            // Setting startvariables
            //--------------------------------------------
            this.Score = 0;
            this.Speed = 5;
            this.IsFoodEaten = false;
            this.Direction = KeyDirection.Right;
            this.GameRunning = true;
            this.AppleDirection = KeyDirection.None;
            this.SnakeDirection = KeyDirection.Right;
            this.TwoPlayer = twoPlayerGame;


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


        public bool Run() 
        {
            while (GameRunning)
            {
                //--------------------------------------------
                // Check for collision with tail and board
                //--------------------------------------------
                if (Snake.CheckBoardCollision(Board))
                {
                    GameRunning = false;
                    this.Winner = "Apple";
                    break;
                }
                if (Snake.CheckTailCollision())
                {
                    GameRunning = false;
                    this.Winner = "Apple";
                    break;
                }
                //--------------------------------------------
                // Getting movement direction
                //--------------------------------------------
                if (Console.KeyAvailable)
                {
                    Direction = Joystick.SetKeyDirection(SnakeDirection);
                    if (Direction == KeyDirection.Up || Direction == KeyDirection.Down || Direction == KeyDirection.Left || Direction == KeyDirection.Right)
                    {
                        SnakeDirection = Direction;
                    }
                    else
                    {
                        AppleDirection = Direction;
                    }
                }
                if (TwoPlayer)
                {
                    SnakeEnergy = Snake.GetEnergy();
                    IsFoodEaten = Snake.Eat(Apple);

                }
                else
                {
                    IsFoodEaten = Snake.Eat(Food);
                }

                Snake.Move(SnakeDirection, IsFoodEaten);
                AppleDirection = Apple.Move(AppleDirection);
               

                if (IsFoodEaten)
                {
                    Apple.LoseLife();
                    Score++;
                    if (TwoPlayer)
                    {
                        Apple.MakeFood(BoardWidth, BoardHeight);
                        Energy = Apple.GetEnergy();
                        Snake.GetEnergyFromApple(Energy);

                    }
                    else
                    {
                        Food.MakeFood(BoardWidth, BoardHeight);
                    }

                }

                //--------------------------------------------
                // Drawing the graphics
                //--------------------------------------------
                Snake.Draw();
                Board.Draw();


                //--------------------------------------------
                // 
                //--------------------------------------------
                if (TwoPlayer)
                {
                    Apple.RottTheApple();
                    Energybar.Draw(BoardHeight, SnakeEnergy);
                    Snake.LoseEnergy();
                    Apple.Draw();
                    Apple.DrawLifes(BoardHeight);
                }
                else
                {
                    Food.Draw();
                    ShowScore(Score, BoardHeight);
                }



                if (SnakeEnergy < 1 && TwoPlayer)
                {
                    // Show winning screen and ask if you want to play again
                    // True resets the game, false go back to title screen
                    // ShowWinner(Winner);
                    // bool PlayAgain = PlayAgain();
                    this.GameRunning = false;
                    this.Winner = "Apple";

                }
                if (Apple.GetLifes() < 1 && TwoPlayer)
                {
                    this.GameRunning = false;
                    this.Winner = "Snake";
                }

                //--------------------------------------------
                // Timer for loop
                //--------------------------------------------
                Thread.Sleep(100 - Speed);
                Console.Clear();

            }
            Console.ForegroundColor = ConsoleColor.White;
            GameOver(this.Winner);
            Console.ReadKey();
            Console.Clear();

            return true;
        }
        static public void ShowScore(int score, int height)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(35, height+2);
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
        public void GameOver(string winner)
        {
            Console.WriteLine(" ██████╗  █████╗ ███╗   ███╗███████╗     ██████╗ ██╗   ██╗███████╗██████╗ ");
            Console.WriteLine("██╔════╝ ██╔══██╗████╗ ████║██╔════╝    ██╔═══██╗██║   ██║██╔════╝██╔══██╗");
            Console.WriteLine("██║  ███╗███████║██╔████╔██║█████╗      ██║   ██║██║   ██║█████╗  ██████╔╝");
            Console.WriteLine("██║   ██║██╔══██║██║╚██╔╝██║██╔══╝      ██║   ██║╚██╗ ██╔╝██╔══╝  ██╔══██╗");
            Console.WriteLine("╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗    ╚██████╔╝ ╚████╔╝ ███████╗██║  ██║");
            Console.WriteLine(" ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝     ╚═════╝   ╚═══╝  ╚══════╝╚═╝  ╚═╝");
            Console.WriteLine("");
            Console.WriteLine($"{winner} has won the game!");
            Console.ReadKey();
        }
    }
}
