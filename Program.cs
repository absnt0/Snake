using System;



namespace SnakeOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 35;
            Console.WindowWidth = 105;
            Console.BufferHeight = 35;
            Console.BufferWidth = 105;
            Console.Title = "SNAKE by absnt";
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            var game = new Game();
            var menu = new Menu();
            
            menu.main(game);
        
            Console.ReadKey();
        }
    }
}
