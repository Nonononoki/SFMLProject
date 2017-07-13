using SFML.Graphics;
using SpaceX.component;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.bossWindow.boss
{
    class BossFirePillarLogicComponent : ILogicComponent
    {
        public Stopwatch SW { set; get; }
        public BossFirePillar Pillar { set; get; }
        public int SpawnTime { set; get; }
        public byte Transparency { set; get; }
        public Color DefaultColor { set; get; }

        public BossFirePillarLogicComponent(BossWindowData BWD, BossFirePillar Pillar)
        {
            Transparency = 100;
            //don't get hit by pillar for a short amount of time

            SpawnTime = BWD.BossFirePillarPhysicsDelay;
            this.Pillar = Pillar;
            DefaultColor = Pillar.RC.Sprite.Color;

            SW = new Stopwatch();
        }

        public void Destroy()
        {
            //throw new NotImplementedException();
            Pillar.RemoveComponent(this);
        }

        public void Update()
        {
            if(SW.ElapsedMilliseconds >= SpawnTime)
            {
                //time to attach body to pillar               
                Pillar.PC.Body.Enabled = true;
                Pillar.RC.Sprite.Color = DefaultColor;
                Destroy();
            }
            else
            {
                //make sprite even more transparent
                Pillar.RC.Sprite.Color = new SFML.Graphics.Color(Pillar.RC.Sprite.Color.R, 
                    Pillar.RC.Sprite.Color.G, Pillar.RC.Sprite.Color.B, Transparency);
            }
        }
    }
}
