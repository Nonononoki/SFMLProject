using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using System.Diagnostics;

namespace SpaceX.gameOverWindow
{
    class AnimationComponent : IComponent
    {
        public int Speed { set; get; } //number of milliseconds to change to next sprite
        public bool Running { set; get; }
        public Sprite[] Sprites { set; get; }
        public RenderingComponent RC { set; get; }
        public int CurrentSpriteNumber { set; get; }
        public Stopwatch SW { set; get; }

        public AnimationComponent(Sprite[] Sprites, int Speed, RenderingComponent RC)
        {
            Running = true;
            CurrentSpriteNumber = 0;
            this.Sprites = Sprites;
            this.Speed = Speed;
            this.RC = RC;

            SW = new Stopwatch();
            SW.Start();
        }

        public void Update()
        {
            if (SW.ElapsedMilliseconds >= Speed)
            {
                RC.Sprite = Sprites[CurrentSpriteNumber];

                //next sprite
                CurrentSpriteNumber++;
                if (CurrentSpriteNumber >= Sprites.Length)
                    CurrentSpriteNumber = 0;

                SW.Restart();
            }
        }

        public void Destroy()
        {
        }
    }
}
