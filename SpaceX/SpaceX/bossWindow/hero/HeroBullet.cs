using FarseerPhysics;
using FarseerPhysics.Common;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.bossWindow.hero
{
    class HeroBullet : GameObject
    {
        public RenderingComponent RC { set; get; }
        public PhysicsComponent PC { set; get; }
        public HeroBulletLogic LC { set; get; }
        public BossHero Hero { set; get; }
        public BossWindowData BWD { set; get; }
        public Vector2 Direction { set; get; }

        public HeroBullet(BossWindowData BWD, BossHero Hero, Vector2 Direction)
        {
            this.Hero = Hero;
            this.BWD = BWD;
            this.Direction = Direction;

            LC = new HeroBulletLogic(BWD.HeroBulletDestroyTime, this);
            RC = new RenderingComponent(Hero.RC.Sprite.Position, BWD.HeroBulletTexture, BWD.HeroBulletSize, false);
            Vertices v = PhysicsComponent.RechtangleVertices(Converter.RelativeWindow(Converter.Vector(BWD.HeroBulletSize)));
            PC = new PhysicsComponent(ConvertUnits.ToDisplayUnits(Hero.PC.Body.Position), Converter.Vector(BWD.HeroBulletSize), v, BossWindow.World, false);
            PC.AddUserData(this, "HeroBullet");
            PC.Body.BodyType = BodyType.Dynamic;
            PC.Speed = BWD.HeroBulletSpeed;
            PC.Body.CollisionCategories = Category.Cat2;
            PC.Body.CollidesWith = Category.Cat3 | Category.Cat4;
            PC.Body.IsBullet = true;
            PC.Body.Mass = BWD.HeroBulletMass;
            RC.AddPhysics(PC);

            this.AddComponent(RC);
            this.AddComponent(PC);
            this.AddComponent(LC);

        }

        public HeroBullet Clone(Vector2 Direction)
        {
            return new HeroBullet(BWD, Hero, Direction);
        }

        public void FireBullet()
        {
            LC.Start();
            HeroBullet nBullet = this.Clone(Hero.FacingDirection);
            nBullet.PC.Move(Hero.FacingDirection);
            BossWindow.MyGameObjects.Add(nBullet);
        }
    }
}
