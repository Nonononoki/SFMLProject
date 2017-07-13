using FarseerPhysics;
using FarseerPhysics.Common;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using SFML.System;
using SpaceX.gameOverWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiled.SFML;

namespace SpaceX.bossWindow.boss
{
    class BossFirePillar : GameObject
    {
        public RenderingComponent RC { set; get; }
        public PhysicsComponent PC { set; get; }
        public TimedDestructionComponent LC { set; get; }
        public AnimationComponent AC { set; get; }
        public BossFirePillarLogicComponent LC2 { set; get; }
        public BossWindowData BWD { set; get; }
        public int DestroyTime { set; get; }

        public BossFirePillar(BossWindowData BWD, Tile Tile, int DestroyTime)
        {
            this.BWD = BWD;
            this.DestroyTime = DestroyTime;

            //randon value
            Vector2f r = new Vector2f(10,10);

            RC = new RenderingComponent(Tile.Position, BWD.BossFirePillarSprites[0].Texture, r, false);
            //reposition and resize because it's relative to window
            RC.Sprite.Position = Tile.Position;
            RC.Sprite.Scale = new Vector2f(BossWindow.Arena.Map.TileSize.X / RC.Sprite.Texture.Size.X,
                BossWindow.Arena.Map.TileSize.Y / RC.Sprite.Texture.Size.Y);

            Vertices v = PhysicsComponent.RechtangleVertices(Converter.Vector(BossWindow.Arena.Map.TileSize));           
            PC = new PhysicsComponent(Converter.Vector(Tile.Position),
                Converter.Vector(BossWindow.Arena.Map.TileSize), v, BossWindow.World, false);
            LC = new TimedDestructionComponent(DestroyTime, this);
            AC = new AnimationComponent(BWD.BossFirePillarSprites, BWD.BossFirePillarSpeed, RC, null, true);
            LC2 = new BossFirePillarLogicComponent(BWD, this);

            //cheating - move objects to origin of tile
            RC.Sprite.Position += BossWindow.Arena.Map.TileSize/2;
            PC.Body.Position += ConvertUnits.ToSimUnits(Converter.Vector(BossWindow.Arena.Map.TileSize / 2));

            PC.AddUserData(this, "BossFire");
            PC.Body.BodyType = BodyType.Static;
            PC.Body.Enabled = false;
            PC.Body.CollisionCategories = Category.Cat4;
            PC.Body.CollidesWith = Category.Cat1;

            this.AddComponent(PC);
            this.AddComponent(RC);
            this.AddComponent(LC);
            this.AddComponent(AC);
            this.AddComponent(LC2);
            LC2.SW.Start();
            AC.Start();
        }

        public BossFirePillar Clone(Tile t)
        {
            
            BossFirePillar b = new BossFirePillar(BWD, t, DestroyTime);            
            b.RC.IsVisible = true;
            b.LC.Start();
            
            return b;
        }
    }
}
