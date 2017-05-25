using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SFML.Window.Keyboard;

namespace SpaceX.component
{
    class PlayerControlComponent : IComponent
    {
        //move ship when pressing arrow keys
        public Key Up { set; get; } 
        public Key Down { set; get; }
        public Key Left { set; get; }
        public Key Right { set; get; }

        public void Destroy()
        {
            throw new NotImplementedException();
        }

        public void Move()
        {
             
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
