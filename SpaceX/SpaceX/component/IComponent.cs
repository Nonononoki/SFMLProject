﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX
{
    interface IComponent 
    {
        void Update();
        void Destroy();
    }
}
