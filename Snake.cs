using System.Collections.Generic;
using System.Linq;


namespace SnakeOOP
{
    class Snake
    {
        private const int defaultXpos = 45;
        private const int defaultYpos = 12;

        private Coord _head = new Coord(defaultXpos, defaultYpos);
        private List<Coord> _tail = new List<Coord>();

        public Snake()
        {
            _tail.AddRange(new List<Coord> {
                new Coord(_head.GetCoordX() - 1, _head.GetCoordY()),
                new Coord(_head.GetCoordX() - 2, _head.GetCoordY()),
                new Coord(_head.GetCoordX() - 3, _head.GetCoordY()),
                new Coord(_head.GetCoordX() - 4, _head.GetCoordY())
            });
        }

        public Coord GetHead()
        {
            return _head;
        }

        public bool CheckTail(int x, int y)
        {
            foreach (var element in _tail)
            {
                if (element.GetCoordX() == x && element.GetCoordY() == y)
                    return true;
            }
            return false;
        }

        public void TailFollow(int headX, int headY)
        {
            for (int i = _tail.Count - 1; i > 0; --i)
            {
                _tail[i].SetCoordX(_tail[i - 1].GetCoordX());
                _tail[i].SetCoordY(_tail[i - 1].GetCoordY());
            }
            _tail[0].SetCoordX(GetHead().GetCoordX());
            _tail[0].SetCoordY(GetHead().GetCoordY());
        }

        public void TailExtend()
        {
            int lastElement = _tail.Count() - 1;
            _tail.Add(item: new Coord(_tail[lastElement].GetCoordX(), _tail[lastElement].GetCoordY()));
        }

        public bool CheckCollision(int HeadX, int HeadY, Board board)
        {
            if (HeadX % (board.getWidth()-1) == 0 || HeadY % (board.getHeight()-1) == 0)
            {
                return true;
            }
            else
            {
                foreach (var element in _tail)
                {
                    if (element.GetCoordX() == HeadX && element.GetCoordY() == HeadY)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public void MoveRight()
        {
            TailFollow(_head.GetCoordX(), _head.GetCoordY());
            _head.SetCoordX(_head.GetCoordX() + 1);
        }

        public void MoveLeft()
        {
            TailFollow(_head.GetCoordX(), _head.GetCoordY());
            _head.SetCoordX(_head.GetCoordX() - 1);
        }

        public void MoveUp()
        {
            TailFollow(_head.GetCoordX(), _head.GetCoordY());
            _head.SetCoordY(_head.GetCoordY() - 1);
        }

        public void MoveDown()
        {
            TailFollow(_head.GetCoordX(), _head.GetCoordY());
            _head.SetCoordY(_head.GetCoordY() + 1);
        }
    }
}
