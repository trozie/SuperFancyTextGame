using System;

namespace TextBasedGame.commands
{
    class LookAround : ICommand
    {
        public string Name { get { return "look around"; } }
        public string Description { get { return "You look around the room"; } }
        public void Execute(Game game)
        {
            /*Console.WriteLine("The room is dark.\n" +
                              "you notice a lightswitch on the wall through the light from the display.\n");
            if (!AdditionalCommands.Contains("turn on lights"))
            {
                AdditionalCommands.Add("turn on lights");
            }*/
        }
    }
}
