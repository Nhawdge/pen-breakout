using System.Numerics;
using System.Collections.Generic;
using PenBreakout.Components;
using PenBreakout.Entities;
using static Raylib_cs.Raylib;
using Raylib_cs;

namespace PenBreakout.Systems
{
    public class ControllableSystem : Systems.System
    {
        public override void Load(Engine engine)
        {
        }

        public override void Update(List<Entity> allEntities)
        {
            var player = allEntities.Find(x => x.GetComponent<Controllable>() != null);
            var playerPos = player.GetComponent<Position>();
            if (IsKeyDown(KeyboardKey.KEY_A))
            {
                playerPos.X -= playerPos.Speed;
            }
            if (IsKeyDown(KeyboardKey.KEY_D))
            {
                playerPos.X += playerPos.Speed;
            }
            if (IsKeyDown(KeyboardKey.KEY_W))
            {
                playerPos.Y -= playerPos.Speed;
            }
            if (IsKeyDown(KeyboardKey.KEY_S))
            {
                playerPos.Y += playerPos.Speed;
            }
            if (IsKeyDown(KeyboardKey.KEY_SPACE))
            {
                player.Components.Add(new Action(Actions.Yell, Vector2.Zero));
            }
            if (IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON))
            {
                if (player.GetComponent<Action>() == null)
                {
                    player.Components.Add(new Action(Actions.Lasso, GetMousePosition()));
                }
            }
        }
    }
}