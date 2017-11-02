using System.Collections.Generic;

namespace TextBasedGame
{
    public class Room
    {
        private const int GridX = 2;
        private const int GridY = 3;
        public IList<Item> Items { get; private set; } = new List<Item>();
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
                    Rooms[i][j] = new Room(roomlist[i][j]);
                }
            }
            Rooms[0][0].Items = new List<Item>      //living room
            {
                new Item("Lamp foot"),
                new Item("Lightbulb")
            };
            Rooms[0][1].Items = new List<Item>      //Hallway
            {
                new Item("thick leather Jacket")
            };
            Rooms[0][2].Items = new List<Item>      //Study
            {
                new Item("billiard cue"),
                new Item("cue ball")
            };
            Rooms[1][0].Items = new List<Item>      //kitchen
            {
                new Item("bedroom key"),
                new Item("cleaver")
            };
            Rooms[1][1].Items = new List<Item>      //cellar
            {
                new Item("steel harness"),
                new Item("front door key"),
                new Item("the colt") //  It is an old gun. On the barrel of the gun is inscribed a Latin quote: "non timebo mala". The handle has a pentagram carved into it. There is only one bullet in the colt.
            };
            Rooms[1][2].Items = new List<Item>      //bedroom
            {
                new Item("cellar key"),
            };
        }

        public Room(string name)
        {
            Name = name;
        }



    }
}
