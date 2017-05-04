using FarseerPhysics.Collision.Shapes;
using FarseerPhysics.Common;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using SFML.Graphics;
using SFML.Window;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gpp2.BreakOut
{
    class BreakOut
    {
        //initialize window
        const int windowHeight = 1400;
        const int windowWidth = 1400;
        RenderWindow window = new RenderWindow(new VideoMode(windowWidth, windowHeight), "BreakOut", Styles.Default);

        const float density = 1f;
        BreakOutCanvas canvas;

        //World, no gravity
        World world = new World(new Vector2(0,0));

        DeltaTime dt;

        //paddle
        BreakOutPaddle paddle;
        Vector2 paddlePosition;
        Texture paddleTexture;
        Vertices paddleVertices;
        Vector2 paddleSize;

        //ball
        BreakOutBall ball;
        Vector2 ballPosition;
        Texture ballTexture;
        Vector2 ballSize;

        public BreakOut()
        {
            dt = new DeltaTime();

            canvas = new BreakOutCanvas(0, windowHeight, 0, windowWidth);

            //paddle attributes
            paddleSize = new Vector2(4,2);
            paddleVertices.Add(new Vector2(paddleSize.X/2, paddleSize.Y / 2));
            paddleVertices.Add(new Vector2(paddleSize.X / 2, -paddleSize.Y / 2));
            paddleVertices.Add(new Vector2(-paddleSize.X / 2, paddleSize.Y / 2));
            paddleVertices.Add(new Vector2(-paddleSize.X / 2, -paddleSize.Y / 2));
            paddlePosition = new Vector2(canvas.Right/2 + paddleSize.X/2, 0 - paddleSize.Y / 2);
            paddleTexture = new Texture("../../../sprites/breakOut/paddle.png");
            paddle = new BreakOutPaddle(0, windowWidth);
            paddle.Set(paddlePosition, paddleTexture, paddleVertices, paddleSize, ref world);

            Run();

        }

        public void Update()
        {
            Events();

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

                Update();

                breakOutWindow.Clear(Color.Black);
                breakOutWindow.DispatchEvents();
                breakOutWindow.Closed += (sender, evtArgs) => running = false;

                //draw stuff
                breakOutWindow.Draw(myPaddle);


                dt.Stop();

            }
        }
    }
}
