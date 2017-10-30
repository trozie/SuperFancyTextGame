using System;

namespace TextBasedGame
{
    class Game
    {
        private string _name;


        public void StartGame()
        {
            Initialise();

            Intro();

            End();
        }

        private void Initialise()
        {
            DateTime startTime = DateTime.Now;

            Console.WriteLine("----------------------------------");
            Console.WriteLine("--------SuperFancyTextGame--------");
            Console.WriteLine("----------------------------------");

            Console.WriteLine($"Game started on: {startTime}\n\n");
        }

        private void Intro()
        {
            while (string.IsNullOrEmpty(_name))
            {
                Console.WriteLine("\nGeef een naam: ");
                _name = Console.ReadLine();
            }
            Console.WriteLine($"\n\n\nYou wake up in a dark room. You dont remember how you got here.\n" +
                              $"Looking around you notice a glowing display stating your name and some more:\n\n" +
                              $"{_name}, You have been chosen to become part of an experiment.\n" +
                              $"Try and stay alive.\n" +
                              $"\"Enjoy\"");

        }

        private void End()
        {
            DateTime endTime = DateTime.Now;
            Console.WriteLine($"Game ended on: {endTime}\n");

            Console.WriteLine("----------------------------------");
            Console.WriteLine("----------   THE  END   ----------");
            Console.WriteLine("----------------------------------");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.StartGame();

            Console.ReadKey();
        }
    }
}
