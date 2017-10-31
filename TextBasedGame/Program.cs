using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace TextBasedGame
{
    internal class Program
    {
        private static readonly IList<string> _additionalCommands = new List<string>();

        static void Main(string[] args)
        {
            Room.AddAllRooms();
            var game = Game.StartGame(1);

            var input = "";
            while (input.ToLower() != "ragequit")
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("What do you want to do? (type \"help\" for available commands)");
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
                        game.LookAround(_additionalCommands);
                        break;
                    case "ragequit":
                        Console.WriteLine("A gun magically appeares in front of you. \n" +
                                          "Wanting to ragequit the experiment, you deside headbutting a bullet is the fastest way out.\n\n");
                        Console.WriteLine(Game.Death);
                        game.End();
                        break;
                    default:
                        Console.WriteLine($"I dont know how to do {input}. (type \"help\" for available commands)");
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}
