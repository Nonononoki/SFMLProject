using FarseerPhysics;
using Microsoft.Xna.Framework;
using SpaceX.component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.gameWindow
{
    class BulletLogicComponent : ILogicComponent
    {
        public Bullet Bullet { set; get; }

        public BulletLogicComponent(Bullet Bullet)
        {
            this.Bullet = Bullet;
        }
        public void Spawn()
        {
            Bullet.SW.Restart();

            //shoot upwards
            Bullet.BPC.Move(new Vector2(0, -1));

            Bullet.BPC.Body.Enabled = true;
            Bullet.RC.IsVisible = true;

            //move to the front of the ship relative to its size
            Bullet.BPC.Body.Position = Bullet.Ship.GetComponent<ShipPhysicsComponent>().Body.Position + ConvertUnits.ToSimUnits(Bullet.Position);

        }
        public void Reset()
        {
            //reset bullet after a certain time to reduce cpu usage
            Bullet.BPC.Body.LinearVelocity = new Vector2(0, 0);
            Bullet.BPC.Body.Enabled = false;
            Bullet.RC.IsVisible = false;
            Bullet.SW.Stop();
        }

        public void Update()
        {
            if (Bullet.SW.ElapsedMilliseconds >= Bullet.Duration)
            {
                Bullet.Reset();
            }
        }

        public void Destroy()
        {
        }
    }
}
