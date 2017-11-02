using System;
using System.Collections.Generic;

namespace TextBasedGame
{
    public class Game
    {

        private string _name;

        public Room Room { get; set; } 
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
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t    ----------------------------------");
            Console.WriteLine("\t    --------SuperFancyTextGame--------");
            Console.WriteLine("\t    ----------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(Domain.AsciiArtworks.InitArt);
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

       
        public void LookAround(IList<string> additionalCommands)
        {
            Console.WriteLine("The room is dark.\n" +
                              "you notice a lightswitch on the wall through the light from the display.\n");
            if (!additionalCommands.Contains("turn on lights"))
            {
                additionalCommands.Add("turn on lights");
            }
        }

        public void LookAroundLight(IList<string> additionalCommands)
        {
            Console.WriteLine("The room is now Lit.\n" +
                              "You see that the room contains a couch, a standing lamp without a hood, a table and a tv screen with the \"welcome message\" shown on it.\n" +
                              "Looking for exits, you notice 2 doors; one to the kitchen, and one to the hallway .\n\n" +
                              "In another room you hear glass shattering followed by an inhuman screech");
            if (!additionalCommands.Contains("move to kitchen"))
            {
                additionalCommands.Add("move to kitchen");
            }

            if (!additionalCommands.Contains("move to hallway"))
            {
                additionalCommands.Add("move to hallway");
            }
        }

        public void LookAroundHallWay (IList<string> additionalCommands)
        {
            Console.WriteLine(" The hallway is quite large and you see 4 doors. the front door, the study, the cellar and the door back to the livingroom.\n" +
                              "you notice a thick leather jacket on the coat rack.\n");
            additionalCommands.Add("move to study");
            additionalCommands.Add("move to cellar");
            additionalCommands.Add("move to livingroom");

        }

        public void LookAroundKitchen(IList<string> additionalCommands)
        {
            Console.WriteLine(" The kitchen is a complete mess. there are no other doors exept the door of the livingroom.\n" +
                              "you notice a cleaver stuck in the kitchen table and a key labled \"bedroom\" nearby.\n");
            additionalCommands.Add("move to livingroom");

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