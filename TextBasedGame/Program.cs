using System;
using System.Collections.Generic;

namespace TextBasedGame
{
    internal class Program
    {
        private static readonly IList<string> _additionalCommands = new List<string>();

        static void Main(string[] args)
        {
            Room.AddAllRooms();
            var game = Game.StartGame(1);
            var lights = false;
            var input = "";

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Note: type \"help\" for available commands");
            while (input.ToLower() != "ragequit")
            {
                
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("What do you want to do?");
                Console.ForegroundColor = ConsoleColor.Yellow;
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
                        foreach (var addcommand in _additionalCommands)
                        {
                            Console.WriteLine($"\t {addcommand}");
                        }
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "look around":
                        if (lights)
                        {
                            game.LookAroundLight(_additionalCommands);
                        }
                        else
                        {
                            game.LookAround(_additionalCommands);
                        }
                        break;
                    case "ragequit":
                        Console.WriteLine("A gun magically appeares in front of you. \n" +
                                          "Wanting none of this, you desideto ragequit the experiment. \n" +
                                          "\"Headbutting a bullet is the fastest way out\" was the last thing that went through your mind.\n" +
                                          "(actually the bullet was the last thing...)\n\n");
                        Console.WriteLine(Game.Death);
                        game.End();
                        break;
                    case "turn on lights":
                        if (_additionalCommands.Contains("turn on lights"))
                        {
                            Console.WriteLine("You turned on the lights. \n" +
                                              "You notice the light in other rooms are on now aswell.");
                            lights = true;
                            _additionalCommands.Remove("turn on lights");
                            
                        }
                        else
                        {
                            Console.WriteLine($"I dont know how to {input}. (type \"help\" for available commands)\n");
                        }
                        break;
                    default:
                        Console.WriteLine($"I dont know how to {input}. (type \"help\" for available commands)\n");
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}
