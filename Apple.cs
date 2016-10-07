using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeOOP
{
    class Apple
    {
        public Coord appleCoord = new Coord(10, 15);

        public void generateApple(Snake snake, Board board)
        {
            Random rndX = new Random();
            Random rndY = new Random();
            bool notGenerated = true;
            int randomX; 
            int randomY; 

            while (notGenerated)
            {
                randomX = rndX.Next(1, board.getHeight() - 1);
                randomY = rndY.Next(1, board.getWidth() - 1);
                Coord snakeHead = snake.GetHead();

                if ((randomX != snakeHead.GetCoordX() && randomY != snakeHead.GetCoordY()) || (!snake.CheckTail(randomY, randomX)))
                {
                    notGenerated = false;
                    appleCoord.SetCoordX(randomX);
                    appleCoord.SetCoordY(randomY);
                }
            }
        }
    }
}
