namespace SnakeOOP
{
    class Coord
    {
        private int _x { get; set; }
        private int _y { get; set; }

        public Coord()
        {
            _x = 0;
            _y = 0;
        }

        public Coord(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public int GetCoordX()
        {
            return _x;
        }

        public int GetCoordY()
        {
            return _y;
        }

        public void SetCoordX(int x)
        {
            _x = x;
        }

        public void SetCoordY(int y)
        {
            _y = y;
        }


    }
}
