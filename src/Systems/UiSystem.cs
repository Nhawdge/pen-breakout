using System.Collections.Generic;
using PenBreakout.Components;
using PenBreakout.Entities;
using Raylib_cs;

namespace PenBreakout.Systems
{
    public class UiSystem : Systems.System
    {
        public Engine Engine { get; private set; }

        public override void Load(Engine engine)
        {
            Engine = engine;
        }

        public override void Update(List<Entity> allEntities)
        {
            Raylib_cs.Raylib.DrawText("Score: " + Engine.Singleton.GetComponent<Singleton>().Score, 10, 10, 20, Color.WHITE);
        }
    }
}