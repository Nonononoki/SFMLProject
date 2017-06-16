using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using System.Diagnostics;
using SpaceX.component;

namespace SpaceX.gameOverWindow
{
    class AnimationComponent : IComponent
    {
        public int Speed { set; get; } //number of milliseconds to change to next sprite
        public bool Running { set; get; }
        public Sprite[] Sprites { set; get; }
        public RenderingComponent RC { set; get; }
        public IAnimationLogicComponent ALC { set; get; }
        public int CurrentSpriteNumber { set; get; }
        public Stopwatch SW { set; get; }
        public bool Looping { set; get; }
        public Sprite OriginalSprite { set; get; }

        public AnimationComponent(Sprite[] Sprites, int Speed, RenderingComponent RC, IAnimationLogicComponent ALC, bool Looping)
        {
            Running = false;
            CurrentSpriteNumber = 0;

            this.Looping = Looping;
            this.Sprites = Sprites;
            this.Speed = Speed;
            this.RC = RC;
            this.OriginalSprite = RC.Sprite;
            this.ALC = ALC;

            SW = new Stopwatch();
            SW.Start();
        }

        public void Start()
        {
            SW.Start();
            Running = true;
        }

        public void Stop()
        {
            SW.Reset();
            Running = false;
            CurrentSpriteNumber = 0;
        }

        public void Update()
        {
            if (SW.ElapsedMilliseconds >= Speed && Running)
            {
                RC.Sprite.Origin = new Vector2f(this.Sprites[CurrentSpriteNumber].Texture.Size.X / 2, this.Sprites[CurrentSpriteNumber].Texture.Size.Y / 2);
                RC.Sprite.Texture = Sprites[CurrentSpriteNumber].Texture;
                RC.Sprite = OriginalSprite;

                //next sprite
                CurrentSpriteNumber++;

                if (CurrentSpriteNumber >= Sprites.Length && !Looping)
                {
                    //stop animation if no loop
                    Stop();
                    //RC.Sprite.Texture = OriginalSprite.Texture;
                    ALC.AfterAnimation();
                }

                else if (CurrentSpriteNumber >= Sprites.Length)
                    CurrentSpriteNumber = 0;

                if(Running)
                    SW.Restart();
            }
        }

        public void Destroy()
        {
        }
    }
}
