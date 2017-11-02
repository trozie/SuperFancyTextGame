using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

            var input = "";

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Note: type \"help\" for available commands");
            while (input.ToLower() != "ragequit")
            {
                
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
                        if (game.Room == Room.Rooms[0][0])
                        {
                            if (Lights)
                            {
                                game.LookAroundLight(AdditionalCommands);
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
                        break;
                    case "ragequit":
                        Console.WriteLine("A gun magically appeares in front of you. \n" +
                                          "Wanting none of this, you deside to ragequit the experiment. \n" +
                                          "\"Headbutting a bullet is the fastest way out\" was the last thought that went through your head.\n");
                        Console.WriteLine("actually the bullet was the last thing that went through your head...\n\n");
                        Console.WriteLine(Domain.AsciiArtworks.Death);
                        game.End();
                        break;
                    case "turn on lights":
                        if (AdditionalCommands.Contains("turn on lights"))
                        {
                            Console.WriteLine("You turned on the lights. \n" +
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
                        if (Lights)
                        {
                            game.Room = Room.Rooms[0][1];
                            Console.WriteLine("You moved to the hallway");
                            AdditionalCommands.Remove("move to hallway");
                            AdditionalCommands.Remove("move to kitchen");
                        }
                        break;
                        
                    case "move to kitchen":
                        if (Lights)
                        {
                            game.Room = Room.Rooms[1][0];
                            Console.WriteLine("You moved to the kitchen");
                            AdditionalCommands.Remove("move to hallway");
                            AdditionalCommands.Remove("move to kitchen");

                        }
                        break;
                    case "move to livingroom":
                        if (Lights)
                        {
                            game.Room = Room.Rooms[0][0];
                            Console.WriteLine("You moved to the kitchen");
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
    }
}
