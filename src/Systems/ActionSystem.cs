using System.Collections.Generic;
using PenBreakout.Entities;
using PenBreakout.Components;

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
                var actions = entity.GetComponents<Action>();
                Action actionCompleted = null;
                foreach (var action in actions)
                {
                    if (action.ActiveAction == Actions.Lasso)
                    {
                        action.Duration += action.CountDirection;
                        if (action.Duration > 100)
                        {
                            action.CountDirection = -5;
                        }
                        if (action.Duration < 0)
                        {
                            actionCompleted = action;
                        }
                    }
                }
                entity.Components.Remove(actionCompleted);
            }
        }
    }
}