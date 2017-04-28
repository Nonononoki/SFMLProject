using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gpp2.Pong
{
    class Pong
    {
        // all needed variables

        //deltatime for continious and accurate movement
        DeltaTime dt = new DeltaTime();

        //initialize window
        const int windowHeight = 800;
        const int windowWidth = 1400;
        RenderWindow pongWindow = new RenderWindow(new VideoMode(windowWidth, windowHeight), "Pong", Styles.Default);

        //initialize canvas
        const int padding = 10;
        PongCanvas canvas = new PongCanvas(padding * 2, windowHeight - padding * 2, padding * 2, windowWidth - padding * 2, padding);
        RectangleShape myCanvas = new RectangleShape();

        //initialize ball
        float ballSpeed = 400f;
        PongBall ball;
        CircleShape myBall = new CircleShape();

        //Paddle
        float paddleMinHeight;
        float paddleMaxHeight;

        //initialize myPaddle
        float myPaddleHeight = 100f;
        float myPaddleWidth = 10f;
        float myPaddleSpeed = 800f;
        Vector2f myPaddlePos; 
        PongMyPaddle myPaddle; 

        RectangleShape myMyPaddle = new RectangleShape();

        //initialize foePaddle
        float foePaddleHeight = 100f;
        float foePaddleWidth = 10f;
        float foePaddleSpeed = 800f;
        Vector2f foePaddlePos; 
        PongFoePaddle foePaddle; 

        RectangleShape myFoePaddle = new RectangleShape();

        //Score variables
        Font font = new Font("../../../fonts/pixel.ttf");
        Color fontColor = new Color(255, 255, 255, 100);
        uint fontSize = 60;

        //initialize myScore
        PongScore myScore = new PongScore();
        Text myMyScore = new Text();

        //initialize foeScore
        PongScore foeScore = new PongScore();
        Text myFoeScore = new Text();

        public Pong()
        {
            Start();
            Run();
        }

        //load game with custom values
        public Pong(PongValues pv)
        {
            ballSpeed = pv.BallSpeed;
            myPaddleHeight = pv.MyPaddleHeight;
            myPaddleSpeed = pv.MyPaddleSpeed;
            foePaddleHeight = pv.FoePaddleHeight;
            foePaddleSpeed = pv.FoePaddleSpeed;

            Start();
            Run();
        }

        public void Start()
        {
            //initialization of almost all variables!

            myCanvas.Size = new Vector2f(canvas.Right, canvas.Bottom);
            myCanvas.Position = new Vector2f(canvas.Padding, canvas.Padding);
            myCanvas.OutlineThickness = 1;
            myCanvas.OutlineColor = Color.White;
            myCanvas.FillColor = Color.Black;

            ball = new PongBall(ballSpeed);
            ball.Radius = 5;
            ball.Respawn(windowWidth, windowHeight); //spawn ball for first game

            myBall.FillColor = Color.White;
            myBall.Radius = ball.Radius;
            myBall.Origin = new Vector2f(ball.Radius, ball.Radius);

            paddleMinHeight = 0 + canvas.Padding;
            paddleMaxHeight = windowHeight - canvas.Padding;

            myPaddlePos = new Vector2f(windowWidth - 2 * canvas.Padding, windowHeight / 2);
            myPaddle = new PongMyPaddle(myPaddleWidth, myPaddleHeight, myPaddleSpeed, myPaddlePos);

            myPaddle.MaxHeight = paddleMaxHeight;
            myPaddle.MinHeight = paddleMinHeight;

            myMyPaddle.FillColor = Color.White;
            myMyPaddle.Origin = new Vector2f(myPaddle.Width / 2, myPaddle.Height / 2);
            myMyPaddle.Size = new Vector2f(myPaddle.Width, myPaddle.Height);


            foePaddlePos = new Vector2f(0 + 2 * canvas.Padding, windowHeight / 2);
            foePaddle = new PongFoePaddle(foePaddleWidth, foePaddleHeight, foePaddleSpeed, foePaddlePos);

            foePaddle.MaxHeight = paddleMaxHeight;
            foePaddle.MinHeight = paddleMinHeight;

            myFoePaddle.FillColor = Color.White;
            myFoePaddle.Origin = new Vector2f(foePaddle.Width / 2, foePaddle.Height / 2);
            myFoePaddle.Size = new Vector2f(foePaddle.Width, foePaddle.Height);

            myMyScore.Position = new Vector2f(windowWidth * 0.75f, 3 * canvas.Padding);
            myMyScore.Color = fontColor;
            myMyScore.Font = font;
            myMyScore.CharacterSize = fontSize;

            myFoeScore.Position = new Vector2f(windowWidth * 0.25f, 3 * canvas.Padding);
            myFoeScore.Color = fontColor;
            myFoeScore.Font = font;
            myFoeScore.CharacterSize = fontSize;
        }

        public void Update(DeltaTime dt)
        {
            AI(dt);
            Events(dt);

            if (ball.CanvasRightCollision(canvas))
            {
                ball.Respawn(windowWidth, windowHeight);
                foeScore.Value++;
            }

            if (ball.CanvasLeftCollision(canvas))
            {
                ball.Respawn(windowWidth, windowHeight);
                myScore.Value++;
            }

            ball.CanvasTopBottomCollision(canvas);

            ball.PaddleCollision(foePaddle, true);
            ball.PaddleCollision(myPaddle, false);

            ball.Pos += ball.Mov * ball.Speed * dt.Time;

            myBall.Position = ball.Pos;
            myMyPaddle.Position = myPaddle.Pos;
            myFoePaddle.Position = foePaddle.Pos;
            myMyScore.DisplayedString = myScore.Value.ToString();
            myFoeScore.DisplayedString = foeScore.Value.ToString();
        }

        public void Run()
        {
            //Start();

            bool running = true;
            while (running)
            {
                dt.Start();

                Update(dt);

                pongWindow.Clear(Color.Black);
                pongWindow.DispatchEvents();
                pongWindow.Closed += (sender, evtArgs) => running = false;

                //draw canvas
                pongWindow.Draw(myCanvas);

                //draw ball
                pongWindow.Draw(myBall);

                //draw myPaddle
                pongWindow.Draw(myMyPaddle);

                //draw foePaddle
                pongWindow.Draw(myFoePaddle);

                //draw myScore
                pongWindow.Draw(myMyScore);

                //draw foeScore
                pongWindow.Draw(myFoeScore);

                //display window
                pongWindow.Display();

                dt.Stop();
            }

            pongWindow.Close();
        }

        //my movements
        public void Events(DeltaTime dt)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
            {
                myPaddle.MoveUp(dt);
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
            {
                myPaddle.MoveDown(dt);
            }
        }

        //ai movements
        void AI(DeltaTime dt)
        {
            //move paddle down
            if (foePaddle.Pos.Y > ball.Pos.Y)
            {
                foePaddle.MoveUp(dt);
            }
            else if (foePaddle.Pos.Y < ball.Pos.Y)
            {
                foePaddle.MoveDown(dt);
            }
        }

    }

    
}
