using System.Collections.Generic;
using PenBreakout.Entities;

namespace PenBreakout.Systems
{
    public abstract class System
    {
        public abstract void Load(Engine engine);
        public abstract void Update(List<Entity> allEntities);
    }
}

