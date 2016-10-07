using System;

namespace SnakeOOP
{
    class Game
    {
        public static ConsoleColor gameForeground = ConsoleColor.White;
        public static ConsoleColor gameBackground = ConsoleColor.Black;
        public static int gameDifficulty = 60;
        public static int score = 0;
        public void Start()
        {
            Board board = new Board();
            board.create();
            bool gameOver = false;
            Snake snake = new Snake();
            Apple apple = new Apple();
            
            ConsoleKey key;
            direction currentDirection = direction.none;
            apple.generateApple(snake, board);

            while (!gameOver)
            {
                while (Console.KeyAvailable)
                {
                    key = Console.ReadKey().Key;
                    switch (key.ToString())
                    {
                        case "UpArrow":
                            if ((currentDirection != direction.down) && (currentDirection != direction.none))
                                currentDirection = direction.up;
                            break;
                        case "DownArrow":
                            if ((currentDirection != direction.up) && (currentDirection != direction.none))
                                currentDirection = direction.down;
                            break;
                        case "LeftArrow":
                            if ((currentDirection != direction.right) && (currentDirection != direction.none))
                                currentDirection = direction.left;
                            break;
                        case "RightArrow":
                            if (currentDirection != direction.left)
                                currentDirection = direction.right;
                            break;
                        case "Escape":
                            snake.TailExtend();
                            break;
                    }
                }

                switch (currentDirection)
                {
                    case direction.up:
                        snake.MoveUp();
                        break;
                    case direction.down:
                        snake.MoveDown();
                        break;
                    case direction.right:
                        snake.MoveRight();
                        break;
                    case direction.left:
                        snake.MoveLeft();
                        break;
                }

                board.draw(snake, apple);
                
                if (snake.CheckCollision(snake.GetHead().GetCoordX(), snake.GetHead().GetCoordY(), board))
                {
                    gameOver = true;
                    score = 0;
                    Console.Clear();
                }

                if ((snake.GetHead().GetCoordX() == apple.appleCoord.GetCoordY()) && (snake.GetHead().GetCoordY() == apple.appleCoord.GetCoordX()))
                {
                    snake.TailExtend();
                    score++;
                    apple.generateApple(snake, board);
                }
            }
        }
    }
    enum direction { up, left, right, down, none };
}
