using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX
{
    //userdata stored in bodies
    class UserData
    {
        //type of gameobject
        public String Type { set; get; }

        //id of gameobject
        public uint ID { set; get; }

        public UserData(String Type, uint ID)
        {
            this.Type = Type;
            this.ID = ID;
        }
    }
}
