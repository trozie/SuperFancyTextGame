using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace TextBasedGame
{
    class Game
    {
        private string death =
                "    ________                                 ________\r\n    ` \\  / `                                 ` \\  / `\r\n     (____)                                   (____)\r\n       ||       .-\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"-.       ||\r\n      <__>     /                         \\     <__>\r\n       ||     |--LI-------------------LI--|     ||\r\n       ||    (|   ===      -|-      ===   |)    ||\r\n       ||     |             |             |     ||\r\n       ||     |___________________________|     ||\r\n       ||     `||\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"||`     ||\r\n      _||_     ||-----------------------||     _||_\r\n     /____\\   _||_                     _||_   /____\\"
            ;
        private IList<string> additionalCommands = new List<string>();
        private string _name;
        private string _input = "placeholder";
        private string _room = "Living Room";
        private int _level = 1;

        public void StartGame()
        {
            Initialise();
            Intro();
            Core();
            End();
        }

        private void Initialise()
        {

            var init_art = $"\n                            ,-.\r\n       ___,---.__          /\'|`\\          __,---,___\r\n    ,-\'    \\`    `-.____,-\'  |  `-.____,-\'    //    `-.\r\n  ,\'        |           ~\'\\     /`~           |        `.\r\n /      ___//              `. ,\'          ,  , \\___      \\\r\n|    ,-\'   `-.__   _         |        ,    __,-\'   `-.    |\r\n|   /          /\\_  `   .    |    ,      _/\\          \\   |\r\n\\  |           \\ \\`-.___ \\   |   / ___,-\'/ /           |  /\r\n \\  \\           | `._  ■`\\\\  |  //\'■  _,\' |           /  /\r\n  `-.\\         /\'  _ `---\'\' , . ``---\' _  `\\         /,-\'\r\n     ``       /     \\    ,=\'/ \\`=.    /     \\       \'\'\r\n             |__   /|\\_,--.,-.--,--._/|\\   __|\r\n             /  `./  \\\\`\\ |  |  | /,//\' \\,\'  \\\r\n            /   /     ||--+--|--+-/-|     \\   \\\r\n           |   |     /\'\\_\\_\\ | /_/_/`\\     |   |\r\n            \\   \\__, \\_     `~\'     _/ .__/   /\r\n             `-._,-\'   `-._______,-\'   `-._,-\'";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t    ----------------------------------");
            Console.WriteLine("\t    --------SuperFancyTextGame--------");
            Console.WriteLine("\t    ----------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(init_art);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
        }

        private void Intro()
        {
            DateTime startTime = DateTime.Now;
            Console.WriteLine($"Game started on:{startTime}\n\n");

            while (string.IsNullOrEmpty(_name))
            {
                Console.WriteLine("\nHello Player! What is your name? ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                _name = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine("\n\n\nYou wake up in a dark room. You dont remember how you got here.\n" +
                              $"Looking around you notice a glowing display stating your name and some more:\n\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\t{_name},\n\tYou have been chosen to become part of an experiment.\n" +
                              $"\tYour current level is {_level}\n\n" +
                              "\tTry and stay alive.\n" +
                              "\t\"Enjoy\"\n\n" +
                              "\t~ DM\n\n");
        }

        private void Core()
        {
            while (_input.ToLower() != "ragequit")
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("What do you want to do? (type \"help\" for available commands)");
                Console.ForegroundColor = ConsoleColor.Yellow;
                _input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("\n");

                switch (_input.ToLower())
                {
                    case "help":
                        Console.WriteLine("Availabe commands:\n");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t help\n" +
                                          "\t look around\n" +
                                          "\t ragequit");
                        foreach (var addcommand in additionalCommands)
                        {
                            Console.WriteLine($"\t {addcommand}");
                        }
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "look around":
                        LookAround();
                        break;
                    case "ragequit":
                        Console.WriteLine("A gun magically appeares in front of you. \n" +
                                          "Wanting to ragequit the experiment, you deside headbutting a bullet is the fastest way out.\n\n");
                        Console.WriteLine(death);
                        break;
                    default:
                        Console.WriteLine($"I dont know how to do {_input}. (type \"help\" for available commands)");
                        break;
                }
            }
        }

        private void LookAround()
        {
            Console.WriteLine("The room is dark.\n" +
                              "you notice a lightswitch on the wall through the light from the display.\n");
            if (!additionalCommands.Contains("turn on lights"))
            {
                additionalCommands.Add("turn on lights");
            }
        }

        private void End()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            DateTime endTime = DateTime.Now;
            Console.WriteLine($"Game ended on: {endTime}\n");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t    ----------------------------------");
            Console.WriteLine("\t    ----------   THE  END   ----------");
            Console.WriteLine("\t    ----------------------------------");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.StartGame();

            Console.ReadKey();
        }
    }
}
