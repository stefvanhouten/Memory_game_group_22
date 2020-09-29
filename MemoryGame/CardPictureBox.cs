
using System.Drawing;
using System.Windows.Forms;

namespace MemoryGame
{
    public class CardPictureBox : PictureBox
    {
        public string PairName { get; set; }
        public bool IsSolved { get; set; } = false;
        public bool HasBeenVisible { get; set; } = false;
        public Bitmap CardImage { get; set; } //Custom bitmap to store the image in. PictureBox.Image cant be hidden without losing the image
    }

    class CardPictureBoxJson
    {
        public string Name { get; set; }
        public string PairName { get; set; }
        public bool IsSolved { get; set; } = false;
        public bool HasBeenVisible { get; set; } = false;
    }
}
