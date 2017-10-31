using System.Collections.Generic;

namespace TextBasedGame
{
    internal class Room
    {
        private const int GridX = 2;
        private const int GridY = 3;
        public IList<Item> Items { get; }
        public string Name { get; }
        public static Room[][] Rooms { get; }

        static Room()
        {
            Rooms = new Room[GridX][];
            for (var i = 0; i < GridX; i++)
            {
                Rooms[i] = new Room[GridY];
            }
        }

        public static void AddAllRooms()
        {
            var roomlist = new string[][] 
            {
                new string[] { "Livingroom", "Hallway", "Studyroom" },
                new string[] { "Kitchen", "Cellar", "Bedroom" } 
            };


            for (var i = 0; i < GridX; i++)
            {
                for (var j = 0; j < GridY; j++)
                {
                    Rooms[i][j] = new Room(roomlist[i][j], new[] { new Item("Lamp Voet") });
                }
            }
        }

        public Room(string name, IEnumerable<Item> items)
        {
            Items = new List<Item>(items);
            Name = name;
        }



    }
}
