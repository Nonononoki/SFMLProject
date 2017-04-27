using FarseerPhysics.Collision.Shapes;
using FarseerPhysics.Common;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using SFML.Graphics;
using SFML.Window;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gpp2.BrickBreak
{
    class BrickBreak
    {
        //initialize window
        const int windowHeight = 1400;
        const int windowWidth = 1400;
        RenderWindow brickBreakWindow = new RenderWindow(new VideoMode(windowWidth, windowHeight), "BrickBreak", Styles.Default);

        //World, no gravity
        World world = new World(new Vector2(0,0));

        DeltaTime dt;

        //paddle
        Vector2 paddleSize = new Vector2(200, 20);
        Vector2 paddlePos;
        Body paddleBody;
        BrickBreakPaddle paddle;
        RectangleShape myPaddle;


        public BrickBreak()
        {

        }

        public void Start()
        {
            dt = new DeltaTime();

            //paddle
            paddlePos = new Vector2(windowHeight, windowWidth - (paddleSize.X/2));
            paddleBody = new Body(world, paddlePos);
            paddleBody.Position = paddlePos;

            Vertices paddleVerticies = new Vertices(4);

            //testing values
            paddleVerticies.Add(new Vector2(2.6f, 0.10f));
            paddleVerticies.Add(new Vector2(2.375f, 0.46f));
            paddleVerticies.Add(new Vector2(0.58f, 0.92f));
            paddleVerticies.Add(new Vector2(0.46f, 0.72f));
            PolygonShape paddleShape = new PolygonShape(paddleVerticies, 1f);



        }

        public void Update()
        {

        }

        public void Events()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                paddle.MoveLeft(dt);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                paddle.MoveRight(dt);
            }
        }

        public void Run()
        {
            bool running = true;

            while(running)
            {
                dt.Start();

                brickBreakWindow.Clear(Color.Black);
                brickBreakWindow.DispatchEvents();
                brickBreakWindow.Closed += (sender, evtArgs) => running = false;

                //draw stuff
                brickBreakWindow.Draw(myPaddle);


                dt.Stop();

            }
        }
    }
}
