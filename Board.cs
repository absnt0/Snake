using System;
using System.Threading;


namespace SnakeOOP
{
    class Board
    {
        private const int WIDTH = 100;
        private const int HEIGHT = 25;
        private char[,] board = new char[HEIGHT, WIDTH];
        
        public void create()
        {
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    board[i, j] = ' ';
                }
            }
        }

        public void draw(Snake snake, Apple apple)
        {
            Coord snakeHead = snake.GetHead();
            string drawBuffer = "";

            Console.WriteLine();
            drawBuffer += String.Format("\t\tSNAKE \t\t\t\t SCORE: {0}\n", Game.score);
            drawBuffer += "     _____                _              \n";
            drawBuffer += "    /  ___|              | |             \n";
            drawBuffer += "    \\ `--.  _ __    __ _ | | __  ___     \n";
            drawBuffer += "     `--. \\| '_ \\  / _` || |/ / / _ \\    \n";
            drawBuffer += "    /\\__/ /| | | || (_| ||   < |  __/    \n";
            drawBuffer += "    \\____/ |_| |_| \\__,_||_|\\_\\ \\___|    \n";
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    if (i % (HEIGHT - 1) == 0 || j % (WIDTH - 1) == 0)
                        drawBuffer += "█";
                    else if ((snakeHead.GetCoordX() == j && snakeHead.GetCoordY() == i) || (snake.CheckTail(j, i)) || (apple.appleCoord.GetCoordX() == i && apple.appleCoord.GetCoordY() == j))
                        drawBuffer += "█";
                    else
                        drawBuffer += " ";
                }
                drawBuffer += "\n";
            }
            
            Console.SetCursorPosition(0, 0);
            Console.Write(drawBuffer);
            Thread.Sleep(Game.gameDifficulty);
        }

        public int getWidth()
        {
            return WIDTH;
        }

        public int getHeight()
        {
            return HEIGHT;
        }
    }
}
