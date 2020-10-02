using System.Drawing;

namespace MemoryGame
{
    /// <summary>
    /// Template used to store Name and resource/Image
    /// </summary>
    public struct CardNameAndImage
    {
        public string Name { get; set; }
        public Bitmap Resource { get; set; }
    }
}
