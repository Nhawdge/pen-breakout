using System.Collections.Generic;
using System.Linq;
using PenBreakout.Components;
using PenBreakout.Entities;
using static PenBreakout.Entities.EntityService;

namespace PenBreakout.Systems
{
    public class GenerationSystem : Systems.System
    {
        public Engine Engine { get; private set; }

        public override void Load(Engine engine)
        {
            Engine = engine;
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
            if (!allEntities.Any(x => x.GetComponent<FarmAi>() != null))
            {
                Engine.Entities.Add(CreateHorse());
                Engine.Entities.Add(CreateHorse());
                Engine.Entities.Add(CreateHorse());
                Engine.Entities.Add(CreatePig());
                Engine.Entities.Add(CreatePig());
            }
        }
    }
}