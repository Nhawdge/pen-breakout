using Raylib_cs;
using TemplateProject.Entities;
using TemplateProject.Systems;
using Raylib = Raylib_cs.Raylib;

public class Engine
{
    public List<Entity> Entities = new List<Entity>();
    public List<TemplateProject.Systems.System> Systems = new List<TemplateProject.Systems.System>();

    public void Run()
    {
        Load();
        GameLoop();
    }

    private void Load()
    {
        Systems.Add(new RenderingSystem());
    }

    public void GameLoop()
    {
        Raylib.InitWindow(1366, 768, "Template"); // change to 16:9

        Raylib.SetTargetFPS(30);
        var game = new Engine();
        Camera2D camera = new Camera2D();
        camera.zoom = 1;

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.BeginMode2D(camera);
            Raylib.ClearBackground(Color.WHITE);

            game.Update();

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