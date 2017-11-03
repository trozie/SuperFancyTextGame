using System;
using System.Collections.Generic;
using System.Threading;

namespace TextBasedGame
{
    public class Game
    {

        public string _name { get; private set; }

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
            Thread.Sleep(600);
            Console.WriteLine(Domain.AsciiArtworks.InitArt);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Thread.Sleep(200);
            Console.WriteLine($"Game started on:{StartTime}\n\n");
            Thread.Sleep(100);
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

        public void LookAroundLivingRoom(IList<string> AdditionalCommands)
        {
           Console.WriteLine("You see that the room contains a couch, a standing lamp without a hood, a table and a tv screen with the \"welcome message\" shown on it.\n" +
                              "Looking for exits, you notice 2 doors; one to the kitchen, and one to the hallway .\n\n" +
                              "In another room you hear glass shattering followed by an inhuman screech");
           AdditionalCommands.Add("move to kitchen");
           AdditionalCommands.Add("move to hallway");
           
        }

        public void LookAroundHallWay (IList<string> AdditionalCommands)
        {
            Console.WriteLine("The hallway is quite large and you see 4 doors. the front door, the study, the cellar and the door back to the livingroom.\n" +
                              "you notice a thick leather jacket on the coat rack.\n");
            AdditionalCommands.Add("move to study");
            AdditionalCommands.Add("move to cellar");
            AdditionalCommands.Add("move to livingroom");

        }

        public void LookAroundKitchen(IList<string> AdditionalCommands)
        {
            Console.WriteLine("The kitchen is a complete mess. there are no other doors exept the door of the livingroom.\n" +
                              "you notice a cleaver stuck in the kitchen table and a key labled \"bedroom\" nearby.\n");
            AdditionalCommands.Add("move to livingroom");
            AdditionalCommands.Add("take bedroomkey");
        }

        public void LookAroundCellar(IList<string> AdditionalCommands)
        {
            Console.WriteLine("The cellar is dimly lit and smells like death.\n" +
                              "There are no other doors exept the stairs to the hallway.\n" +
                              "you see a lot of junk, but also a harness in the corner.\n" +
                              "As you are looking for more interesting stuff, you notice a bloody key, a bloodysoaked note and a gun on a table.\n" +
                              "To your horror you see a corpse slanted againt the table.");
            AdditionalCommands.Add("move to hallway");
            AdditionalCommands.Add("inspect note");
            AdditionalCommands.Add("inspect corpse");
            AdditionalCommands.Add("take frontdoorkey");
        }
        public void LookAroundStudy(IList<string> AdditionalCommands)
        {
            Console.WriteLine("There are a lot of bookcases and a billiards table in the room\n" +
                              "the study seems to connect the bedroom and the hallway.\n" +
                              "on top the billiard lies a billiards cue and a the cueball.\n" +
                              "there is nothing interesting in the room.\n");
            AdditionalCommands.Add("move to hallway");
            AdditionalCommands.Add("move to bedroom");
        }
        public void LookAroundBedroom(IList<string> AdditionalCommands)
        {
            Console.WriteLine("The bedroom looks very spartan. You only see a nightstand, a clock on the wall, a small wardrobe and the bed itself.\n" +
                              "the bedroom is only attached to the study.\n" +
                              "on the bed lies a key and a bloody note.");
            AdditionalCommands.Add("move to study");
            AdditionalCommands.Add("take cellarkey");
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
            Thread.Sleep(400);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t    ----------------------------------");
            Console.WriteLine("\t    ----------   THE  END   ----------");
            Console.WriteLine("\t    ----------------------------------");
        }
    }
}