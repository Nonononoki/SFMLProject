﻿using Microsoft.Xna.Framework;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}