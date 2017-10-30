using System;

namespace TextBasedGame
{
    class Game
    {
        public static void StartGame()
        {
            Initialise();

            Start();

            End();
        }

        private static void Initialise()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("--------SuperFancyTextGame--------");
            Console.WriteLine("----------------------------------\n");
        }

        private static void Start()
        {

        }

        private static void End()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("----------   THE  END   ----------");
            Console.WriteLine("----------------------------------\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Game.StartGame();

            Console.WriteLine("Press any key to close this window");
            Console.ReadKey();
        }
    }
}
