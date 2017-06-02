using FarseerPhysics;
using Microsoft.Xna.Framework;
using SFML.Window;
using SpaceX.component;
using SpaceX.window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SFML.Window.Keyboard;

namespace SpaceX.gameWindow
{
    class ShipControllerComponent : IControllerComponent
    {
        private ShipPhysicsComponent SPC;

        private Key Up;
        private Key Down;
        private Key Left;
        private Key Right;

        private Vector2 V_Up = new Vector2(0,-1);
        private Vector2 V_Down = new Vector2(0, 1);
        private Vector2 V_Left = new Vector2(-1, 0);
        private Vector2 V_Right = new Vector2(1, 0);
        private Vector2 Direction;

        public ShipControllerComponent(ShipPhysicsComponent SPC, GameWindowData GWD)
        {
            this.Up = GWD.Up;
            this.Down = GWD.Down;
            this.Left = GWD.Left;
            this.Right = GWD.Right;
            this.SPC = SPC;

            Direction = new Vector2(0, 0);
        }
        public void Destroy()
        {
            
        }

        public void Update()
        {
            SPC.Body.LinearVelocity = new Vector2(0, 0);

            //move Ship when key is pressed
            if (Keyboard.IsKeyPressed(Up) && ConvertUnits.ToDisplayUnits(SPC.Body.Position.Y) > 0)
            {
                Direction += V_Up;
            }
            if (Keyboard.IsKeyPressed(Down) && ConvertUnits.ToDisplayUnits(SPC.Body.Position.Y) < Program.Window.Size.Y)
            {
                Direction += V_Down;
            }
            if (Keyboard.IsKeyPressed(Left) && ConvertUnits.ToDisplayUnits(SPC.Body.Position.X) > 0)
            {
                Direction += V_Left;
            }
            if (Keyboard.IsKeyPressed(Right) && ConvertUnits.ToDisplayUnits(SPC.Body.Position.X) < Program.Window.Size.X)
            {
                Direction += V_Right;
            }

            SPC.Move(Direction);
            Direction = new Vector2(0, 0);

        }
    }
}
