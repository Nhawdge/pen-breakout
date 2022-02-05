using System.Runtime;
using System.Collections.Generic;
using PenBreakout.Entities;
using static Raylib_cs.Raylib;
using System;
using System.Numerics;
using PenBreakout.Components;

namespace PenBreakout.Systems
{
    public class RenderingSystem : System
    {
        public Raylib_cs.Texture2D pigTexture { get; set; }
        public Raylib_cs.Texture2D horseTexture { get; set; }
        public Raylib_cs.Texture2D fenceTexture { get; set; }
        public Raylib_cs.Texture2D barnyardTexture { get; set; }
        private Engine Engine { get; set; }

        public override void Load(Engine engine)
        {
            this.Engine = engine;
            // Load Assets
            pigTexture = LoadTexture("src/Assets/pig.png");
            horseTexture = LoadTexture("src/Assets/horse.png");
            fenceTexture = LoadTexture("src/Assets/fence.png");
            barnyardTexture = LoadTexture("src/Assets/barnyard.png");
        }

        public override void Update(List<Entity> allEntities)
        {
            var bgSourceRect = new Raylib_cs.Rectangle(0, 0, barnyardTexture.width, barnyardTexture.height);
            var bgDestinationRect = new Raylib_cs.Rectangle(0, 0, 800, 800);
            DrawTexturePro(barnyardTexture, bgSourceRect, bgDestinationRect, new Vector2(0), 0f, Raylib_cs.Color.WHITE);
            foreach (var entity in allEntities)
            {
                var myPos = entity.GetComponent<Position>();
                //Console.WriteLine($"Rendering {entity.Id}");
                if (CanRender(entity))
                {
                    var myRender = entity.GetComponent<Render>();
                    var destinationRect = new Raylib_cs.Rectangle(myPos.X, myPos.Y, 64, 64);

                    Raylib_cs.Raylib.DrawTexturePro(myRender.Texture, myRender.Rectangle, myPos.Rectangle, new Vector2(0), 0f, Raylib_cs.Color.WHITE);
                }
                var actions = entity.GetComponents<PenBreakout.Components.Action>();
                foreach (var action in actions)
                {
                    if (action.ActiveAction == Actions.Lasso)
                    {
                        var yDistance = action.Target.Y - myPos.Y;
                        var xDistance = action.Target.X - myPos.X;
                        var angle = Math.Atan2(yDistance, xDistance);

                        int destX = (int)(myPos.X + (float)Math.Cos(angle) * Math.Min(action.Duration, 100));
                        int destY = (int)(myPos.Y + (float)Math.Sin(angle) * Math.Min(action.Duration, 100));

                        DrawLine(myPos.X, myPos.Y, destX, destY, Raylib_cs.Color.BROWN);
                    }
                }
            }
        }
        private static bool CanRender(Entity entity)
        {
            return true;
        }
    }

}