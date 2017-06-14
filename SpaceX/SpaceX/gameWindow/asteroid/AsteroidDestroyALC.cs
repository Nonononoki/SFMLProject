using SpaceX.component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.gameWindow.asteroid
{
    class AsteroidDestroyALC : IAnimationLogicComponent
    {
        public Asteroid Asteroid { set; get; }

        public AsteroidDestroyALC(Asteroid Asteroid)
        {
            this.Asteroid = Asteroid;
        }

        public void AfterAnimation()
        {
            Asteroid.DestroyMe();
        }

        public void Destroy()
        {
            //throw new NotImplementedException();

        }

        public void Update()
        {
            //throw new NotImplementedException();
        }
    }
}
