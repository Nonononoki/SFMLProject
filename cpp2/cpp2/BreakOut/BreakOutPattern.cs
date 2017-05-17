using FarseerPhysics.Common;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gpp2.BreakOut
{
    class BreakOutPattern
    {
        private Vector2[,] v; //Positions of bricks
        private BreakOutCanvas canvas;
        public int currentLevel = 1;
        public int maxLevel;
        private const int padding = 5; // padding of blocks
        public bool gameOver = false;

        //generated bricks
        public BreakOutBricks[,] bricks;

        //reference to world objects
        private World world;
        private BreakOutPaddle paddle;
        private BreakOutBall ball;
        public BreakOutScore score;

        public BreakOutPattern(int maxLevel, BreakOutCanvas canvas, World World, BreakOutPaddle paddle, BreakOutBall ball, BreakOutScore score)
        {
            this.maxLevel = maxLevel;
            this.canvas = canvas;
            this.world = World;
            this.paddle = paddle;
            this.ball = ball;
            this.score = score;
        }

        public void LoadPattern(int level)
        {
            //reset ball + paddle
            ball.Reset();
            paddle.Reset();

            //still have remaining levels
            if (level <= maxLevel)
            {
                ReadJson(level);
            }
            
            //win! Game Over!
            else
            {
                gameOver = true;
            }
        }

        //spawn bricks in designated areas
        private void SpawnPattern(JObject o)
        {
            //get number of bricks
            int x = o.Value<int>("numHorizontal");
            int y = o.Value<int>("numVertical");
            bricks = new BreakOutBricks[y, x];

            //texture
            Texture texture = new Texture("../../../sprites/breakOut/brick.png");

            //get brick size
            int brickWidth = o.Value<int>("brickWidth");
            int brickHeight = o.Value<int>("brickHeight");
            Vector2 brickSize = new Vector2(brickWidth, brickHeight);

            //calculate positions of bricks
            int canvasPadding = 50;

            //starting positions to spawn
            float newCanvasWidth = canvas.Right - 2*canvasPadding;
            float newCanvasHeight = canvas.Top + 2*canvasPadding;

            //space between bricks
            float spaceX = newCanvasWidth / x;
            float spaceY = newCanvasHeight / y;


            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Vector2 pos = new Vector2(newCanvasWidth - spaceX * i, newCanvasHeight + spaceY * j);
                    Vertices vertices = GameObject.RechtangleVertices(brickSize);
                    bricks[j, i] = new BreakOutBricks(1, this);
                    bricks[j, i].Set(pos, texture, vertices, brickSize, world);
                    bricks[j, i].Spawn();
                }
            }
        }

        //read data from json file
        public void ReadJson(int level)
        {
            string path = "../../../json/breakOut/level" + level + ".json";
            JObject o = JObject.Parse(File.ReadAllText(@path));

            SpawnPattern(o);
        }
    }
}
