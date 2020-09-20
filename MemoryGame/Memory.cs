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
        public bool IsSolved {get; set;} = false;
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
                /* We need to create a 'fake' deck with cards and the backgrouund image that we want to use.
                 * There seems to be no way of hiding the PictureBox image without losing the image in the process,
                 * For that reason we create a fictional deck called this.Deck and store our images in there.
                 * 
                 * When we click a PictureBox we look up the fictional Deck and then set that PictureBox background image
                 * to the image that is provided by the fictional deck. 
                 */
                this.Deck.Add(new Card() { Id = i, Image = this.ThemeImages[this.SelectedTheme][i].Resource });
                CardPictureBox card = new CardPictureBox()
                {
                    Dock = DockStyle.Fill,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Name = $"{i}", //Couuld make a property that holds an int but we need to cast it to a string later on anyway
                    PairName = this.ThemeImages[this.SelectedTheme][i].Name
                };
                card.Click += this.CardClicked;
                this.Panel.Controls.Add(card);
            }
        }

        public void CheckIfMatch()
        {
            /*  This method check if the selected card in SelectedCards list are a match. 
             *  If it is a match flip a boolean in the PictureBox so that we know this card has previously been solved.
             *  
             *  Also calls the ScoreBoard.Add method to increment the score of the player that is currently playing.
             *  We keep track of the current player with the this.IsPlayerOnesTurn bool. After a player turned two cards
             *  this boolean is flipped.
             *  
             *  Lastly we clear the SelectedCards list so that we can keep on playing.
             */
            if (this.SelectedCards[0].PairName == this.SelectedCards[1].PairName)
            {
                foreach (CardPictureBox card in this.SelectedCards)
	            {
                    card.IsSolved = true;
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
            }
            else
            {
                foreach (CardPictureBox card in this.SelectedCards)
                {
                    card.Image = null;
                }
            }
            this.SelectedCards.Clear();
            this.GameFrozen = false;
        }

        public void CardClicked(object sender, System.EventArgs e)
        {
            /*  Handles whatever happends when clicking on one of the PictureBoxes(cards) on the playing field.
             *  First we have to run a couple checks to determine if we can proceed;
             *  - We need to check if the game is frozen, this happends after clicking on a card. We need to freeze the game
             *    because if we do not do so the player has no time to see the second card he tried to match with the first. 
             *    So when we do not freeze the game the player has a (300)ms window to click other cards and mess up what is happening.
             *    When the game is frozen we have to wait untill all checks are done and we regain control.
             *  - Check if the currently clicked card is already in the this.SelectedCards list, we do not want a user to be able
             *    to gain points for matching the card with the card he just clicked.
             *  - If a card is solved we do not want to be able to gain points for that either. 
             *  
             *  If we manage to get past the checks we want to get the cardId and load the image from the virtual deck.
             *  Then add the selected card to the list this.SelectedCards so that we know this card has been clicked this turn.
             *  
             *  When we have two cards in the this.SelectedCards list we want to proceed and check if they match. 
             */
            CardPictureBox selectedCard = (CardPictureBox)sender;
            //First check all the conditions on which we want to exit early
            if (this.GameFrozen || this.SelectedCards.Contains(selectedCard) || selectedCard.IsSolved)
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
                Task.Delay(300).ContinueWith(x =>
                {
                    this.CheckIfMatch();
                });
            }
        }
    }
}