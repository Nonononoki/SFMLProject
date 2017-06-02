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
        public BulletPhysicsComponent(GameWindowData gwd, GameObject go)
            : base(gwd.MyBulletPosition, gwd.MyBulletSize, gwd.MyBulletVertices, false)
        {
            Body.BodyType = BodyType.Dynamic;
            Body.IsBullet = true;
            Body.Enabled = false;
            Body.Mass = 1;
            Speed = gwd.MyBulletSpeed;

            AddUserData(go, "Bullet");
        }
    }
}
