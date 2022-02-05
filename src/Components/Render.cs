using System.Numerics;
using Raylib_cs;

namespace PenBreakout.Components
{
    public class Render : Component
    {
        public Texture2D Texture { get; set; }
        public Rectangle Rectangle { get; set; }

        public Render(Texture2D texture)
        {
            Texture = texture;
            Rectangle = new Rectangle(0, 0, Texture.width, Texture.height);
        }
        public Render(string path)
        {
            Texture = Raylib.LoadTexture(path);
            Rectangle = new Rectangle(0, 0, Texture.width, Texture.height);
        }
        public Vector2 GetCenter()
        {
            return new Vector2(Rectangle.x + Rectangle.width / 2, Rectangle.y + Rectangle.height / 2);
        }
    }
}