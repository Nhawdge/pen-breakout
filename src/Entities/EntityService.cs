using System;
using PenBreakout.Components;
using Raylib_cs;

namespace PenBreakout.Entities
{
    public static class EntityService
    {
        public static Entity CreateHorse()
        {
            var entity = new Entity();
            var rand = new Random();

            entity.Components.Add(new Position { X = rand.Next(100, 500), Y = rand.Next(100, 500), Width = 64, Height = 64 });
            entity.Components.Add(new Render("src/Assets/horse.png"));
            entity.Components.Add(new FarmAi());

            return entity;
        }

        public static Entity CreatePig()
        {
            var entity = new Entity();
            var rand = new Random();

            entity.Components.Add(new Position { X = rand.Next(100, 300), Y = rand.Next(100, 300), Width = 64, Height = 64 });
            entity.Components.Add(new Render("src/Assets/pig.png"));
            entity.Components.Add(new FarmAi());

            return entity;
        }

        public static Entity CreatePlayer()
        {
            var entity = new Entity();
            var rand = new Random();

            entity.Components.Add(new Position { X = rand.Next(100, 300), Y = rand.Next(100, 300), Speed = 5, Width = 64, Height = 64 });
            entity.Components.Add(new Render("src/Assets/rancher.png"));
            entity.Components.Add(new Controllable());

            return entity;
        }

        public static Entity CreateSellPoint()
        {
            var entity = new Entity();
            var rand = new Random();

            entity.Components.Add(new Position { X = rand.Next(0, 50), Y = rand.Next(00, 750), Width = 64, Height = 64 });
            entity.Components.Add(new Render("src/Assets/sellsquare.png"));
            entity.Components.Add(new SellSquare());

            return entity;
        }
    }
}