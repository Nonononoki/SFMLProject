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
    class PongSettings
    {
        const int windowHeight = 600;
        const int windowWidth = 800;
        RenderWindow pongSettingsWindow = new RenderWindow(new VideoMode(windowWidth, windowHeight), "PongSettings", Styles.Default);

        //default values
        const float d_ballSpeed = 400;
        const float d_myPaddleHeight = 100f;
        const float d_myPaddleSpeed = 600f;
        const float d_foePaddleHeight = 100f;
        const float d_foePaddleSpeed = 800f;

        float ballSpeed = d_ballSpeed;
        float myPaddleHeight = d_myPaddleHeight;
        float myPaddleSpeed = d_myPaddleSpeed;
        float foePaddleHeight = d_foePaddleHeight;
        float foePaddleSpeed = d_foePaddleSpeed;

        //in- and decrease percentage
        float increase = 0.01f;
        float decrease = 0.01f;

        //position values
        float smallerWidth = 100;
        float smallerHeight = 100;

        Vector2f smallerStartPos = new Vector2f(0, 0);

        float biggerWidth = 100;
        float biggerHeight = 100;

        Vector2f biggerStartPos = new Vector2f(700, 0);

        Vector2f textStartPos = new Vector2f(100,0);
        float textHeight = 100;


        //sprite to make values smaller
        Sprite ballSpeedSmaller = new Sprite();
        Sprite myPaddleHeightSmaller = new Sprite();
        Sprite myPaddleSpeedSmaller = new Sprite();
        Sprite foePaddleHeightSmaller = new Sprite();
        Sprite foePaddleSpeedSmaller = new Sprite();
        Sprite reset = new Sprite();

        Vector2f ballSpeedSmallerPos;
        Vector2f myPaddleHeightSmallerPos;
        Vector2f myPaddleSpeedSmallerPos;
        Vector2f foePaddleHeightSmallerPos;
        Vector2f foePaddleSpeedSmallerPos;
        Vector2f resetPos;


        //Texts
        Text ballSpeedText = new Text();
        Text myPaddleHeightText = new Text();
        Text myPaddleSpeedText = new Text();
        Text foePaddleHeightText = new Text();
        Text foePaddleSpeedText = new Text();

        String ballSpeedString = "ballSpeed: ";
        String myPaddleHeightString = "myPaddleHeight: ";
        String myPaddleSpeedString = "myPaddleSpeed: ";
        String foePaddleHeightString = "foePaddleHeight: ";
        String foePaddleSpeedString = "foePaddleSpeed: ";

        Vector2f ballSpeedTextPos = new Vector2f();
        Vector2f myPaddleHeightTextPos = new Vector2f();
        Vector2f myPaddleSpeedTextPos = new Vector2f();
        Vector2f foePaddleHeightTextPos = new Vector2f();
        Vector2f foePaddleSpeedTextPos = new Vector2f();

        //sprite to make values bigger
        Sprite ballSpeedBigger = new Sprite();
        Sprite myPaddleHeightBigger = new Sprite();
        Sprite myPaddleSpeedBigger = new Sprite();
        Sprite foePaddleHeightBigger = new Sprite();
        Sprite foePaddleSpeedBigger = new Sprite();
        Sprite play = new Sprite();

        Vector2f ballSpeedBiggerPos;
        Vector2f myPaddleHeightBiggerPos;
        Vector2f myPaddleSpeedBiggerPos;
        Vector2f foePaddleHeightBiggerPos;
        Vector2f foePaddleSpeedBiggerPos;
        Vector2f playPos;


        //fonts
        Font font = new Font("../../../fonts/pixel.ttf");
        Color fontColor = new Color(255, 255, 255, 100);
        uint fontSize = 35;
        float textPadding;

        //textures
        Texture smallerTexture = new Texture("../../../sprites/smaller.png");
        Texture biggerTexture = new Texture("../../../sprites/bigger.png");
        Texture smallerHoverTexture = new Texture("../../../sprites/smaller_hover.png");
        Texture biggerHoverTexture = new Texture("../../../sprites/bigger_hover.png");
        Texture resetTexture = new Texture("../../../sprites/reset.png");
        Texture resetHoverTexture = new Texture("../../../sprites/reset_hover.png");
        Texture playTexture = new Texture("../../../sprites/play.png");
        Texture playHoverTexture = new Texture("../../../sprites/play_hover.png");

        void Start()
        { 
            //Sprites
            ballSpeedSmallerPos = new Vector2f(smallerStartPos.X, smallerStartPos.Y + 0 * smallerHeight);
            myPaddleHeightSmallerPos = new Vector2f(smallerStartPos.X, smallerStartPos.Y + 1 * smallerHeight);
            myPaddleSpeedSmallerPos = new Vector2f(smallerStartPos.X, smallerStartPos.Y + 2 * smallerHeight);
            foePaddleHeightSmallerPos = new Vector2f(smallerStartPos.X, smallerStartPos.Y + 3 * smallerHeight);
            foePaddleSpeedSmallerPos = new Vector2f(smallerStartPos.X, smallerStartPos.Y + 4 * smallerHeight);
            resetPos = new Vector2f(smallerStartPos.X, smallerStartPos.Y + 5 * smallerHeight);

            ballSpeedBiggerPos = new Vector2f(biggerStartPos.X, biggerStartPos.Y + 0 * biggerHeight);
            myPaddleHeightBiggerPos = new Vector2f(biggerStartPos.X, biggerStartPos.Y + 1 * biggerHeight);
            myPaddleSpeedBiggerPos = new Vector2f(biggerStartPos.X, biggerStartPos.Y + 2 * biggerHeight);
            foePaddleHeightBiggerPos = new Vector2f(biggerStartPos.X, biggerStartPos.Y + 3 * biggerHeight);
            foePaddleSpeedBiggerPos = new Vector2f(biggerStartPos.X, biggerStartPos.Y + 4 * biggerHeight);
            playPos = new Vector2f(biggerStartPos.X, biggerStartPos.Y + 5 * biggerHeight);

            ballSpeedSmaller.Texture = smallerTexture;
            myPaddleHeightSmaller.Texture = smallerTexture;
            myPaddleSpeedSmaller.Texture = smallerTexture;
            foePaddleHeightSmaller.Texture = smallerTexture;
            foePaddleSpeedSmaller.Texture = smallerTexture;
            reset.Texture = resetTexture;

            ballSpeedSmaller.Position = ballSpeedSmallerPos;
            myPaddleHeightSmaller.Position = myPaddleHeightSmallerPos;
            myPaddleSpeedSmaller.Position = myPaddleSpeedSmallerPos;
            foePaddleHeightSmaller.Position = foePaddleHeightSmallerPos;
            foePaddleSpeedSmaller.Position = foePaddleSpeedSmallerPos;
            reset.Position = resetPos;

            ballSpeedSmaller.Scale = new Vector2f(smallerWidth / smallerTexture.Size.X, smallerHeight / smallerTexture.Size.Y);
            myPaddleHeightSmaller.Scale = new Vector2f(smallerWidth / smallerTexture.Size.X, smallerHeight / smallerTexture.Size.Y);
            myPaddleSpeedSmaller.Scale = new Vector2f(smallerWidth / smallerTexture.Size.X, smallerHeight / smallerTexture.Size.Y);
            foePaddleHeightSmaller.Scale = new Vector2f(smallerWidth / smallerTexture.Size.X, smallerHeight / smallerTexture.Size.Y);
            foePaddleSpeedSmaller.Scale = new Vector2f(smallerWidth / smallerTexture.Size.X, smallerHeight / smallerTexture.Size.Y);
            reset.Scale = new Vector2f(smallerWidth / resetTexture.Size.X, smallerHeight / resetTexture.Size.Y);

            ballSpeedBigger.Texture = biggerTexture;
            myPaddleHeightBigger.Texture = biggerTexture;
            myPaddleSpeedBigger.Texture = biggerTexture;
            foePaddleHeightBigger.Texture = biggerTexture;
            foePaddleSpeedBigger.Texture = biggerTexture;
            play.Texture = playTexture;

            ballSpeedBigger.Position = ballSpeedBiggerPos;
            myPaddleHeightBigger.Position = myPaddleHeightBiggerPos;
            myPaddleSpeedBigger.Position = myPaddleSpeedBiggerPos;
            foePaddleHeightBigger.Position = foePaddleHeightBiggerPos;
            foePaddleSpeedBigger.Position = foePaddleSpeedBiggerPos;
            play.Position = playPos;

            ballSpeedBigger.Scale = new Vector2f(biggerWidth / biggerTexture.Size.X, biggerHeight / biggerTexture.Size.Y);
            myPaddleHeightBigger.Scale = new Vector2f(biggerWidth / biggerTexture.Size.X, biggerHeight / biggerTexture.Size.Y);
            myPaddleSpeedBigger.Scale = new Vector2f(biggerWidth / biggerTexture.Size.X, biggerHeight / biggerTexture.Size.Y);
            foePaddleHeightBigger.Scale = new Vector2f(biggerWidth / biggerTexture.Size.X, biggerHeight / biggerTexture.Size.Y);
            foePaddleSpeedBigger.Scale = new Vector2f(biggerWidth / biggerTexture.Size.X, biggerHeight / biggerTexture.Size.Y);
            play.Scale = new Vector2f(biggerWidth / playTexture.Size.X, biggerHeight / playTexture.Size.Y);


            //text
            textPadding = 0.3f * textHeight;
            ballSpeedTextPos = new Vector2f(textStartPos.X, textStartPos.Y + 0 * textHeight + textPadding);
            myPaddleHeightTextPos = new Vector2f(textStartPos.X, textStartPos.Y + 1 * textHeight + textPadding);
            myPaddleSpeedTextPos = new Vector2f(textStartPos.X, textStartPos.Y + 2 * textHeight + textPadding);
            foePaddleHeightTextPos = new Vector2f(textStartPos.X, textStartPos.Y + 3 * textHeight + textPadding);
            foePaddleSpeedTextPos = new Vector2f(textStartPos.X, textStartPos.Y + 4 * textHeight + textPadding);

            ballSpeedText.Color = fontColor;
            myPaddleHeightText.Color = fontColor;
            myPaddleSpeedText.Color = fontColor;
            foePaddleHeightText.Color = fontColor;
            foePaddleSpeedText.Color = fontColor;

            ballSpeedText.Font = font;
            myPaddleHeightText.Font = font;
            myPaddleSpeedText.Font = font;
            foePaddleHeightText.Font = font;
            foePaddleSpeedText.Font = font;

            ballSpeedText.CharacterSize = fontSize;
            myPaddleHeightText.CharacterSize = fontSize;
            myPaddleSpeedText.CharacterSize = fontSize;
            foePaddleHeightText.CharacterSize = fontSize;
            foePaddleSpeedText.CharacterSize = fontSize;

            ballSpeedText.Position = ballSpeedTextPos;
            myPaddleHeightText.Position = myPaddleHeightTextPos;
            myPaddleSpeedText.Position = myPaddleSpeedTextPos;
            foePaddleHeightText.Position = foePaddleHeightTextPos;
            foePaddleSpeedText.Position = foePaddleSpeedTextPos;
        }

        public void Run()
        {
            Start();

            bool running = true;
            while (running)
            {
                //dt not needed for main screen!

                Events();
                Update();

                pongSettingsWindow.Clear(Color.Black);
                pongSettingsWindow.DispatchEvents();
                pongSettingsWindow.Closed += (sender, evtArgs) => running = false;

                //draw buttons
                pongSettingsWindow.Draw(ballSpeedSmaller);
                pongSettingsWindow.Draw(myPaddleHeightSmaller);
                pongSettingsWindow.Draw(myPaddleSpeedSmaller);
                pongSettingsWindow.Draw(foePaddleHeightSmaller);
                pongSettingsWindow.Draw(foePaddleSpeedSmaller);
                pongSettingsWindow.Draw(reset);

                pongSettingsWindow.Draw(ballSpeedBigger);
                pongSettingsWindow.Draw(myPaddleHeightBigger);
                pongSettingsWindow.Draw(myPaddleSpeedBigger);
                pongSettingsWindow.Draw(foePaddleHeightBigger);
                pongSettingsWindow.Draw(foePaddleSpeedBigger);
                pongSettingsWindow.Draw(play);

                //draw text
                pongSettingsWindow.Draw(ballSpeedText);              
                pongSettingsWindow.Draw(myPaddleHeightText);
                pongSettingsWindow.Draw(myPaddleSpeedText);
                pongSettingsWindow.Draw(foePaddleHeightText);
                pongSettingsWindow.Draw(foePaddleSpeedText);
                

                //display window
                pongSettingsWindow.Display();
            }

            pongSettingsWindow.Close();
        }

        void Update()
        {
            ballSpeedText.DisplayedString = ballSpeedString + ballSpeed;
            myPaddleHeightText.DisplayedString =  myPaddleHeightString + myPaddleHeight;
            myPaddleSpeedText.DisplayedString = myPaddleSpeedString + myPaddleSpeed;
            foePaddleHeightText.DisplayedString =  foePaddleHeightString + foePaddleHeight;
            foePaddleSpeedText.DisplayedString =  foePaddleSpeedString + foePaddleSpeed;

            //hovering effects

            //hover smaller
            if (MouseOverSprite(ballSpeedSmaller, pongSettingsWindow))
            {
                ballSpeedSmaller.Texture = smallerHoverTexture;
            }
            else
            {
                ballSpeedSmaller.Texture = smallerTexture;
            }

            if (MouseOverSprite(myPaddleHeightSmaller, pongSettingsWindow))
            {
                myPaddleHeightSmaller.Texture = smallerHoverTexture;
            }
            else
            {
                myPaddleHeightSmaller.Texture = smallerTexture;
            }

            if (MouseOverSprite(myPaddleSpeedSmaller, pongSettingsWindow))
            {
                myPaddleSpeedSmaller.Texture = smallerHoverTexture;
            }
            else
            {
                myPaddleSpeedSmaller.Texture = smallerTexture;
            }

            if (MouseOverSprite(foePaddleHeightSmaller, pongSettingsWindow))
            {
                foePaddleHeightSmaller.Texture = smallerHoverTexture;
            }
            else
            {
                foePaddleHeightSmaller.Texture = smallerTexture;
            }

            if (MouseOverSprite(foePaddleSpeedSmaller, pongSettingsWindow))
            {
                foePaddleSpeedSmaller.Texture = smallerHoverTexture;
            }
            else
            {
                foePaddleSpeedSmaller.Texture = smallerTexture;
            }


            //bigger
            if (MouseOverSprite(ballSpeedBigger, pongSettingsWindow))
            {
                ballSpeedBigger.Texture = biggerHoverTexture;
            }
            else
            {
                ballSpeedBigger.Texture = biggerTexture;
            }
            if (MouseOverSprite(myPaddleHeightBigger, pongSettingsWindow))
            {
                myPaddleHeightBigger.Texture = biggerHoverTexture;
            }
            else
            {
                myPaddleHeightBigger.Texture = biggerTexture;
            }
            if (MouseOverSprite(myPaddleSpeedBigger, pongSettingsWindow))
            {
                myPaddleSpeedBigger.Texture = biggerHoverTexture;
            }
            else
            {
                myPaddleSpeedBigger.Texture = biggerTexture;
            }
            if (MouseOverSprite(foePaddleHeightBigger, pongSettingsWindow))
            {
                foePaddleHeightBigger.Texture = biggerHoverTexture;
            }
            else
            {
                foePaddleHeightBigger.Texture = biggerTexture;
            }
            if (MouseOverSprite(foePaddleSpeedBigger, pongSettingsWindow))
            {
                foePaddleSpeedBigger.Texture = biggerHoverTexture;
            }
            else
            {
                foePaddleSpeedBigger.Texture = biggerTexture;
            }

            //reset
            if (MouseOverSprite(reset, pongSettingsWindow))
            {
                reset.Texture = resetHoverTexture;
            }
            else
            {
                reset.Texture = resetTexture;
            }

            //play
            if (MouseOverSprite(play, pongSettingsWindow))
            {
                play.Texture = playHoverTexture;
            }
            else
            {
                play.Texture = playTexture;
            }

        }


        void Events()
        {
            //click events
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                //smaller
                if (MouseOverSprite(ballSpeedSmaller, pongSettingsWindow))
                {
                    ballSpeed -= d_ballSpeed * decrease;
                }
                if (MouseOverSprite(myPaddleHeightSmaller, pongSettingsWindow))
                {
                    myPaddleHeight -= d_myPaddleHeight * decrease;
                }
                if (MouseOverSprite(myPaddleSpeedSmaller, pongSettingsWindow))
                {
                    myPaddleSpeed -= d_myPaddleSpeed * decrease;
                }
                if (MouseOverSprite(foePaddleHeightSmaller, pongSettingsWindow))
                {
                    foePaddleHeight -= d_foePaddleHeight * decrease;
                }
                if (MouseOverSprite(foePaddleSpeedSmaller, pongSettingsWindow))
                {
                    foePaddleSpeed -= d_foePaddleSpeed * decrease;
                }

                //bigger
                if (MouseOverSprite(ballSpeedBigger, pongSettingsWindow))
                {
                    ballSpeed += d_ballSpeed * increase;
                }
                if (MouseOverSprite(myPaddleHeightBigger, pongSettingsWindow))
                {
                    myPaddleHeight += d_myPaddleHeight * increase;
                }
                if (MouseOverSprite(myPaddleSpeedBigger, pongSettingsWindow))
                {
                    myPaddleSpeed += d_myPaddleSpeed * increase;
                }
                if (MouseOverSprite(foePaddleHeightBigger, pongSettingsWindow))
                {
                    foePaddleHeight += d_foePaddleHeight * increase;
                }
                if (MouseOverSprite(foePaddleSpeedBigger, pongSettingsWindow))
                {
                    foePaddleSpeed += d_foePaddleSpeed * increase;
                }

                //reset and play
                if (MouseOverSprite(reset, pongSettingsWindow))
                {
                    ballSpeed = d_ballSpeed;
                    myPaddleHeight = d_myPaddleHeight;
                    myPaddleSpeed = d_myPaddleSpeed;
                    foePaddleHeight = d_foePaddleHeight;
                    foePaddleSpeed = d_foePaddleSpeed;
                }

                if (MouseOverSprite(play, pongSettingsWindow))
                {
                    PongValues pv = new PongValues();
                    pv.BallSpeed       = ballSpeed;
                    pv.MyPaddleHeight  = myPaddleHeight;
                    pv.MyPaddleSpeed   = myPaddleSpeed;
                    pv.FoePaddleHeight = foePaddleHeight;
                    pv.FoePaddleSpeed  = foePaddleSpeed;

                    Pong pong = new Pong(pv);
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
