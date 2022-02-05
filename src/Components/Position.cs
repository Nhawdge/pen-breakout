using System.Numerics;

namespace PenBreakout.Components
{
    public class Position : Component
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int Speed { get; set; } = 2;
        public int Direction { get; set; } = 0;

        public Vector2 AsVector() => new Vector2(X, Y);

    }
}