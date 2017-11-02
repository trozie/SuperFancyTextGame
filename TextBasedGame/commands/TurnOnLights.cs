using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedGame.commands
{
    class TurnOnLights : ICommand
    {
        public string Name { get { return "turn on lights"; } }
        public string Description { get { return "Turns on the light in the room"; } }
        public void Execute(Game game)
        {
            
        }
    }
}
