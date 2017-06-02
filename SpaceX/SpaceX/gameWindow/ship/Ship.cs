using FarseerPhysics.Common;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Contacts;
using Microsoft.Xna.Framework;
using Newtonsoft.Json.Linq;
using SFML.Graphics;
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
        public ShipLogicComponent SLC { set; get; }
        public ShipPhysicsComponent SPC { set; get; }
        public RenderingComponent RC { set; get; }
        public ShipControllerComponent SCC { set; get; }

        public Ship(GameWindowData gwd) : base()
        {
            SLC = new ShipLogicComponent();
            SPC = new ShipPhysicsComponent(gwd, SLC);
            SPC.Speed = gwd.MyShipSpeed;
            SPC.AddUserData(this, "MyShip");
            RC = new RenderingComponent(Converter.Vector(gwd.MyShipPosition), gwd.MyShipTexture, Converter.Vector(gwd.MyShipSize), false);
            RC.AddPhysics(SPC);
            SCC = new ShipControllerComponent(SPC, gwd);
      
            this.AddComponent(SLC);
            this.AddComponent(SPC);
            this.AddComponent(RC);
            this.AddComponent(SCC);
        }
    }
}
