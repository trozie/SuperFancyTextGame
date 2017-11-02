using System;

namespace TextBasedGame.commands
{
    public class HelpCommand : ICommand
    {
        public string Name { get { return "help"; } }
        public string Description { get { return "This command"; } }
        public void Execute(Game game)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Available help Commands: ");
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var command1 in Program.Commands)
            {
                Console.WriteLine($"{command1.Name} : {command1.Description}");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
