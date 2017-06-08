using SFML.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.component
{
    class AudioComponent : IComponent
    {
        public Sound Sound { set; get; }

        public AudioComponent(String path, bool IsBGM)
        {
            this.Sound = new Sound();
            SoundBuffer Buffer = new SoundBuffer(path);
            Sound.SoundBuffer = Buffer;

            if (IsBGM)
                Sound.Loop = true;
        }

        public void Destroy()
        {
            
        }

        public void Update()
        {
        }
    }
}
