using System.Numerics;
using System.Collections.Generic;
using PenBreakout.Entities;
using PenBreakout.Components;
using System;
using System.Linq;

namespace PenBreakout.Systems
{
    public class ActionSystem : Systems.System
    {
        public override void Load(Engine engine)
        {
        }

        public override void Update(List<Entity> allEntities)
        {
            foreach (var entity in allEntities)
            {
                var actions = entity.GetComponents<Components.Action>();
                var myPos = entity.GetComponent<Position>();
                Components.Action actionCompleted = null;
                foreach (var action in actions)
                {
                    if (action.ActiveAction == Actions.Lasso)
                    {
                        action.Duration += action.CountDirection;
                        if (action.AttachedEntity != Guid.Empty)
                        {
                            var attachedEntity = allEntities.Find(x => x.Id == action.AttachedEntity);
                            if (attachedEntity == null)
                            {
                                entity.Components.Remove(actionCompleted);

                            }
                            else
                            {
                                var attachedPos = attachedEntity.GetComponent<Position>();
                                if (attachedPos != null)
                                {
                                    attachedPos.X = myPos.X;
                                    attachedPos.Y = myPos.Y;
                                }
                            }
                        }
                        if (action.Duration > 100)
                        {
                            foreach (var target in allEntities.Where(x => x.GetComponent<FarmAi>() != null))
                            {
                                var targetPos = target.GetComponent<Position>();
                                if (Raylib_cs.Raylib.CheckCollisionPointRec(action.DrawPoint, targetPos.Rectangle))
                                {
                                    //action.CountDirection = 0;
                                    action.AttachedEntity = target.Id;
                                }
                                else
                                {
                                    action.CountDirection = -5;
                                }
                            }
                        }
                        if (action.Duration < 0)
                        {
                            actionCompleted = action;
                        }

                        var yDistance = action.Target.Y - myPos.Y;
                        var xDistance = action.Target.X - myPos.X;
                        var angle = Math.Atan2(yDistance, xDistance);

                        int destX = (int)(myPos.X + (float)Math.Cos(angle) * Math.Min(action.Duration, 100));
                        int destY = (int)(myPos.Y + (float)Math.Sin(angle) * Math.Min(action.Duration, 100));
                        action.DrawPoint = new Vector2(destX, destY);

                    }
                }
                entity.Components.Remove(actionCompleted);
            }
        }
    }
}