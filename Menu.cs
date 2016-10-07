using System;
using System.Linq;
using System.Threading;


namespace SnakeOOP
{
    class Menu
    {
        public int colorsCurrentOption = 0;
        public int difficultyCurrentOption = 0;

        public void main(Game game)
        {
            String[] menu = { "NEW GAME", "SETTINGS", "  QUIT  " };
            int menuCurrentPosition = 0;
            Console.Clear();

            while (true)
            {
                ConsoleKey key;
                while (Console.KeyAvailable)
                {
                    key = Console.ReadKey().Key;
                    switch (key.ToString())
                    {
                        case "UpArrow":
                            menuCurrentPosition = (menuCurrentPosition == 0) ? 2 : menuCurrentPosition - 1;
                            
                            break;
                        case "DownArrow":
                            menuCurrentPosition = (menuCurrentPosition == 2) ? 0 : menuCurrentPosition + 1;
                            
                            break;
                        case "Enter":
                            switch (menuCurrentPosition)
                            {
                                case 0:
                                    game.Start();
                                    break;
                                case 1:
                                    DrawSettingsMenu();
                                    break;
                                case 2:
                                    Environment.Exit(0);
                                    break;
                            }
                            break;
                    }
                }

                Console.SetCursorPosition(0, 10);
                Thread.Sleep(10);
                DrawHeading();
            

                for (int i = 0, n = menu.Count(); i < n; i++)
                {
                    Console.Write("\t\t\t\t\t");
                    
                    if (i == menuCurrentPosition)
                    {
                        ConsoleColor defaultConsoleBackground = Console.BackgroundColor;
                        ConsoleColor defaultConsoleForeground = Console.ForegroundColor;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(menu[i]);
                        Console.BackgroundColor = defaultConsoleBackground;
                        Console.ForegroundColor = defaultConsoleForeground;
                    }
                    else
                        Console.WriteLine(menu[i]);
                }
            }
        }

        public int DrawSettingsMenu()
        {
            String[] settings = { "Color Scheme", "Difficulty", "  Back  " };
            String[][] configOptions =
            {
                new String[] { "Monochrome", "Doogie Howser", "Metro", "Forest", "Nuke", "Bloody" },  // Color theme configuration options
                new String[] { "Don't kill me", "Bring it on", "Nightmare" } // Difficulty options
            };
            int settingsCurrentPosition = 0;    
            int submenuCurrentOption = 0;
            Console.Clear();

            while (true)
            {
                ConsoleKey key;
                while (Console.KeyAvailable)
                {
                    key = Console.ReadKey().Key;
                    switch (key.ToString())
                    {
                        case "UpArrow":
                            settingsCurrentPosition = (settingsCurrentPosition == 0) ? 2 : settingsCurrentPosition - 1;
                            Console.Clear();
                            
                            break;
                        case "DownArrow":
                            settingsCurrentPosition = (settingsCurrentPosition == 2) ? 0 : settingsCurrentPosition + 1;
                            Console.Clear();
                            
                            break;
                        case "LeftArrow":
                            switch(settingsCurrentPosition)
                            {
                                case 0:
                                    colorsCurrentOption = (colorsCurrentOption == 0) ? 5 : colorsCurrentOption - 1;
                                    ChangeColor(colorsCurrentOption);
                                    Console.Clear();
                                    
                                    break;
                                case 1:
                                    difficultyCurrentOption = (difficultyCurrentOption == 0) ? 2 : difficultyCurrentOption - 1;
                                    Console.Clear();
                                    
                                    break;
                            }
                            break;
                        case "RightArrow":
                            switch (settingsCurrentPosition)
                            {
                                case 0:
                                    colorsCurrentOption = (colorsCurrentOption == 5) ? 0 : colorsCurrentOption + 1;
                                    ChangeColor(colorsCurrentOption);
                                    Console.Clear();
                                    
                                    break;
                                case 1:
                                    difficultyCurrentOption = (difficultyCurrentOption == 2) ? 0 : difficultyCurrentOption + 1;
                                    Console.Clear();
                                    
                                    break;
                            }
                            break;
                        case "Enter":
                            if (settingsCurrentPosition == 2)
                            {
                                switch (difficultyCurrentOption)
                                {
                                    case 0: // Don't kill me
                                        Game.gameDifficulty = 40;
                                        break;
                                    case 1: // Bring it on
                                        Game.gameDifficulty = 20;
                                        break;
                                    case 2: // Nightmare
                                        Game.gameDifficulty = 5;
                                        break;
                                }
                                Console.Clear();
                                return 0;
                            }
                            break;
                    }
                }

                Console.SetCursorPosition(0, 10);
                Thread.Sleep(10);
                DrawHeading();
                
                Console.WriteLine("\t\t\t\t\t SETTINGS");
                for (int i = 0, n = settings.Count(); i < n; i++)
                {
                    switch(i)
                    {
                        case 0:
                            submenuCurrentOption =  colorsCurrentOption;
                            break;
                        case 1:
                            submenuCurrentOption = difficultyCurrentOption;
                            break;
                    }
                   
                    Console.Write("\t\t\t\t\t");
                    if (i == settingsCurrentPosition)
                    {
                        ConsoleColor defaultConsoleBackground = Console.BackgroundColor;
                        ConsoleColor defaultConsoleForeground = Console.ForegroundColor;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;

                        if (settingsCurrentPosition != 2)
                            Console.WriteLine(settings[i] + "\t" + configOptions[i][submenuCurrentOption]);
                        else
                            Console.WriteLine(settings[2]);

                        Console.BackgroundColor = defaultConsoleBackground;
                        Console.ForegroundColor = defaultConsoleForeground;
                    }
                    else
                        Console.WriteLine(settings[i]);
                }
            }
        }

        private void ChangeColor(int ColorScheme)
        {
            switch (ColorScheme)
            {
                case 0: //Monochrome
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 1: //Dark
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
                case 2: //Metro
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case 3: // Forest
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 4: // Nuke
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case 5: // Bloody
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }
        }

        private void DrawHeading()
        {
            Console.WriteLine("\t\t\t     _____                _             ");
            Console.WriteLine("\t\t\t    /  ___|              | |            ");
            Console.WriteLine("\t\t\t    \\ `--.  _ __    __ _ | | __  ___    ");
            Console.WriteLine("\t\t\t     `--. \\| '_ \\  / _` || |/ / / _ \\   ");
            Console.WriteLine("\t\t\t    /\\__/ /| | | || (_| ||   < |  __/   ");
            Console.WriteLine("\t\t\t    \\____/ |_| |_| \\__,_||_|\\_\\ \\___|   ");
            Console.Write("\n\n");
        }
    }
}
