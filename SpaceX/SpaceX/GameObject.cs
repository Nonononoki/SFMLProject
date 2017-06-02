using FarseerPhysics;
using FarseerPhysics.Common;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using SFML.Graphics;
using SFML.System;
using SpaceX.component;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX
{
    class GameObject
    {
        public List<IComponent> _components;

        public uint id; //current id, no two are the same
        public static uint _id = 0; //counter for Id 
        public static List<GameObject> _list;

        public GameObject()
        {
            ID();
        }

        //update components
        public void Update()
        {
            foreach(IComponent c in _components)
            {
                c.Update();
            }
        }

        public void AddComponent(IComponent component)
        {
            if (_components == null)
                _components = new List<IComponent>();

            _components.Add(component);
        }

        public T GetComponent<T>()
        {

            //get the first object from list, there is only one of each type
            IEnumerable<T> list = _components.OfType<T>();

            return list.ElementAt(0);
        }

        private void ID() //assign id, count id
        {
            if (_list == null)
            {
                _list = new List<GameObject>();
            }

            id = _id++;
            _list.Add(this);
        }

        //for debugging
        public static GameObject FindById(uint id)
        {
            foreach (GameObject g in _list)
            {
                if (g.id == id)
                {
                    return g;
                }
            }
            return null;
        }

        //destroy GameObject
        public void Destroy()
        {
            _list.Remove(this);
        }

        //destroy every gameObject on the list
        public static void DestroyAll()
        {
            foreach (GameObject g in _list)
            {
                foreach(IComponent c in g._components)
                {
                    c.Destroy();
                }
            }

            foreach (GameObject g in _list.ToList<GameObject>())
            {
                _list.Remove(g);
            }
        }
    }
}
