using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedGame.commands
{
    class RageQuit
    {
        public string Name { get { return "ragequit"; } }
        public string Description { get { return "Give up the experiment."; } }

        public void Execute(Game game)
        {
            Console.WriteLine("A gun magically appeares in front of you. \n" +
                              "Wanting none of this, you deside to ragequit the experiment. \n" +
                              "\"Headbutting a bullet is the fastest way out\" was the last thought that went through your head.\n");
            Console.WriteLine("actually the bullet was the last thing that went through your head...\n\n");
            Console.WriteLine(Domain.AsciiArtworks.Death);
            game.End();
        }
    }
}
