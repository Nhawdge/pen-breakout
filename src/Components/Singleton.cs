namespace PenBreakout.Components
{
    public class Singleton : Component
    {
        GameState State = GameState.Menu;
    }

    public enum GameState
    {
        Menu,
        Game,
    }
}