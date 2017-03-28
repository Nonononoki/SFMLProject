using SFML.Graphics;
using SFML.Window;
using SFML.System;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace cpp2
{
	class Program
	{
		static void Main(string[] args)
		{
            //initialize window
            const int windowHeight = 400;
            const int windowWidth = 800;
			var pongWindow = new RenderWindow(new VideoMode(windowWidth, windowHeight), "GPP2", Styles.Default);
			bool running = true;


            //initialize canvas
            int padding = 5;
            Canvas canvas = new Canvas(padding*2, windowHeight - padding*2, padding*2, windowWidth - padding*2, padding);

            RectangleShape myCanvas = new RectangleShape();
            myCanvas.Size = new Vector2f(canvas.right, canvas.bottom);
            myCanvas.Position = new Vector2f(canvas.padding, canvas.padding);
            myCanvas.OutlineThickness = 1;
            myCanvas.OutlineColor = Color.White;
            myCanvas.FillColor = Color.Black;


            //initialize ball
            Ball ball = new Ball();
            ball.radius = 5;
            ball.respawn(windowWidth, windowHeight); //spawn ball for first game

            CircleShape myBall = new CircleShape();
            myBall.FillColor = Color.White;
            myBall.Radius = ball.radius;
            myBall.Origin = new Vector2f(ball.radius, ball.radius);


            //initialize myPaddle
            const float myPaddleHeight = 50f;
            const float myPaddleWidth = 3f;
            const float myPaddleSpeed = 0.1f;

            Vector2f myPaddlepos = new Vector2f(windowWidth - 2*canvas.padding, windowHeight / 2); 
            MyPaddle myPaddle = new MyPaddle(myPaddleWidth, myPaddleHeight, myPaddleSpeed, myPaddlepos);

            RectangleShape myMyPaddle = new RectangleShape();
            myMyPaddle.FillColor = Color.White;
            myMyPaddle.Origin = new Vector2f(myPaddle.width/2, myPaddle.height/2);
            myMyPaddle.Size = new Vector2f(myPaddle.width, myPaddle.height);

            //initialize foePaddle
            const float foePaddleHeight = 50f;
            const float foePaddleWidth = 3f;
            const float foePaddleSpeed = 0.1f;
            Vector2f foePaddlepos = new Vector2f(0 + 2*canvas.padding, windowHeight / 2);
            MyPaddle foePaddle = new MyPaddle(foePaddleWidth, foePaddleHeight, foePaddleSpeed, foePaddlepos);

            RectangleShape myFoePaddle = new RectangleShape();
            myFoePaddle.FillColor = Color.White;
            myFoePaddle.Origin = new Vector2f(foePaddle.width / 2, foePaddle.height / 2);
            myFoePaddle.Size = new Vector2f(foePaddle.width, foePaddle.height);

            //Score variables
            Font font = new Font("../../../fonts/pixel.ttf");
            Color fontColor = new Color(255, 255, 255, 100);
            uint fontSize = 32;

            //initialize myScore
            Score myScore = new Score();
            Text myMyScore = new Text();
            myMyScore.Position = new Vector2f(windowWidth*0.75f, 3 * canvas.padding);
            myMyScore.Color = fontColor;
            myMyScore.Font = font;
            myMyScore.CharacterSize = fontSize;

            //initialize foeScore
            Score foeScore = new Score();
            Text myFoeScore = new Text();
            myFoeScore.Position = new Vector2f(windowWidth * 0.25f, 3 * canvas.padding);
            myFoeScore.Color = fontColor;
            myFoeScore.Font = font;
            myFoeScore.CharacterSize = fontSize;

            //ai movements
            void ai()
            {
                //move paddle down
                if(foePaddle.pos.Y > ball.pos.Y)
                {
                    foePaddle.moveUp();
                }
                else if (foePaddle.pos.Y < ball.pos.Y)
                {
                    foePaddle.moveDown();
                }
            }

            //moving player paddle
            void events()
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
                {
                    myPaddle.moveUp();
                }
                else if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
                {
                    myPaddle.moveDown();
                }
            }

            //update object positions and score
            void update()
            {
                ai();
                events();

                if (ball.CanvasRightCollision(canvas))
                {
                    ball.respawn(windowWidth, windowHeight);
                    foeScore.value++;
                }

                if (ball.CanvasLeftCollision(canvas))
                {
                    ball.respawn(windowWidth, windowHeight);
                    myScore.value++;
                }

                ball.CanvasTopBottomCollision(canvas);

                ball.pos += ball.mov;

                myBall.Position = ball.pos;
                myMyPaddle.Position = myPaddle.pos;
                myFoePaddle.Position = foePaddle.pos;
                myMyScore.DisplayedString = myScore.value.ToString();
                myFoeScore.DisplayedString = foeScore.value.ToString();

            }


            while (running)
			{
                update();

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
			}
		}
	}
}
