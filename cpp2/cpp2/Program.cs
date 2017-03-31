using SFML.Graphics;
using SFML.Window;
using SFML.System;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using gpp2;
using System.Threading;

namespace cpp2
{
	class Program
	{
		static void Main(string[] args)
		{
            //deltatime for continious and accurate movement
            DeltaTime dt = new DeltaTime();

            //initialize window
            const int windowHeight = 400;
            const int windowWidth = 700;
			var pongWindow = new RenderWindow(new VideoMode(windowWidth, windowHeight), "GPP2", Styles.Default);
			bool running = true;

            //initialize canvas
            const int padding = 5;
            Canvas canvas = new Canvas(padding*2, windowHeight - padding*2, padding*2, windowWidth - padding*2, padding);
            RectangleShape myCanvas = new RectangleShape();

            //initialize ball
            const float ballSpeed = 0.1f;
            Ball ball = new Ball(ballSpeed);
            CircleShape myBall = new CircleShape();

            //Paddle
            float paddleMinHeight = 0 + canvas.padding;
            float paddleMaxHeight = windowHeight - canvas.padding;

            //initialize myPaddle
            const float myPaddleHeight = 50f;
            const float myPaddleWidth = 3f;
            const float myPaddleSpeed = 0.3f;
            Vector2f myPaddlePos = new Vector2f(windowWidth - 2*canvas.padding, windowHeight / 2); 
            MyPaddle myPaddle = new MyPaddle(myPaddleWidth, myPaddleHeight, myPaddleSpeed, myPaddlePos);

            RectangleShape myMyPaddle = new RectangleShape();

            //initialize foePaddle
            const float foePaddleHeight = 50f;
            const float foePaddleWidth = 3f;
            const float foePaddleSpeed = 0.3f;
            Vector2f foePaddlePos = new Vector2f(0 + 2*canvas.padding, windowHeight / 2);
            FoePaddle foePaddle = new FoePaddle(foePaddleWidth, foePaddleHeight, foePaddleSpeed, foePaddlePos);

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

            Start();

            //GameLoop
            while (running)
			{           
                dt.Start();
          
                Update();

                //test
                Thread.Sleep(50);

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

                pongWindow.Display();

                dt.Stop();
            }

            //initialization
            void Start()
            {
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

                myPaddle.maxHeight = paddleMaxHeight;
                myPaddle.minHeight = paddleMinHeight;

                myMyPaddle.FillColor = Color.White;
                myMyPaddle.Origin = new Vector2f(myPaddle.width / 2, myPaddle.height / 2);
                myMyPaddle.Size = new Vector2f(myPaddle.width, myPaddle.height);

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

            //ai movements
            void AI()
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

            //moving player paddle
            void Events()
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

            //update object positions and score
            void Update()
            {
                AI();
                Events();

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
        }


	}
}
