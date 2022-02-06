using System.Collections;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Collections.Generic;
using PenBreakout.Entities;
using Raylib_cs;

namespace PenBreakout.Systems
{
    public class SoundSystem : System
    {
        Music BackgroundMusic { get; set; }

        public override void Load(Engine engine)
        {
            Raylib_cs.Raylib.InitAudioDevice();
            BackgroundMusic = Raylib.LoadMusicStream("src/assets/background-noise.wav");
            Raylib.SetMusicVolume(BackgroundMusic, 0.1f);
            Raylib.PlayMusicStream(BackgroundMusic);
        }

        public override void Update(List<Entity> allEntities)
        {
            Raylib.UpdateMusicStream(BackgroundMusic);
        }
    }
}