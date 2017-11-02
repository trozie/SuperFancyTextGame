using System;

namespace TextBasedGame.commands
{
    class TurnOnLights : ICommand
    {
        public string Name { get { return "turn on lights"; } }
        public string Description { get { return "Turns on the light in the room"; } }
        public void Execute(Game game)
        {
           /* if (AdditionalCommands.Contains("turn on lights"))
            {
                Console.WriteLine("You turned on the lights. \n" +
                                  "You notice the light in other rooms are on now aswell.");
                Program.Lights = true;
                Program.Commands.Remove( /* object of turn on lights#1# );

            }
            else
            {
                Console.WriteLine($"I dont know how to {input}. (type \"help\" for available commands)\n");
            }*/
        }
    }
}
