using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml.Linq;
using TextBasedGame.commands;

namespace TextBasedGame
{
    internal class Program
    {
        public static IList<ICommand> Commands { get; private set; }
        private static readonly IList<string> AdditionalCommands = new List<string>();
        public static bool Lights { get; set; }

        static void Main(string[] args)
        {
            SetupCommands();
            Room.AddAllRooms();
            var game = Game.StartGame(1);

            Lights = false;
            bool Bedroomkey = false;
            bool Cellarkey = false;
            bool Frontdoorkey = false;
            bool WinGame = false;
            bool VisitedHallWay = false;
            bool VisitedStudy = false;
            bool VisitedKitchen = false;
            bool VisitedCellar = false;
            bool VisitedBedRoom = false;
            var input = "";

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Note: type \"help\" for available commands");
            while (input.ToLower() != "ragequit")
            {
                if (WinGame)
                {
                    break;
                }
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("What do you want to do?");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("=> ");
                input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("\n");

                switch (input.ToLower())
                {
                    case "help":
                        Console.WriteLine("Availabe commands:\n");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t help\n" +
                                          "\t look around\n" +
                                          "\t ragequit");
                        foreach (var addcommand in AdditionalCommands)
                        {
                            Console.WriteLine($"\t {addcommand}");
                        }
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "look around":

                        LookAround(game);

                        break;
                    case "ragequit":
                        Console.WriteLine("A gun magically appeares in front of you. \n" +
                                          "Wanting none of this, you deside to ragequit the experiment. \n" +
                                          "\"Headbutting a bullet is the fastest way out\" was the last thought that went through your head.\n");
                        Console.WriteLine("actually the bullet was the last thing that went through your head...\n\n");
//                        Thread.Sleep(7000);
                        Console.WriteLine(Domain.AsciiArtworks.Death);
//                        Thread.Sleep(1000);
                        game.End();
                        break;
                    case "turn on lights":
                        if (AdditionalCommands.Contains("turn on lights"))
                        {
                            Console.WriteLine("You turned on the lights. \n" +
                                              "The room is now Lit.\n" +
                                              "You notice the light in other rooms are on now aswell.");
                            Lights = true;
                            AdditionalCommands.Remove("turn on lights");
                            
                        }
                        else
                        {
                            Console.WriteLine($"I dont know how to {input}. (type \"help\" for available commands)\n");
                        }
                        break;
                    case "move to hallway":
                        if (Lights && AdditionalCommands.Contains("move to hallway"))
                        {
                            game.Room = Room.Rooms[0][1];
                            Console.WriteLine("You moved to the hallway");
                            VisitedHallWay = true;
                            AdditionalCommands.Remove("move to hallway");
                            AdditionalCommands.Remove("move to kitchen");
                            AdditionalCommands.Remove("move to bedroom");
                            AdditionalCommands.Remove("inspect gun");
                            AdditionalCommands.Remove("inspect note");
                            AdditionalCommands.Remove("inspect corpse");
                            AdditionalCommands.Remove("take frontdoorkey");
                            if (Frontdoorkey)
                            {
                                AdditionalCommands.Add("open frontdoor");
                            }
                        }
                        break;
                    case "move to study":
                        if (Lights && AdditionalCommands.Contains("move to study"))
                        {
                            game.Room = Room.Rooms[0][2];
                            VisitedStudy = true;
                            Console.WriteLine("You moved to the study");
                            AdditionalCommands.Remove("move to study");
                            AdditionalCommands.Remove("move to cellar");
                            AdditionalCommands.Remove("move to livingroom");
                            AdditionalCommands.Remove("take cellarkey");

                        }
                        break;
                    case "move to cellar":
                        if (Lights && AdditionalCommands.Contains("move to cellar"))
                        {
                            if (Cellarkey)
                            {
                                game.Room = Room.Rooms[1][1];
                                VisitedCellar = true;
                                Console.WriteLine("You moved to the cellar");
                                AdditionalCommands.Remove("move to study");
                                AdditionalCommands.Remove("move to cellar");
                                AdditionalCommands.Remove("move to livingroom");
                            }
                            else
                            {
                                Console.WriteLine("cellar door seems to be locked");
                            }
                        }
                        break;
                    case "move to bedroom":
                        if (Lights && AdditionalCommands.Contains("move to bedroom"))
                        {
                            if (Bedroomkey)
                            {
                                game.Room = Room.Rooms[1][2];
                                VisitedBedRoom = true;
                                Console.WriteLine("You moved to the bedroom");
                                AdditionalCommands.Remove("move to hallway");
                                AdditionalCommands.Remove("move to bedroom");
                            }
                            else
                            {
                                Console.WriteLine("bedroom door seems to be locked");
                            }
                        }
                        break;
                    case "move to kitchen":
                        if (Lights && AdditionalCommands.Contains("move to kitchen"))
                        {
                            game.Room = Room.Rooms[1][0];
                            VisitedKitchen = true;
                            Console.WriteLine("You moved to the kitchen");
                            AdditionalCommands.Remove("move to hallway");
                            AdditionalCommands.Remove("move to kitchen");

                        }
                        break;
                    case "move to livingroom":
                        if (Lights && AdditionalCommands.Contains("move to livingroom"))
                        {
                            game.Room = Room.Rooms[0][0];
                            Console.WriteLine("You moved to the livingroom");
                            AdditionalCommands.Remove("move to study");
                            AdditionalCommands.Remove("move to cellar");
                            AdditionalCommands.Remove("move to livingroom");
                            AdditionalCommands.Remove("take bedroomkey");

                        }
                        break;
                    case "inspect note":
                        if (Lights && AdditionalCommands.Contains("inspect note"))
                        {
                            Console.WriteLine("According to legend, anything shot by this colt, using one of the original bullets,  will die. \n" +
                                              "Including supernatural creatures normally immune to any and all weapons.");
                            AdditionalCommands.Add("inspect gun");
                        }
                            break;
                    case "inspect corpse":
                        if (Lights && AdditionalCommands.Contains("inspect corpse"))
                        {
                            Console.WriteLine("Looking at the pen in his hands, he's probably the note-writer.");
                        }
                        break;
                    case "open frontdoor":
                        if (Lights && Frontdoorkey)
                        {
                            Console.WriteLine(Domain.AsciiArtworks.WinArt);
                            WinGame = true;
                            game.End();
                        }
                        break;
                    case "inspect gun":
                        if (Lights && AdditionalCommands.Contains("inspect gun"))
                        {
                            Console.WriteLine("It is an old gun.\n" +
                                              "On the barrel of the gun is inscribed a Latin quote: \"non timebo mala\". if my latin serves correct, it means:\"I will fear no evil\"\n" +
                                              "The handle has a pentagram carved into it.\n" +
                                              "There is only one bullet in the colt, the bullettip is carved with a pentagram and made of silver.");
                        }
                        break;
                    case "take bedroomkey":
                        if (Lights && game.Room == Room.Rooms[1][0] && Bedroomkey == false)
                        {
                            Console.WriteLine("you took the bedroomkey");
                            Bedroomkey = true;
                        }
                        break;
                    case "take cellarkey":
                        if (Lights && game.Room == Room.Rooms[1][2] && Cellarkey == false)
                        {
                            Console.WriteLine("you took the cellarkey");
                            Cellarkey = true;
                        }
                        break;
                    case "take frontdoorkey":
                        if (Lights && game.Room == Room.Rooms[1][1] && Frontdoorkey == false)
                        {
                            Console.WriteLine("you took the frontdoorkey");
                            Frontdoorkey = true;
                        }
                        break;
                    case "hack win":
                        {
                            if (game._name == "Twan")
                            {
                                Console.WriteLine(Domain.AsciiArtworks.WinArt);
                                WinGame = true;
                                game.End();
                            }
                        }
                        break;
                    default:
                        Console.WriteLine($"I dont know how to {input}. (type \"help\" for available commands)\n");
                        break;
                }
            }
            Console.ReadKey();
        }
        private static void SetupCommands()
        {
            Commands = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => x.GetInterfaces().Contains(typeof(ICommand)))
                .Select(x => Activator.CreateInstance(x) as ICommand).ToList();
        }

        private static void LookAround(Game game)
        {
            if (game.Room == Room.Rooms[0][0])
            {
                if (Lights)
                {
                    game.LookAroundLivingRoom(AdditionalCommands);
                }
                else
                {
                    game.LookAround(AdditionalCommands);
                }
            }
            if (game.Room == Room.Rooms[0][1] && Lights)
            {
                game.LookAroundHallWay(AdditionalCommands);
            }
            if (game.Room == Room.Rooms[0][2] && Lights)
            {
                game.LookAroundStudy(AdditionalCommands);
            }
            if (game.Room == Room.Rooms[1][0] && Lights)
            {
                game.LookAroundKitchen(AdditionalCommands);
            }
            if (game.Room == Room.Rooms[1][1] && Lights)
            {
                game.LookAroundCellar(AdditionalCommands);
            }
            if (game.Room == Room.Rooms[1][2] && Lights)
            {
                game.LookAroundBedroom(AdditionalCommands);
            }
        }
    }
}
