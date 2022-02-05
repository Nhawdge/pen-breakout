using Raylib_cs;
using PenBreakout.Entities;
using PenBreakout.Systems;
using Raylib = Raylib_cs.Raylib;
using System.Collections.Generic;
using PenBreakout.Components;

public class Engine
{
    public List<Entity> Entities = new List<Entity>();
    public List<PenBreakout.Systems.System> Systems = new List<PenBreakout.Systems.System>();
    public Entity Singleton { get; set; }

    public void Run()
    {
        Load();
        GameLoop();
    }

    private void Load()
    {
        Systems.Add(new RenderingSystem());
        Systems.Add(new GenerationSystem());
        Systems.Add(new AiMovementSystem());
        Systems.Add(new ControllableSystem());
        Systems.Add(new ActionSystem());
        Systems.Add(new SellingSystem());

        var singleton = new Entity();
        singleton.Components.Add(new Singleton());
    }

    public void GameLoop()
    {
        Raylib.InitWindow(800, 800, "Template");

        foreach (var system in Systems)
        {
            system.Load(this);
        }

        Raylib.SetTargetFPS(30);
        Camera2D camera = new Camera2D();
        camera.zoom = 1;

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.BeginMode2D(camera);
            Raylib.ClearBackground(Color.WHITE);

            Update();

            Raylib.EndMode2D();
            Raylib.EndDrawing();

        }
        Raylib.CloseWindow();

    }
    private void Update()
    {
        foreach (var system in Systems)
        {
            system.Update(Entities);
        }
    }
}