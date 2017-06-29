using SFML.Graphics;
using Tiled.SFML;

namespace SpaceX.bossWindow
{
    class BossArena : GameObject
    {
        public Map Map { set; get; }
        public RenderTarget Target { set; get; }
        public RenderStates States { set; get; }

        public BossArena(BossWindowData bwd)
        {
            Map = bwd.Map; //new Map(bwd.MapPath, Program.Window.DefaultView);
            Target = Program.Window;
            States = RenderStates.Default;
        }

        public void Draw()
        {
            Map.Draw(Target, States);
        }
    }
}
