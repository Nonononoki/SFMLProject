using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gpp2.BreakOut
{
    //Collision handling

    class BreakOutPhysics
    {
        void BallCollision(BreakOutBall ball, List<GameObject> list)
        {
            foreach(GameObject go in list)
            {
                //if(ball.Body.ContactList.)
                //collides with paddle
                if (go.GetType().Equals(typeof(BreakOutPaddle)))
                {

                }

            }
            

        }
            
        
    }
}
