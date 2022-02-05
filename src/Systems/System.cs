using System.Collections.Generic;
using TemplateProject.Entities;

namespace TemplateProject.Systems
{
    public abstract class System
    {
        public abstract void Load(Engine engine);
        public abstract void Update(List<Entity> allEntities);
    }
}

