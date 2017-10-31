namespace TextBasedGame
{
    public class Item
    {
        public bool Taken { get; set; }
        public string Name { get; set; }

        public Item(string name)
        {
            Name = name;
            Taken = false;
        }
    }
}