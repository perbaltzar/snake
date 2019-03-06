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
        private Snake SnakePlayerTwo { get; set; }
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
        private int TwoPlayerScore { get; set; }
        private int Speed { get; }
        private bool IsFoodEaten { get; set; }

        private bool OnePlayerFoodIsEaten { get; set; }
        private bool TwoPlayerFoodIsEaten { get; set; }
        private bool GameRunning { get; set; }
        private string Winner { get; set; }
        private GameMode GameMode { get; set; }
        private KeyDirection Direction { get; set; }
        private KeyDirection AppleDirection { get; set; }
        private KeyDirection SnakeDirection { get; set; }
        private KeyDirection SnakeDirectionPlayerTwo { get; set; }


        public Game(GameMode gameMode)
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
            this.SnakePlayerTwo = new Snake(5, 15, 3);
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
            this.TwoPlayerScore = 0;
            this.Speed = 5;
            this.IsFoodEaten = false;
            this.Direction = KeyDirection.Right;
            this.GameRunning = true;
            if (gameMode == GameMode.SnakeVsApple)
            {
                this.AppleDirection = KeyDirection.None;
            }
            else
            {
                this.AppleDirection = KeyDirection.D;
            }
            this.SnakeDirection = KeyDirection.Right;
            this.SnakeDirectionPlayerTwo = KeyDirection.Right;
            this.GameMode = gameMode;
            this.OnePlayerFoodIsEaten = false;
            this.TwoPlayerFoodIsEaten = false;


        }
        public void Countdown ()
        {
            Console.Clear();
            Snake.Draw("Green");
            Food.Draw();
            Board.Draw();
            ShowLargeNumber(3, BoardWidth);
            Console.Clear();
            Snake.Draw("Green");
            Food.Draw();
            Board.Draw();
            ShowLargeNumber(2, BoardWidth);
            Console.Clear();
            Snake.Draw("Green");
            Food.Draw();
            Board.Draw();
            ShowLargeNumber(1, BoardWidth);
            Console.Clear();
            Board.Draw();
        }


        public bool Run() 
        {
            while (GameRunning)
            {
                if (GameMode == GameMode.SinglePlayer)
                {
                    if (Snake.CheckBoardCollision(Board))
                    {
                        GameRunning = false;
                        this.Winner = "Someone Else";
                        break;
                    }
                    if (Snake.CheckTailCollision())
                    {
                        GameRunning = false;
                        this.Winner = "Someone Else";
                        break;
                    }
                }
                //--------------------------------------------
                // Check for collision with tail and board
                //--------------------------------------------
                if (GameMode == GameMode.SnakeVsApple)
                {
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

                }
                else if (GameMode == GameMode.SnakeVsSnake)
                {
                    //--------------------------------------------
                    // Check for collision on Snake Player Two
                    //--------------------------------------------
                    if (SnakePlayerTwo.CheckBoardCollision(Board))
                    {
                        GameRunning = false;
                        this.Winner = "Player 1";
                        break;
                    }
                    if (SnakePlayerTwo.CheckTailCollision())
                    {
                        GameRunning = false;
                        this.Winner = "Player 1";
                        break;
                    }
                    if (SnakePlayerTwo.CheckSnakeCollision(Snake))
                    {
                        GameRunning = false;
                        this.Winner = "Player 1";
                        break;
                    }
                    //--------------------------------------------
                    // Check for collision with other Snake
                    //--------------------------------------------
                    //if (Snake.CheckSnakeCollision(SnakePlayerTwo))
                    //{
                    //    GameRunning = false;
                    //    this.Winner = "Player 2";
                    //    break;
                    //}
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

                //--------------------------------------------
                // Eating of the apple
                //--------------------------------------------
                if (GameMode == GameMode.SnakeVsApple)
                {
                    SnakeEnergy = Snake.GetEnergy();
                    IsFoodEaten = Snake.Eat(Apple);

                }
                else if (GameMode == GameMode.SinglePlayer)
                {
                    IsFoodEaten = Snake.Eat(Food);
                }
                else if (GameMode == GameMode.SnakeVsSnake)
                {

                    OnePlayerFoodIsEaten = Snake.Eat(Food);
                    TwoPlayerFoodIsEaten = SnakePlayerTwo.Eat(Food);
                    if (OnePlayerFoodIsEaten)
                    {
                        Score++;
                        IsFoodEaten = true;                    
                    }
                    if (TwoPlayerFoodIsEaten)
                    {
                        TwoPlayerScore++;
                        IsFoodEaten = true;
                    }

                }

                Apple.EraseOldApple();
                if (GameMode == GameMode.SnakeVsApple)
                {
                    Snake.Move(SnakeDirection, IsFoodEaten);
                    AppleDirection = Apple.Move(AppleDirection);
                }
                else if (GameMode == GameMode.SnakeVsSnake)
                {
                    SnakeDirectionPlayerTwo = SnakePlayerTwo.TranslateAppleDirectionToSnake(AppleDirection, SnakeDirectionPlayerTwo);
                    Snake.Move(SnakeDirection, OnePlayerFoodIsEaten);
                    SnakePlayerTwo.Move(SnakeDirectionPlayerTwo, TwoPlayerFoodIsEaten);
                }
                else if (GameMode == GameMode.SinglePlayer)
                {
                    Snake.Move(SnakeDirection, IsFoodEaten);
                }




                if (IsFoodEaten)
                {

                    if (GameMode == GameMode.SnakeVsApple)
                    {
                        Apple.LoseLife();
                        Apple.MakeFood(BoardWidth, BoardHeight);
                        Energy = Apple.GetEnergy();
                        Snake.GetEnergyFromApple(Energy);
                    }
                    else if (GameMode == GameMode.SnakeVsSnake)
                    {
                        Food.MakeFood(BoardWidth, BoardHeight);
                        IsFoodEaten = false;
                    }
                    else
                    {
                        Score++;
                        Food.MakeFood(BoardWidth, BoardHeight);
                    }

                }

                //--------------------------------------------
                // Drawing the graphics in both modes
                //--------------------------------------------
                Snake.Draw("Green");
                




                //--------------------------------------------
                // Drawing different for Two vs One Player mode
                //--------------------------------------------
                if (GameMode == GameMode.SnakeVsApple)
                {
                    Apple.RottTheApple();
                    Energybar.Draw(BoardHeight, SnakeEnergy);
                    Snake.LoseEnergy();
                    Apple.Draw();
                    Apple.DrawLifes(BoardHeight);
                }
                else if (GameMode == GameMode.SnakeVsSnake)
                {
                    SnakePlayerTwo.Draw("Magenta");
                    Food.Draw();
                }
                else
                {
                    Food.Draw();
                    ShowScore(Score, BoardHeight);
                }



                if (SnakeEnergy < 1 && GameMode == GameMode.SnakeVsApple)
                {
                    this.GameRunning = false;
                    this.Winner = "Apple";

                }
                if (Apple.GetLifes() < 1 && GameMode == GameMode.SnakeVsApple)
                {
                    this.GameRunning = false;
                    this.Winner = "Snake";
                }

                //--------------------------------------------
                // Timer for loop
                //--------------------------------------------
                Thread.Sleep(100 - Speed);
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            GameOver(this.Winner);
            bool playAgain = AskIfPlayAgain();

            return playAgain;
        }
        public bool RunTwoPlayerSnake()

        {
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
            lock (Program.WriteLock)
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
        public void GameOver(string winner)
        {

            Console.WriteLine(" ██████╗  █████╗ ███╗   ███╗███████╗     ██████╗ ██╗   ██╗███████╗██████╗ ");
            Console.WriteLine("██╔════╝ ██╔══██╗████╗ ████║██╔════╝    ██╔═══██╗██║   ██║██╔════╝██╔══██╗");
            Console.WriteLine("██║  ███╗███████║██╔████╔██║█████╗      ██║   ██║██║   ██║█████╗  ██████╔╝");
            Console.WriteLine("██║   ██║██╔══██║██║╚██╔╝██║██╔══╝      ██║   ██║╚██╗ ██╔╝██╔══╝  ██╔══██╗");
            Console.WriteLine("╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗    ╚██████╔╝ ╚████╔╝ ███████╗██║  ██║");
            Console.WriteLine(" ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝     ╚═════╝   ╚═══╝  ╚══════╝╚═╝  ╚═╝");
            Console.WriteLine("");
            Console.SetCursorPosition(26, 8);
            Console.WriteLine($"{winner} has won the game!");
            Console.WriteLine("");
        }
        public bool AskIfPlayAgain() 
        {
            Console.SetCursorPosition(18, 11);
            Console.WriteLine("Press Enter to play again, ESC to exit!");
            while (true)
            {
                var key = Console.ReadKey().Key;
                if (key == ConsoleKey.Enter)
                {
                    return true;
                }
                if (key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    return false;
                }
            }
        }
    }
}
