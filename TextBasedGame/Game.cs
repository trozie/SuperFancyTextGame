using System;
using System.Collections.Generic;

namespace TextBasedGame
{
    public class Game
    {
        //public static string Death = "    ________                                 ________\r\n    ` \\  / `                                 ` \\  / `\r\n     (____)                                   (____)\r\n       ||       .-\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"-.       ||\r\n      <__>     /                         \\     <__>\r\n       ||     |--LI-------------------LI--|     ||\r\n       ||    (|   ===      -|-      ===   |)    ||\r\n       ||     |             |             |     ||\r\n       ||     |___________________________|     ||\r\n       ||     `||\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"||`     ||\r\n      _||_     ||-----------------------||     _||_\r\n     /____\\   _||_                     _||_   /____\\";


        private string _name;

        public Room Room { get; private set; } 
        private int _level;
        public DateTime StartTime { get; }
        

        public Game(int level)
        {
            
            StartTime = DateTime.Now;
            Initialise(level);
            Intro();
        }

        public static Game StartGame(int level)
        {
            var game = new Game(level);
            
            return game;
        }

        private void Initialise(int level)
        {
            Room = Room.Rooms[0][0];
            _level = level;

        }
        private void Intro()
        {
            var initArt = $"\n                            ,-.\r\n       ___,---.__          /\'|`\\          __,---,___\r\n    ,-\'    \\`    `-.____,-\'  |  `-.____,-\'    //    `-.\r\n  ,\'        |           ~\'\\     /`~           |        `.\r\n /      ___//              `. ,\'          ,  , \\___      \\\r\n|    ,-\'   `-.__   _         |        ,    __,-\'   `-.    |\r\n|   /          /\\_  `   .    |    ,      _/\\          \\   |\r\n\\  |           \\ \\`-.___ \\   |   / ___,-\'/ /           |  /\r\n \\  \\           | `._  ■`\\\\  |  //\'■  _,\' |           /  /\r\n  `-.\\         /\'  _ `---\'\' , . ``---\' _  `\\         /,-\'\r\n     ``       /     \\    ,=\'/ \\`=.    /     \\       \'\'\r\n             |__   /|\\_,--.,-.--,--._/|\\   __|\r\n             /  `./  \\\\`\\ |  |  | /,//\' \\,\'  \\\r\n            /   /     ||--+--|--+-/-|     \\   \\\r\n           |   |     /\'\\_\\_\\ | /_/_/`\\     |   |\r\n            \\   \\__, \\_     `~\'     _/ .__/   /\r\n             `-._,-\'   `-._______,-\'   `-._,-\'";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t    ----------------------------------");
            Console.WriteLine("\t    --------SuperFancyTextGame--------");
            Console.WriteLine("\t    ----------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(initArt);
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.WriteLine($"Game started on:{StartTime}\n\n");

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

       
        public void LookAround(IList<string> AdditionalCommands)
        {
            Console.WriteLine("The room is dark.\n" +
                              "you notice a lightswitch on the wall through the light from the display.\n");
            if (!AdditionalCommands.Contains("turn on lights"))
            {
                AdditionalCommands.Add("turn on lights");
            }
        }

        public void LookAroundLight(IList<string> additionalCommands)
        {
            Console.WriteLine("The room is now Lit.\n" +
                              "You see that the room contains a couch, a standing lamp without a hood, a table and a tv screen with the \"welcome message\" shown on it.\n" +
                              "Looking for exits, you notice 2 doors; one to the kitchen and one to the hallway.\n\n" +
                              "In another room you hear glass shattering followed by an inhuman screech");
        }

        public void End()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            DateTime endTime = DateTime.Now;
            Console.WriteLine($"Game ended on: {endTime}\n");

            var diff = endTime.Subtract(StartTime);
            var res = String.Format("{0} day(s) {1} hour(s) {2} minute(s) and {3} second(s)", diff.Days, diff.Hours,
                diff.Minutes, diff.Seconds);
            Console.WriteLine($"time elapsed this game: {res}\n");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t    ----------------------------------");
            Console.WriteLine("\t    ----------   THE  END   ----------");
            Console.WriteLine("\t    ----------------------------------");
        }
    }
}