using System.Numerics;
using System;
using System.Collections.Generic;
using PenBreakout.Components;
using PenBreakout.Entities;

namespace PenBreakout.Systems
{
    public class AiMovementSystem : Systems.System
    {
        public override void Load(Engine engine) { }

        public override void Update(List<Entity> allEntities)
        {
            var rand = new Random();
            foreach (var entity in allEntities)
            {
                if (AiCanMove(entity))
                {
                    var myPos = entity.GetComponent<Position>();
                    myPos.Direction += rand.Next(-1, 1);
                    var futureX = Math.Cos(myPos.Direction) * myPos.Speed;
                    var futureY = Math.Sin(myPos.Direction) * myPos.Speed;
                    var futurePos = new Vector2((int)futureX, (int)futureY);
                    //Console.WriteLine($"{entity.Id} is moving to {futurePos} ({futureX}, {futureY}), Direction: {myPos.Direction}");

                    myPos.X += (int)futurePos.X;
                    myPos.Y += (int)futurePos.Y;

                }
            }
        }
        private bool AiCanMove(Entity entity)
        {
            return entity.GetComponent<FarmAi>() != null;
        }
    }
}