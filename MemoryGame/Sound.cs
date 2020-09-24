using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;

namespace MemoryGame
{
    public class Sound
    {
        public void Play(Stream audioResource)
        {
            // Initialize player
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(audioResource);

            player.Play();
        }
    }
    // Todo: Background music?
}
