using FarseerPhysics;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using SpaceX.bossWindow.boss;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.bossWindow
{
    class BossFire : GameObject
    {
        public RenderingComponent RC { set; get; }
        public PhysicsComponent PC { set; get; }
        public TimedDestructionComponent LC { set; get; }
        public Boss Boss { set; get; }
        public BossWindowData BWD { set ; get; }
        public Vector2 Direction { set; get; }
        
        public BossFire(BossWindowData BWD, Boss Boss, Vector2 Direction)
        {
            this.Boss = Boss;
            this.BWD = BWD;
            this.Direction = Direction;
            LC = new TimedDestructionComponent(BWD.BossFireDestroyTime, this);
            RC = new RenderingComponent(Boss.RC.Sprite.Position, BWD.BossFireTexture, BWD.BossFireSize, true);
            PC = new PhysicsComponent(ConvertUnits.ToDisplayUnits(Boss.PC.Body.Position), Converter.Vector(BWD.BossFireSize),null, BossWindow.World, true);
            PC.AddUserData(this, "BossFire");
            PC.Body.BodyType = BodyType.Dynamic;
            PC.Speed = BWD.BossFireSpeed;
            PC.Body.Enabled = false;
            PC.Body.CollisionCategories = Category.Cat4;
            PC.Body.CollidesWith = Category.Cat1 | Category.Cat2;
            PC.Body.IsBullet = true;
            PC.Body.Mass = BWD.BossFireMass;
            RC.AddPhysics(PC);


            this.AddComponent(RC);
            this.AddComponent(PC);
            this.AddComponent(LC);

        }

        public BossFire Clone(Vector2 Direction)
        {
            BossFire b = new BossFire(BWD, Boss, Direction);

            b.PC.Body.Enabled = true;

            return b;
        }

        public void Shoot()
        {
            LC.Start();
            PC.Move(Direction);
        }
    }
}
