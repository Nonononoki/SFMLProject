﻿using FarseerPhysics;
using Microsoft.Xna.Framework;
using SFML.System;
using SFML.Window;
using SpaceX.bossWindow.hero;
using SpaceX.component;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SFML.Window.Keyboard;

namespace SpaceX.bossWindow
{
    class BossHeroControllerComponent : IControllerComponent
    {
        public Vector2 Direction { set; get; }
        public BossWindowData BWD { set; get; }
        public BossHero Hero { set; get; }
        public int HeroSpeed { set; get; }
        public int HeroFireCooldown { set; get; }
        public Stopwatch SW { set; get; }
        public bool CanFire { set; get; }

        public Key Up { set; get; }
        public Key Down { set; get; }
        public Key Left { set; get; }
        public Key Right { set; get; }
        public Key Shoot { set; get; }

        public Vector2 V_Up = new Vector2(0, -1);
        public Vector2 V_Down = new Vector2(0, 1);
        public Vector2 V_Left = new Vector2(-1, 0);
        public Vector2 V_Right = new Vector2(1, 0);


        public BossHeroControllerComponent(BossHero Hero, BossWindowData BWD)
        {
            this.CanFire = true;
            this.Hero = Hero;
            this.BWD = BWD;

            Up = BWD.Up;
            Down = BWD.Down;
            Left = BWD.Left;
            Right = BWD.Right;
            Shoot = BWD.Shoot;

            HeroSpeed = BWD.HeroSpeed;
            HeroFireCooldown = BWD.HeroFireCooldown;

            SW = new Stopwatch();
        }

        public void Update()
        {
            Hero.PC.Body.LinearVelocity = new Vector2(0, 0);

            //move Hero when key is pressed
            if (Keyboard.IsKeyPressed(Up) && ConvertUnits.ToDisplayUnits(Hero.PC.Body.Position.Y) > 0)
            {
                Direction = V_Up;
                Hero.AM.ChangeDirection(HeroDirections.Direction.Up);
            }
            else if (Keyboard.IsKeyPressed(Down) && ConvertUnits.ToDisplayUnits(Hero.PC.Body.Position.Y) < Program.Window.Size.Y)
            {
                Direction = V_Down;
                Hero.AM.ChangeDirection(HeroDirections.Direction.Down);
            }
            else if (Keyboard.IsKeyPressed(Left) && ConvertUnits.ToDisplayUnits(Hero.PC.Body.Position.X) > 0)
            {
                Direction = V_Left;
                Hero.AM.ChangeDirection(HeroDirections.Direction.Left);
            }
            else if (Keyboard.IsKeyPressed(Right) && ConvertUnits.ToDisplayUnits(Hero.PC.Body.Position.X) < Program.Window.Size.X)
            {
                Direction = V_Right;
                Hero.AM.ChangeDirection(HeroDirections.Direction.Right);
            }

            if(Direction != Vector2.Zero)
                Hero.FacingDirection = Direction;

            Hero.PC.Move(Direction);
           
            Direction = Vector2.Zero;

            //Shooting with Cooldown

            if(!CanFire && SW.ElapsedMilliseconds >= HeroFireCooldown )
            {
                CanFire = true;
                SW.Reset();
            }

            if(CanFire && Keyboard.IsKeyPressed(Shoot))
            {
                Hero.Bullet.FireBullet();
                CanFire = false;
                SW.Start();
            }
        }

        public void Destroy()
        {
            SW.Stop();
        }

    }
}
