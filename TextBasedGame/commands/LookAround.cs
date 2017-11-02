using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedGame.commands
{
    class LookAround : ICommand
    {
        public string Name { get { return "look around"; } }
        public string Description { get { return "you look around the room"; } }
        public void Execute(Game game)
        {
            
        }
    }
}
