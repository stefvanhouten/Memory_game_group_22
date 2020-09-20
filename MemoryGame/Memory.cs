using MemoryGame.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Permissions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    public class CardPictureBox : PictureBox
    {
        public string PairName { get; set; }
        public bool isSolved {get; set;} = false;
    }

    public struct CardImage
    {
        public string Name { get; set; }
        public Bitmap Resource { get; set; }
    }

    internal class Memory
    {
        private bool GameFrozen { get; set; } = false;
        private bool IsPlayerOnesTurn { get; set; } = true;
        private List<KeyValuePair<int, string>> Theme = new List<KeyValuePair<int, string>>();
        private int SelectedTheme { get; set; } = 0;
        //Probably need to look for a way to dynamicly do this
        private Dictionary<int, List<CardImage>> ThemeImages = new Dictionary<int, List<CardImage>>()
        {
            { 0, new List<CardImage>() { 
                new CardImage() { Name = "banana", Resource = Resources.banana }, 
                new CardImage() { Name = "book", Resource = Resources.book },
                new CardImage() { Name = "bug", Resource = Resources.bug },
                new CardImage() { Name = "car", Resource = Resources.car },
                new CardImage() { Name = "monkey", Resource = Resources.monkey },
                new CardImage() { Name = "tornado", Resource = Resources.tornado },
                new CardImage() { Name = "tree", Resource = Resources.tree },
                new CardImage() { Name = "wine", Resource = Resources.wine },
                new CardImage() { Name = "banana", Resource=Resources.banana },
                new CardImage() { Name = "book", Resource = Resources.book },
                new CardImage() { Name = "bug", Resource = Resources.bug },
                new CardImage() { Name = "car", Resource = Resources.car },
                new CardImage() { Name = "monkey", Resource = Resources.monkey },
                new CardImage() { Name = "tornado", Resource = Resources.tornado },
                new CardImage() { Name = "tree", Resource = Resources.tree },
                new CardImage() { Name = "wine", Resource = Resources.wine },
            } },
        };

        public int Rows { get; private set; } = 4;
        public int Collumns { get; private set; } = 4;

        public Player[] Players { get; private set; } = new Player[2];

        public List<Card> Deck { get; private set; } 
        public List<CardPictureBox> SelectedCards { get; private set; } //Holds 2 cards that currently are selected

        public TableLayoutPanel Panel { get; private set; }

        public Memory(TableLayoutPanel panel)
        {
            this.Panel = panel;
            this.Theme.Add(new KeyValuePair<int, string>(0, "Animals"));
        }

        public void StartGame()
        {
            this.PopulateDeck();
        }

        public int Test()
        {
            return 20;
        }

        public void PopulateDeck()
        {
            //Card might not be needed anymore. Might have to refracture to use CardPictureBox since we can add custom fields/properties
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
                this.Deck.Add(new Card() { Id = i, Image = this.ThemeImages[this.SelectedTheme][i].Resource });
                CardPictureBox card = new CardPictureBox()
                {
                    Dock = DockStyle.Fill,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Name = $"{i}",
                    PairName = this.ThemeImages[this.SelectedTheme][i].Name
                };
                card.Click += this.CardClicked;
                this.Panel.Controls.Add(card);
            }
        }

        public void CheckIfMatch()
        {
            if (this.SelectedCards[0].PairName == this.SelectedCards[1].PairName)
            {
                foreach (CardPictureBox card in this.SelectedCards)
	            {
                    card.isSolved = true;
	            }
                if (this.IsPlayerOnesTurn)
                {
                    this.Players[0].ScoreBoard.Add();
                }
                else
                {
                    this.Players[1].ScoreBoard.Add();
                }

                this.IsPlayerOnesTurn = !this.IsPlayerOnesTurn;
                this.SelectedCards.Clear();
            }
            else
            {
                foreach (CardPictureBox card in this.SelectedCards)
                {
                    card.Image = null;
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
            //Handles what happends whenever a card/picturebox is clicked.
            CardPictureBox selectedCard = (CardPictureBox)sender;
            //First check all the conditions on which we want to exit early
            if (this.GameFrozen || this.SelectedCards.Contains(selectedCard) || selectedCard.isSolved)
            {
                return;
            }
            else
            {
                int cardId = Convert.ToInt32(selectedCard.Name);
                selectedCard.Image = this.Deck[cardId].Image;
                this.SelectedCards.Add(selectedCard);
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