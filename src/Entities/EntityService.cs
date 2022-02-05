using System;
using PenBreakout.Components;

namespace PenBreakout.Entities
{
    public static class EntityService
    {
        public static Entity CreateHorse()
        {
            var entity = new Entity();
            var rand = new Random();

            entity.Components.Add(new Position { X = rand.Next(100, 500), Y = rand.Next(100, 500) });
            entity.Components.Add(new Render("src/Assets/horse.png"));
            entity.Components.Add(new FarmAi());

            return entity;
        }

        public static Entity CreatePig()
        {
            var entity = new Entity();
            var rand = new Random();

            entity.Components.Add(new Position { X = rand.Next(100, 300), Y = rand.Next(100, 300) });
            entity.Components.Add(new Render("src/Assets/pig.png"));
            entity.Components.Add(new FarmAi());

            return entity;
        }

        public static Entity CreatePlayer()
        {
            var entity = new Entity();
            var rand = new Random();

            entity.Components.Add(new Position { X = rand.Next(100, 300), Y = rand.Next(100, 300), Speed = 5 });
            entity.Components.Add(new Render("src/Assets/rancher.png"));
            entity.Components.Add(new Controllable());

            return entity;
        }
    }
}