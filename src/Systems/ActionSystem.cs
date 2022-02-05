using System.Threading;
using System.Collections.Generic;
using PenBreakout.Entities;
using PenBreakout.Components;
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
                var actions = entity.GetComponents<Action>();
                foreach (var action in actions)
                {
                    if (action.ActiveAction == Actions.Lasso)
                    {
                        action.Duration++;
                    }
                }
            }
        }
    }
}