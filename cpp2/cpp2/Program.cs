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
using gpp2.Pong;

namespace cpp2
{
	class Program
	{
		static void Main(string[] args)
		{
            //Main Window and Controller

            //main window
            const int windowHeight = 400;
            const int windowWidth = 400;
            RenderWindow mainWindow = new RenderWindow(new VideoMode(windowWidth, windowHeight), "Nho Quy Dinh GPP2", Styles.Default);

            //pong buttons
            Sprite pongStart = new Sprite();
            Sprite pongOptions = new Sprite();

            //brickbreak buttons
            Sprite brickBreakStart = new Sprite();
            Sprite brickBreakOptions = new Sprite();

            //spaceshooter buttons
            Sprite spaceShooterStart = new Sprite();
            Sprite spaceShooterOptions = new Sprite();

            //myGame buttons
            Sprite myGameStart = new Sprite();
            Sprite myGameOptions = new Sprite();

            //buttonsizes and vectors
            Vector2f gameButtonSize = new Vector2f(300, 100) ;
            Vector2f optionButtonSize = new Vector2f(100, 100);

            Vector2f pongStartStart         = new Vector2f(0, 0);
            Vector2f brickBreakStartStart   = new Vector2f(0, 1 * gameButtonSize.Y);
            Vector2f spaceShooterStartStart = new Vector2f(0, 2 * gameButtonSize.Y);
            Vector2f myGameStartStart       = new Vector2f(0, 3 * gameButtonSize.Y);

            Vector2f pongOptionStart         = new Vector2f(gameButtonSize.X, 0);
            Vector2f brickBreakOptionStart   = new Vector2f(gameButtonSize.X, 1 * optionButtonSize.Y);
            Vector2f spaceShooterOptionStart = new Vector2f(gameButtonSize.X, 2 * optionButtonSize.Y);
            Vector2f myGameOptionStart       = new Vector2f(gameButtonSize.X, 3 * optionButtonSize.Y);

            Texture settingTexture = new Texture("../../../sprites/settings.png");
            Texture pongTexture = new Texture("../../../sprites/pong.png");
            Texture pongHoverTexture = new Texture("../../../sprites/pong_hover.png");
            Texture settingHoverTexture = new Texture("../../../sprites/settings_hover.png");


            pongStart.Texture = pongTexture;
            pongStart.Position = pongStartStart;
            pongStart.Scale = new Vector2f(gameButtonSize.X / pongTexture.Size.X, gameButtonSize.Y / pongTexture.Size.Y);

            pongOptions.Texture = settingTexture;
            pongOptions.Position = pongOptionStart;
            pongOptions.Scale = new Vector2f(optionButtonSize.X / settingTexture.Size.X, optionButtonSize.Y / settingTexture.Size.Y);
            

            Run();



            void Run()
            {
                bool running = true;
                while (running)
                {
                    //dt not needed for main screen!

                    Events();
                    Update();

                    mainWindow.Clear(Color.Black);
                    mainWindow.DispatchEvents();
                    mainWindow.Closed += (sender, evtArgs) => running = false;

                    //draw buttons
                    mainWindow.Draw(pongStart);
                    mainWindow.Draw(pongOptions);

                    //display window
                    mainWindow.Display();
                }


            }

            void Update()
            {
                //hovering effects
                if (MouseOverSprite(pongStart, mainWindow))
                {
                    pongStart.Texture = pongHoverTexture;
                }
                else
                {
                    pongStart.Texture = pongTexture;
                }

                if (MouseOverSprite(pongOptions, mainWindow))
                {
                    pongOptions.Texture = settingHoverTexture;
                }
                else
                {
                    pongOptions.Texture = settingTexture;
                }
            }

            //click events
            void Events()
            {
                if (Mouse.IsButtonPressed(Mouse.Button.Left))
                {
                    //pong
                    if (MouseOverSprite(pongStart, mainWindow))
                    {
                        Pong pong = new Pong();
                        pong.Run();
                    }

                    //pong settings
                    if (MouseOverSprite(pongOptions, mainWindow))
                    {
                        PongSettings pongSettings = new PongSettings();
                        pongSettings.Run();
                    }

                }
            }

            //check if cursor is over a sprite
            bool MouseOverSprite(Sprite sprite, Window window)
            {
                if (Mouse.GetPosition(window).X > sprite.GetGlobalBounds().Left && 
                    Mouse.GetPosition(window).X < (sprite.GetGlobalBounds().Left + sprite.GetGlobalBounds().Width) && 
                    Mouse.GetPosition(window).Y > sprite.GetGlobalBounds().Top && 
                    Mouse.GetPosition(window).Y < (sprite.GetGlobalBounds().Top + sprite.GetGlobalBounds().Height))
                {
                    return true;
                }

                return false;
            }

        }

  	}
}
