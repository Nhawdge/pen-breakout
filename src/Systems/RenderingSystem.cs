using System.Runtime;
using System.Collections.Generic;
using PenBreakout.Entities;
using static Raylib_cs.Raylib;
using System;
using System.Numerics;
using PenBreakout.Components;
using Raylib_cs;

namespace PenBreakout.Systems
{
    public class RenderingSystem : System
    {
        public Raylib_cs.Texture2D barnyardTexture { get; set; }
        private Engine Engine { get; set; }

        public override void Load(Engine engine)
        {
            this.Engine = engine;
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
                if (CanRender(entity))
                {

                    var myRender = entity.GetComponent<Render>();
                    //Console.WriteLine($"Rendering {entity.Id}, {myRender.Texture.id}");
                    var destinationRect = new Raylib_cs.Rectangle(myPos.X, myPos.Y, 64, 64);

                    Raylib.DrawTexturePro(myRender.Texture, myRender.Rectangle, myPos.Rectangle, new Vector2(0), 0f, Raylib_cs.Color.WHITE);
                }
                var actions = entity.GetComponents<PenBreakout.Components.Action>();
                foreach (var action in actions)
                {
                    if (action.ActiveAction == Actions.Lasso)
                    {
                        DrawLine(myPos.X, myPos.Y, (int)action.DrawPoint.X, (int)action.DrawPoint.Y, Raylib_cs.Color.BROWN);
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