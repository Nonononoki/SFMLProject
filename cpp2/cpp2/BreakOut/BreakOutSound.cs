using SFML.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gpp2.BreakOut
{
    class BreakOutSound
    {
        public static void PlaySound(String sound)
        {
            Sound s = new Sound();
            String path = "../../../sound/breakOut/" + sound + ".ogg";

            SoundBuffer buffer = new SoundBuffer(path);
            s.SoundBuffer = buffer;
            s.Play();
        }
    }
}
