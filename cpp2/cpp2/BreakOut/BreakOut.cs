using FarseerPhysics.Collision.Shapes;
using FarseerPhysics.Common;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using SFML.Graphics;
using SFML.System;
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

        //World, no gravity
        World world = new World(new Vector2(0,0));

        DeltaTime dt;

        int lives = 3;
        int score = 0;

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
        float ballPaddleDistance; //distance when ball is sticky

        //walls
        const float wallThickness = 30;
        BreakOutWall wallTop;
        Vector2 wallTopPosition;
        Texture wallTopTexture;
        Vertices wallTopVertices;
        Vector2 wallTopSize;

        BreakOutWall wallLeft;
        Vector2 wallLeftPosition;
        Texture wallSideTexture;
        Vertices wallSideVertices;
        Vector2 wallSideSize;

        BreakOutWall wallRight;
        Vector2 wallRightPosition;


        public BreakOut()
        {
            dt = new DeltaTime();

            // Limit the framerate to 60 frames per second
            window.SetFramerateLimit(60);

            canvas = new BreakOutCanvas(0 , windowHeight, 0 , windowWidth);

            //paddle attributes
            paddleSize = new Vector2(200,20);
            paddleVertices = GameObject.RechtangleVertices(paddleSize);
            paddlePosition = new Vector2(canvas.Right/2, canvas.Bottom);
            paddleTexture = new Texture("../../../sprites/breakOut/paddle.png");
            paddle = new BreakOutPaddle(wallThickness, windowWidth - wallThickness);
            paddle.Set(paddlePosition, paddleTexture, paddleVertices, paddleSize, ref world);
            paddle.Speed = 300f;
            paddle.Body.Mass = 1f; 

            //ball attributes
            ballSize = new Vector2(50, 50);
            ballPaddleDistance = 2 * ballSize.X;
            ballPosition = new Vector2(canvas.Right / 2 , canvas.Bottom - ballPaddleDistance);
            ballTexture = new Texture("../../../sprites/breakOut/ball.png");
            ball = new BreakOutBall();
            ball.Set(ballPosition, ballTexture, ballSize, ref world);
            ball.Speed = 30f;
            ball.Body.Mass = 1f;
            ball.EnableCollision();

            //wall attributes
            wallTopPosition = new Vector2(canvas.Right / 2, canvas.Top);
            wallTopSize = new Vector2(windowWidth, wallThickness);
            wallTopVertices = GameObject.RechtangleVertices(wallTopSize);
            wallTopTexture = new Texture("../../../sprites/breakOut/wall_horizontal.png");
            wallTop = new BreakOutWall();
            wallTop.Set(wallTopPosition, wallTopTexture, wallTopVertices, wallTopSize, ref world);
            wallTop.Body.BodyType = BodyType.Static;            

            wallLeftPosition = new Vector2(canvas.Left, canvas.Bottom / 2);
            wallSideSize = new Vector2(wallThickness, windowHeight);
            wallSideVertices = GameObject.RechtangleVertices(wallSideSize);
            wallSideTexture = new Texture("../../../sprites/breakOut/wall_vertical.png");
            wallLeft = new BreakOutWall();
            wallLeft.Set(wallLeftPosition, wallSideTexture, wallSideVertices, wallSideSize, ref world);
            wallLeft.Body.BodyType = BodyType.Static;

            wallRightPosition = new Vector2(canvas.Right, canvas.Bottom / 2);
            wallRight = new BreakOutWall();
            wallRight.Set(wallRightPosition, wallSideTexture, wallSideVertices, wallSideSize, ref world);
            wallRight.Body.BodyType = BodyType.Static;
            

            Run();
        }
        
        public void Update(DeltaTime dt)
        {
            Events();

            //moving bodies
            ball.Move(dt.Time);
        }

        public void Events()
        {

            paddle.Body.LinearVelocity = new Vector2(0, 0);
            if (ball.Sticky) ball.Direction = new Vector2(0, 0);

            //key press events
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                paddle.MoveLeft(dt, ball, ballPaddleDistance);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                paddle.MoveRight(dt, ball, ballPaddleDistance);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
            {
                if (ball.Sticky) ball.Launch();
            }


            //Lose when ball touches bottomcanvas
            if(ball.Position.Y + ball.Size.X > canvas.Bottom)
            {
                if (lives > 0)
                {
                    lives--;
                    ball.Reset(ballPosition);
                    paddle.Reset(paddlePosition);
                }
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

                //Farseer Physics
                world.Step(dt.Time);

                window.Clear(Color.Black);
                window.DispatchEvents();
                window.Closed += (sender, evtArgs) => running = false;

                foreach (GameObject go in GameObject._list)
                {
                    window.Draw(go.Sprite);
                }

                window.Display();

                dt.Stop();
            }

            world.Clear();
            window.Close();
        }
    }
}
