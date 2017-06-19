using Microsoft.Xna.Framework;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpaceX
{
    class Converter
    {
        //convert string to key, https://gist.github.com/Bambofy/8146645
        public static Keyboard.Key StringKey(string keystr)
        {
            return (Keyboard.Key)Enum.Parse(typeof(Keyboard.Key), keystr);
        }

        //convert sfml vector to farseer vector and vice versa
        public static Vector2 Vector(Vector2f v)
        {
            return new Vector2(v.X, v.Y);
        }
        public static Vector2f Vector(Vector2 v)
        {
            return new Vector2f(v.X, v.Y);
        }

        //convert position in relation to Window
        public static Vector2f RelativeWindow(Vector2f Position)
        {
            return new Vector2f(Position.X * Program.Window.Size.X, Position.Y * Program.Window.Size.Y) / 100;
        }
        public static Vector2 RelativeWindow(Vector2 Position)
        {
            return new Vector2(Position.X * Program.Window.Size.X, Position.Y * Program.Window.Size.Y) / 100;
        }

        //convert int in relation to Windowwidth
        public static int RelativeWindow(int value)
        {
            return (int)((value / 100) * Program.Window.Size.X);
        }

        //convert Vector to a specific length
        public static Vector2 ResizeVector(Vector2 v, float desiredLength)
        {
            return v / v.Length() * desiredLength;
        }

        public static void RemoveAllComponents(IWindow window)
        {
            List<GameObject> List = window.GameObjects();

            foreach (GameObject go in List.ToList())
            {
                //retain renderingcomponent
                if (go.GetComponent<RenderingComponent>() != null)
                {
                    go.RemoveAllComponentsExcept(go.GetComponent<RenderingComponent>());

                    //fade effect
                    RenderingComponent rc = go.GetComponent<RenderingComponent>();
                    rc.Fading = true;
                    rc.Window = window;
                    rc.RemoveWindow = true;
                }
            }
        }
    }
}
