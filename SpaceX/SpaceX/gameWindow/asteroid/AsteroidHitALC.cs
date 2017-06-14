using SpaceX.component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.gameWindow.asteroid
{
    class AsteroidHitALC : IAnimationLogicComponent
    {
        public Asteroid Asteroid { set; get; }

        public AsteroidHitALC(Asteroid Asteroid)
        {
            this.Asteroid = Asteroid;
        }

        public void AfterAnimation()
        {
            //Asteroid.RemoveComponent(Asteroid.HitAnimation);
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