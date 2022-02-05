using System.Numerics;
namespace PenBreakout.Components
{
    public class Action : Component
    {
        public Actions ActiveAction { get; set; }
        public Render Render { get; set; }
        public int Duration { get; set; }
        public int CountDirection { get; set; } = 3;
        public Vector2 Target { get; set; }
        public Action(Actions action, Vector2 target)
        {
            ActiveAction = action;
            Target = target;
        }
    }

    public enum Actions
    {
        Yell,
        Lasso
    }
}