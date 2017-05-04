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
        const int windowHeight = 800;
        const int windowWidth = 800;
        RenderWindow window = new RenderWindow(new VideoMode(windowWidth, windowHeight), "BreakOut", Styles.Default);

        const float density = 1f;

        BreakOutCanvas canvas;
        float canvasPadding = 10f;

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

            // Limit the framerate to 60 frames per second
            window.SetFramerateLimit(60);

            canvas = new BreakOutCanvas(0 + canvasPadding, windowHeight - canvasPadding, 0 + canvasPadding, windowWidth - canvasPadding);

            //paddle attributes
            paddleSize = new Vector2(200,20);
            paddleVertices = new Vertices();
            paddleVertices.Add(new Vector2(paddleSize.X/2, paddleSize.Y / 2));
            paddleVertices.Add(new Vector2(paddleSize.X / 2, -paddleSize.Y / 2));
            paddleVertices.Add(new Vector2(-paddleSize.X / 2, paddleSize.Y / 2));
            paddleVertices.Add(new Vector2(-paddleSize.X / 2, -paddleSize.Y / 2));
            paddlePosition = new Vector2(canvas.Right/2 + paddleSize.X/2, canvas.Bottom - paddleSize.Y / 2);
            paddleTexture = new Texture("../../../sprites/breakOut/paddle.png");
            paddle = new BreakOutPaddle(canvasPadding, windowWidth - canvasPadding);
            paddle.Set(paddlePosition, paddleTexture, paddleVertices, paddleSize, ref world);
            paddle.Speed = 300f;

            ballSize = new Vector2(50, 50);
            ballPosition = new Vector2(canvas.Right / 2 + paddleSize.X / 2, canvas.Bottom - paddleSize.Y / 2 - ballSize.X);
            ballTexture = new Texture("../../../sprites/breakOut/ball.png");
            ball = new BreakOutBall();
            ball.Set(ballPosition, ballTexture, ballSize, ref world);
            ball.Speed = 300f;

            Run();
        }
        
        public void Update(DeltaTime dt)
        {
            Events();
        }

        public void Events()
        {
            //key press events
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
            //main game loop
            bool running = true;

            while(running)
            {
                dt.Start();

                Update(dt);

                window.Clear(Color.Black);
                window.DispatchEvents();
                window.Closed += (sender, evtArgs) => running = false;

                //draw stuff
                window.Draw(paddle.Sprite);
                window.Draw(ball.Sprite);


                window.Display();

                dt.Stop();

            }

            window.Close();
        }
    }
}
