using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarseerPhysics.Common;
using Microsoft.Xna.Framework;
using FarseerPhysics.Dynamics;
using SpaceX.window;

namespace SpaceX.gameWindow
{
    class BulletPhysicsComponent : PhysicsComponent
    {
        public BulletPhysicsComponent(GameWindowData gwd, Bullet Bullet)
            : base(Bullet.Position, gwd.MyBulletSize, gwd.MyBulletVertices, GameWindow.World, false)
        {
            Body.BodyType = BodyType.Dynamic;
            Body.IsBullet = true;
            Body.Mass = gwd.MyBulletMass;
            Speed = gwd.MyBulletSpeed;

            AddUserData(Bullet, "Bullet");

            Body.CollisionCategories = Category.Cat3;
            Body.CollidesWith = Category.Cat2;
        }
    }
}
