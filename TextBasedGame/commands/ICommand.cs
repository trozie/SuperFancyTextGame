namespace TextBasedGame.commands
{
    public interface ICommand
    {
        string Name { get; }
        string Description { get; }
        void Execute(Game game);
    }
}
