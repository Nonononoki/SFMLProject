using FarseerPhysics.Common;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Contacts;
using Microsoft.Xna.Framework;
using Newtonsoft.Json.Linq;
using SFML.Graphics;
using SFML.System;
using SpaceX.component;
using SpaceX.gameWindow;
using SpaceX.window;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.gameObject
{
    class Ship : GameObject
    {
        public Vector2 Position { set; get; }
        public ShipLogicComponent SLC { set; get; }
        public ShipPhysicsComponent SPC { set; get; }
        public RenderingComponent RC { set; get; }
        public ShipControllerComponent SCC { set; get; }
        public  BulletSpawner BulletSpawner { set; get; }
        public AudioComponent ShipHitAudio { set; get; }

        public Ship(GameWindowData gwd) : base()
        {
            Position = Converter.RelativeWindow(gwd.MyShipPosition);
            SLC = new ShipLogicComponent(this);
            SPC = new ShipPhysicsComponent(gwd, SLC, this);
            SPC.AddUserData(this, "MyShip");
            RC = new RenderingComponent(new Vector2f(0,0), gwd.MyShipTexture, Converter.Vector(gwd.MyShipSize), false);
            RC.AddPhysics(SPC);
            SCC = new ShipControllerComponent(SPC, gwd);
            ShipHitAudio = new AudioComponent(gwd.ShipHitPath, false);

            BulletSpawner = new BulletSpawner(gwd, this);

            this.AddComponent(SLC);
            this.AddComponent(SPC);
            this.AddComponent(RC);
            this.AddComponent(SCC);
            this.AddComponent(BulletSpawner);
            this.AddComponent(ShipHitAudio);
        }
    }
}
