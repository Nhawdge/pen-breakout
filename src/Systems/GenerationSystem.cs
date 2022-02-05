using System.Collections.Generic;
using PenBreakout.Entities;
using static PenBreakout.Entities.EntityService;

namespace PenBreakout.Systems
{
    public class GenerationSystem : Systems.System
    {
        public override void Load(Engine engine)
        {
            engine.Entities.Add(CreateHorse());
            engine.Entities.Add(CreateHorse());
            engine.Entities.Add(CreateHorse());

            engine.Entities.Add(CreatePig());
            engine.Entities.Add(CreatePig());
            engine.Entities.Add(CreatePig());
            engine.Entities.Add(CreatePig());


            engine.Entities.Add(CreateSellPoint());


            engine.Entities.Add(CreatePlayer());
        }

        public override void Update(List<Entity> allEntities)
        {
        }
    }
}