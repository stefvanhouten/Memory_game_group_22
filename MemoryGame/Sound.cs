using System.IO;
using MemoryGame.Properties;


namespace MemoryGame
{
    public class Sound
    {
        public static void Play(Stream audioResource)
        {
            // Initialize player
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(audioResource);

            player.Play();
        }

        public static void StartBackgroundMusic(int selectedTheme)
        {
            // Create an empty Stream
            System.IO.Stream audioResource = new System.IO.MemoryStream();

            // Choose audioResource based on theme
            switch (selectedTheme)
            {
                case 0:
                    // TODO: animals theme audio (idk)
                    audioResource = Resources.testsound;
                    break;
                case 1:
                    // TODO: LOTR theme audio
                    audioResource = Resources.testsound;
                    break;
            }

            System.Media.SoundPlayer player = new System.Media.SoundPlayer(audioResource);

            // Loop the audiotrack
            player.PlayLooping();
        }
    }
}
