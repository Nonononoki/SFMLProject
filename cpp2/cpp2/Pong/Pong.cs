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
        const int windowHeight = 400;
        const int windowWidth = 700;
        RenderWindow pongWindow = new RenderWindow(new VideoMode(windowWidth, windowHeight), "Pong", Styles.Default);

        //initialize canvas
        const int padding = 5;
        Canvas canvas = new Canvas(padding * 2, windowHeight - padding * 2, padding * 2, windowWidth - padding * 2, padding);
        RectangleShape myCanvas = new RectangleShape();

        //initialize ball
        const float ballSpeed = 200f;
        Ball ball = new Ball(ballSpeed);
        CircleShape myBall = new CircleShape();

        //Paddle
        float paddleMinHeight;
        float paddleMaxHeight;

        //initialize myPaddle
        const float myPaddleHeight = 50f;
        const float myPaddleWidth = 3f;
        const float myPaddleSpeed = 400f;
        Vector2f myPaddlePos; 
        MyPaddle myPaddle; 

        RectangleShape myMyPaddle = new RectangleShape();

        //initialize foePaddle
        const float foePaddleHeight = 50f;
        const float foePaddleWidth = 3f;
        const float foePaddleSpeed = 400f;
        Vector2f foePaddlePos; 
        FoePaddle foePaddle; 

        RectangleShape myFoePaddle = new RectangleShape();

        //Score variables
        Font font = new Font("../../../fonts/pixel.ttf");
        Color fontColor = new Color(255, 255, 255, 100);
        uint fontSize = 32;

        //initialize myScore
        Score myScore = new Score();
        Text myMyScore = new Text();

        //initialize foeScore
        Score foeScore = new Score();
        Text myFoeScore = new Text();

        public Pong()
        {
            //initialization of almost all variables!

            myCanvas.Size = new Vector2f(canvas.right, canvas.bottom);
            myCanvas.Position = new Vector2f(canvas.padding, canvas.padding);
            myCanvas.OutlineThickness = 1;
            myCanvas.OutlineColor = Color.White;
            myCanvas.FillColor = Color.Black;

            ball.radius = 5;
            ball.Respawn(windowWidth, windowHeight); //spawn ball for first game

            myBall.FillColor = Color.White;
            myBall.Radius = ball.radius;
            myBall.Origin = new Vector2f(ball.radius, ball.radius);

            paddleMinHeight = 0 + canvas.padding;
            paddleMaxHeight = windowHeight - canvas.padding;

            myPaddlePos = new Vector2f(windowWidth - 2 * canvas.padding, windowHeight / 2);
            myPaddle = new MyPaddle(myPaddleWidth, myPaddleHeight, myPaddleSpeed, myPaddlePos);

            myPaddle.maxHeight = paddleMaxHeight;
            myPaddle.minHeight = paddleMinHeight;

            myMyPaddle.FillColor = Color.White;
            myMyPaddle.Origin = new Vector2f(myPaddle.width / 2, myPaddle.height / 2);
            myMyPaddle.Size = new Vector2f(myPaddle.width, myPaddle.height);


            foePaddlePos = new Vector2f(0 + 2 * canvas.padding, windowHeight / 2);
            foePaddle = new FoePaddle(foePaddleWidth, foePaddleHeight, foePaddleSpeed, foePaddlePos);

            foePaddle.maxHeight = paddleMaxHeight;
            foePaddle.minHeight = paddleMinHeight;

            myFoePaddle.FillColor = Color.White;
            myFoePaddle.Origin = new Vector2f(foePaddle.width / 2, foePaddle.height / 2);
            myFoePaddle.Size = new Vector2f(foePaddle.width, foePaddle.height);

            myMyScore.Position = new Vector2f(windowWidth * 0.75f, 3 * canvas.padding);
            myMyScore.Color = fontColor;
            myMyScore.Font = font;
            myMyScore.CharacterSize = fontSize;

            myFoeScore.Position = new Vector2f(windowWidth * 0.25f, 3 * canvas.padding);
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
                foeScore.value++;
            }

            if (ball.CanvasLeftCollision(canvas))
            {
                ball.Respawn(windowWidth, windowHeight);
                myScore.value++;
            }

            ball.CanvasTopBottomCollision(canvas);

            ball.PaddleCollision(foePaddle, true);
            ball.PaddleCollision(myPaddle, false);

            ball.pos += ball.mov * ball.speed * dt.time;

            myBall.Position = ball.pos;
            myMyPaddle.Position = myPaddle.pos;
            myFoePaddle.Position = foePaddle.pos;
            myMyScore.DisplayedString = myScore.value.ToString();
            myFoeScore.DisplayedString = foeScore.value.ToString();
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
            if (foePaddle.pos.Y > ball.pos.Y)
            {
                foePaddle.MoveUp(dt);
            }
            else if (foePaddle.pos.Y < ball.pos.Y)
            {
                foePaddle.MoveDown(dt);
            }
        }

    }

    
}
