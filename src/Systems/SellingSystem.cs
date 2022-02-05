using System.Collections.Generic;
using PenBreakout.Entities;
using PenBreakout.Components;
using System.Linq;

namespace PenBreakout.Systems
{
    public class SellingSystem : Systems.System
    {
        private Engine Engine { get; set; }
        public override void Load(Engine engine)
        {
            Engine = engine;
        }

        public override void Update(List<Entity> allEntities)
        {
            var sellSquares = allEntities.Where(x => x.GetComponent<SellSquare>() != null);
            var entitiesToDelete = new List<Entity>();
            foreach (var entity in allEntities)
            {
                if (entity.GetComponent<FarmAi>() != null)
                {
                    var myRender = entity.GetComponent<Render>();
                    foreach (var sellSquare in sellSquares)
                    {
                        var sqRender = sellSquare.GetComponent<Render>();
                        if (Raylib_cs.Raylib.CheckCollisionPointRec(myRender.GetCenter(), sqRender.Rectangle))
                        {
                            entitiesToDelete.Add(entity);
                        }
                    }
                }
            }
            foreach (var entity in entitiesToDelete)
            {
                Engine.Entities.Remove(entity);
            }
        }
    }
}