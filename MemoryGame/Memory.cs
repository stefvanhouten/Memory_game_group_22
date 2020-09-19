using MemoryGame.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    public class CardPictureBox : PictureBox
    {
        public string PairName { get; set; }
    }

    public struct CardImage
    {
        public string Name { get; set; }
        public Bitmap Resource { get; set; }
    }

    internal class Memory
    {
        public int Rows { get; private set; } = 4;
        public int Collumns { get; private set; } = 4;
        private bool GameFrozen { get; set; } = false;
        private int SelectedTheme { get; set; } = 0;

        public Player PlayerOne { get; private set; }
        public Player PlayerTwo { get; private set; }

        public List<Card> Deck { get; private set; }
        public List<CardPictureBox> SelectedCards { get; private set; }

        public TableLayoutPanel Panel { get; private set; }

        private Dictionary<int, string> Theme = new Dictionary<int, string>()
        {
            { 0, "Animals"},
        };

        private List<KeyValuePair<int, List<CardImage>>> ThemeImages = new List<KeyValuePair<int, List<CardImage>>>();

        public Memory(TableLayoutPanel panel)
        {
            this.Panel = panel;
            for (int i = 0; i < 2; i++)
            {
                this.ThemeImages.Add(new KeyValuePair<int, List<CardImage>>(0, new List<CardImage>() { new CardImage() { Name = "banana", Resource = Resources.banana } }));
                this.ThemeImages.Add(new KeyValuePair<int, List<CardImage>>(0, new List<CardImage>() { new CardImage() { Name = "book", Resource = Resources.book } }));
                this.ThemeImages.Add(new KeyValuePair<int, List<CardImage>>(0, new List<CardImage>() { new CardImage() { Name = "bug", Resource = Resources.bug } }));
                this.ThemeImages.Add(new KeyValuePair<int, List<CardImage>>(0, new List<CardImage>() { new CardImage() { Name = "car", Resource = Resources.car } }));
                this.ThemeImages.Add(new KeyValuePair<int, List<CardImage>>(0, new List<CardImage>() { new CardImage() { Name = "monkey", Resource = Resources.monkey } }));
                this.ThemeImages.Add(new KeyValuePair<int, List<CardImage>>(0, new List<CardImage>() { new CardImage() { Name = "tornado", Resource = Resources.tornado } }));
                this.ThemeImages.Add(new KeyValuePair<int, List<CardImage>>(0, new List<CardImage>() { new CardImage() { Name = "tree", Resource = Resources.tree } }));
                this.ThemeImages.Add(new KeyValuePair<int, List<CardImage>>(0, new List<CardImage>() { new CardImage() { Name = "wine", Resource = Resources.wine } }));
            }
        }

        public void StartGame()
        {
            this.PopulateDeck();
        }

        public void PopulateDeck()
        {
            this.Deck = new List<Card>();
            this.SelectedCards = new List<CardPictureBox>();
            //Generate a memory game playing field based on game settings stored in Memory.Collumns, Memory.Rows.
            this.Panel.ColumnCount = this.Collumns;
            this.Panel.RowCount = this.Rows;
            this.Panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            this.Panel.BackColor = Color.SlateGray;
            //Remove the default styles from the panel. If we do not do this the playing field gets messed up
            this.Panel.ColumnStyles.Clear();
            this.Panel.RowStyles.Clear();

            //Iterate over all the rows/columns in the playing field. Then apply the same height/width and SizeType
            for (int x = 0; x < this.Panel.RowCount; x++)
            {
                this.Panel.RowStyles.Add(new RowStyle() { Height = 50, SizeType = SizeType.Percent });
            }
            for (int x = 0; x < this.Panel.ColumnCount; x++)
            {
                this.Panel.ColumnStyles.Add(new ColumnStyle() { Width = 50, SizeType = SizeType.Percent });
            }
            for (int i = 0; i < (this.Rows * this.Collumns); i++)
            {
                this.Deck.Add(new Card() { Id = i, Image = this.ThemeImages[i].Value[0].Resource });

                CardPictureBox pictureBox = new CardPictureBox()
                {
                    Dock = DockStyle.Fill,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Name = $"{i}",
                    PairName = this.ThemeImages[i].Value[0].Name
                };
                pictureBox.Click += this.CardClicked;
                this.Panel.Controls.Add(pictureBox);
            }
        }

        public void CheckIfMatch()
        {
            if (this.SelectedCards[0].PairName == this.SelectedCards[1].PairName)
            {
                this.SelectedCards.Clear();
            }
            else
            {
                foreach (CardPictureBox item in this.SelectedCards)
                {
                    item.Image = null;
                }
                this.SelectedCards.Clear();
            }
            this.GameFrozen = false;
        }

        public void ChangeBackground(CardPictureBox item)
        {
            item.BackColor = Color.Red;
        }

        public void CardClicked(object sender, System.EventArgs e)
        {
            CardPictureBox selected = (CardPictureBox)sender;
            if (this.GameFrozen)
            {
                return;
            }
            if (this.SelectedCards.Contains(selected))
            {
                return;
            }
            else
            {
                int cardId = Convert.ToInt32(selected.Name);
                selected.Image = this.Deck[cardId].Image;
                this.SelectedCards.Add(selected);
            }

            if (this.SelectedCards.Count == 2)
            {
                this.GameFrozen = true;
                Task.Delay(750).ContinueWith(x =>
                {
                    this.CheckIfMatch();
                });
            }
        }
    }
}