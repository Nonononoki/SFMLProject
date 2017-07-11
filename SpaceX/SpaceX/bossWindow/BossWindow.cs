using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using SpaceX.component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.bossWindow
{
    class BossWindow : IWindow
    {
        public static World World { set; get; }
        public AudioComponent BGM { set; get; }
        public BossWindowData BWD { set; get; }
        public Boss Boss { set; get; }
        public BossHero Hero { set; get; }
        public BossArena Arena { set; get; }
        public static List<GameObject> MyGameObjects { set; get; }

        public static List<GameObject> ToBeRemoved { set; get; }
        public static List<CollidingComponent> CollisionList { set; get; }

        public static bool IsOver;

        public BossWindow()
        {
            BWD = new BossWindowData();

            MyGameObjects = new List<GameObject>();
            World = new World(new Vector2(0, 0));
            CollisionList = new List<CollidingComponent>();
            ToBeRemoved = new List<GameObject>();

            IsOver = false;

            Arena = new BossArena(BWD);

            Hero = new BossHero(BWD);
            MyGameObjects.Add(Hero);

            Boss = new Boss(BWD, Hero);
            MyGameObjects.Add(Boss);

            BGM = new AudioComponent(BWD.BGM, true);
            BGM.Sound.Play();

            //add to windows "stack"
            Program.Windows.Insert(0, this);
        }
        public List<GameObject> GameObjects()
        {
            return MyGameObjects;
        }

        public void Update()
        {
            //farseer steps
            if (World != null)
                World.Step(DeltaTime.Time);

            Arena.Draw();

            //draw sprites
            foreach (GameObject go in MyGameObjects.ToList<GameObject>())
            {
                go.Update();
            }

            //collide before destruction
            foreach (CollidingComponent cc in CollisionList.ToList<CollidingComponent>())
            {
                CollisionList.Remove(cc);
                cc.CollisionHandling();
            }

            //delete GameObjects
            foreach (GameObject go in ToBeRemoved.ToList<GameObject>())
            {
                ToBeRemoved.Remove(go);
                go.Destroy();
            }

            if (IsOver)
            {
                Remove();
                //GameOverWindow GOW = new GameOverWindow(Score.Value);
            }
        }

        public void Remove()
        {
            Converter.RemoveAllComponents(this);
        }

        public void Clear()
        {
            MyGameObjects.Clear();
            World.Enabled = false;
            Program.Windows.Remove(this);
        }
    }
}
