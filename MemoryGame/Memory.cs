using MemoryGame.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    internal class Memory
    {
        private bool GameIsFrozen { get; set; } = false;
        private bool IsPlayerOnesTurn { get; set; } = true;
        public int SelectedTheme { get; set; } = 0;
        private List<CardPictureBox> Deck { get; set; }
        //Probably need to look for a way to dynamicly do this
        private Dictionary<int, List<CardNameAndImage>> ThemeImages { get; set; } = new Dictionary<int, List<CardNameAndImage>>()
        {
            { 0, new List<CardNameAndImage>()
                {
                    new CardNameAndImage() { Name = "banana", Resource = Resources.banana },
                    new CardNameAndImage() { Name = "banana", Resource=Resources.banana },
                    new CardNameAndImage() { Name = "book", Resource = Resources.book },
                    new CardNameAndImage() { Name = "book", Resource = Resources.book },
                    new CardNameAndImage() { Name = "bug", Resource = Resources.bug },
                    new CardNameAndImage() { Name = "bug", Resource = Resources.bug },
                    new CardNameAndImage() { Name = "car", Resource = Resources.car },
                    new CardNameAndImage() { Name = "car", Resource = Resources.car },
                    new CardNameAndImage() { Name = "monkey", Resource = Resources.monkey },
                    new CardNameAndImage() { Name = "monkey", Resource = Resources.monkey },
                    new CardNameAndImage() { Name = "tornado", Resource = Resources.tornado },
                    new CardNameAndImage() { Name = "tornado", Resource = Resources.tornado },
                    new CardNameAndImage() { Name = "tree", Resource = Resources.tree },
                    new CardNameAndImage() { Name = "tree", Resource = Resources.tree },
                    new CardNameAndImage() { Name = "wine", Resource = Resources.wine },
                    new CardNameAndImage() { Name = "wine", Resource = Resources.wine },
                }
            },
            { 1, new List<CardNameAndImage>()
                {
                    new CardNameAndImage() { Name = "BadBoi", Resource = Resources.BadBoi },
                    new CardNameAndImage() { Name = "BadBoi", Resource = Resources.BadBoi },
                    new CardNameAndImage() { Name = "Ent", Resource = Resources.Ent },
                    new CardNameAndImage() { Name = "Ent", Resource = Resources.Ent },
                    new CardNameAndImage() { Name = "Frodo", Resource = Resources.Frodo },
                    new CardNameAndImage() { Name = "Frodo", Resource = Resources.Frodo },
                    new CardNameAndImage() { Name = "Gandalf", Resource = Resources.Gandalf },
                    new CardNameAndImage() { Name = "Gandalf", Resource = Resources.Gandalf },
                    new CardNameAndImage() { Name = "Ring", Resource = Resources.ring },
                    new CardNameAndImage() { Name = "Ring", Resource = Resources.ring },
                    new CardNameAndImage() { Name = "SwordWieldingLotrGuy", Resource = Resources.SwordWieldingLotrGuy },
                    new CardNameAndImage() { Name = "SwordWieldingLotrGuy", Resource = Resources.SwordWieldingLotrGuy },
                    new CardNameAndImage() { Name = "SomeDwarf", Resource = Resources.SomeDwarf },
                    new CardNameAndImage() { Name = "SomeDwarf", Resource = Resources.SomeDwarf },
                    new CardNameAndImage() { Name = "Smeegle", Resource = Resources.Smeegle },
                    new CardNameAndImage() { Name = "Smeegle", Resource = Resources.Smeegle },
                }
            },

        };
        public HighScore HighScores { get; private set; }
        public int Rows { get; set; } = 4;
        public int Collumns { get; set; } = 4;
        public Player[] Players { get; private set; } = new Player[2];
        public List<CardPictureBox> SelectedCards { get; private set; } //Holds 2 cards that currently are selected
        public TableLayoutPanel Panel { get; private set; }
        public Form1 Form1 { get; set; }
        public List<KeyValuePair<int, string>> Theme { get; private set; } = new List<KeyValuePair<int, string>>();
        public List<GameOptions> GameOptions { get; private set; } = new List<GameOptions>() {
            new GameOptions { Name = "Classic 4x4", Rows = 4, Columns = 4 },
            new GameOptions { Name = "Easy 2x2", Rows = 2, Columns = 2 },
            new GameOptions { Name = "Medium 4x5", Rows = 4, Columns = 5 },
            new GameOptions { Name = "Hard 5x6", Rows = 5, Columns = 6 },
        };

        public Memory(TableLayoutPanel panel, Form1 form1)
        {
            this.Form1 = form1;
            this.Panel = panel;

            this.HighScores = new HighScore();
            this.Theme.Add(new KeyValuePair<int, string>(0, "Animals"));
            this.Theme.Add(new KeyValuePair<int, string>(1, "Lord Of The Rings"));
        }

        /// <summary>
        /// Launches the memory game!
        /// </summary>
        public void StartGame()
        {
            //Sound.PlayEffect(Resources.bangerbeat);
            Sound.StartBackgroundMusic(this.SelectedTheme);
            this.PopulateDeck();
        }

        /// <summary>
        /// Return the total amount of cards in the currently selected theme
        /// </summary>
        /// <returns>Integer total amount of cards</returns>
        public int TotalCardsInCurrentTheme()
        {
            return this.ThemeImages[this.SelectedTheme].Count;
        }

        ///  <summary> 
        ///  Handles setting up all the styling that needs to be done before a game of memory is played.  
        ///  Builds the layout based on the amount of Collumns and Rows the players have selected in the 
        ///  pre-game interface. 
        ///  
        ///  Also Removes default styles given to the column and rows, this needs to be done because it will
        ///  mess up the styles of the dynamicly generated colums and rows.
        ///  </summary>
        private void ConfigurateDeckStyling()
        {
            this.Panel.ColumnCount = this.Collumns;
            this.Panel.RowCount = this.Rows;
            this.Panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            this.Panel.BackColor = Color.SlateGray;
            this.Panel.Dock = DockStyle.Fill;
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
        }

        /// <summary>
        /// Ends the current memory game and redirects to highscores page.
        /// Calls the HighScores.AddToHighScores method to add the previously played game to the highscores
        /// </summary>
        public void EndGame()
        {
            foreach (Player player in this.Players)
            {
                this.HighScores.AddToHighScores(player);
            }
            this.Form1.RedirectToHighScores();
            this.Form1.ClearPanels();
        }

        /// <summary>
        /// Generates the amount of cards needed based on this.Colums and this.Rows.
        /// Cards get assigned images based on the currently selected theme. 
        /// Also handles randomizing the deck each time a game is played. 
        /// </summary>
        private void PopulateDeck()
        {
            this.ConfigurateDeckStyling();
            this.Deck = new List<CardPictureBox>(); 
            this.SelectedCards = new List<CardPictureBox>();

            for (int i = 0; i < (this.Rows * this.Collumns); i++)
            {
                CardPictureBox card = new CardPictureBox()
                {
                    Dock = DockStyle.Fill,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Name = $"{i}", //Couuld make a property that holds an int but we need to cast it to a string later on anyway
                    PairName = this.ThemeImages[this.SelectedTheme][i].Name,
                    CardImage = this.ThemeImages[this.SelectedTheme][i].Resource
                };
               
                card.Click += this.CardClicked;
                this.Deck.Add(card);
            }
            //Randomize the location of the cards in the deck
            this.Deck.Shuffle();
            this.Deck.Shuffle();
            foreach (CardPictureBox card in this.Deck)
            {
                this.Panel.Controls.Add(card);
            }
        }
        /// <summary>
        /// This method check if the selected card in SelectedCards list are a match. 
        /// If it is a match flip a boolean in the PictureBox so that we know this card has previously been solved.
        /// Also calls the ScoreBoard.Add method to increment the score of the player that is currently playing.
        /// We keep track of the current player with the this.IsPlayerOnesTurn bool. After a player turned two cards
        /// this boolean is flipped.
        /// Lastly we clear the SelectedCards list so that we can keep on playing.
        /// </summary>
        public void CheckIfMatch()
        {
            if (this.SelectedCards[0].PairName == this.SelectedCards[1].PairName)
            {
                Sound.PlayEffect(Resources.correct);
                foreach (CardPictureBox card in this.SelectedCards)
	            {
                    //When we have a matching pair mark them as solved to take them out of the game
                    card.IsSolved = true;
	            }
                //Increment the score based on which player was playing
                if (this.IsPlayerOnesTurn)
                    this.Players[0].ScoreBoard.IncreaseScore();
                else
                    this.Players[1].ScoreBoard.IncreaseScore();
            }
            else
            {
                //If there was no match and the card has previously been turned we want to punish the player
                //Check if any of the Cards in the this.SelectedCards list have the boolean HasBeenVisible flipped
                if(this.SelectedCards.FindIndex(c => c.HasBeenVisible == true) >= 0)
                {
                    if (this.IsPlayerOnesTurn)
                        this.Players[0].ScoreBoard.DecreaseScore();
                    else
                        this.Players[1].ScoreBoard.DecreaseScore();
                }
                foreach (CardPictureBox card in this.SelectedCards)
                {
                    //Reset the cards to show no image and set the property to ensure that we know the card has been flipped before
                    card.Image = null;
                    card.HasBeenVisible = true;
                }
            }
            //Update the scoreboard for both players
            this.Form1.UpdateScore($"" +
                    $"{this.Players[0].Name} : {this.Players[0].ScoreBoard.Score}",
                    $"{this.Players[1].Name} : {this.Players[1].ScoreBoard.Score}"
                    );
            this.Form1.UpdateCurrentPlayer(!this.IsPlayerOnesTurn ? $"Current player: {this.Players[0].Name}" : $"Current player: {this.Players[1].Name}");
            this.IsPlayerOnesTurn = !this.IsPlayerOnesTurn;
            this.SelectedCards.Clear();
            this.GameIsFrozen = false;
            //Check if all cards are solved
            if (this.Deck.FindAll(c => c.IsSolved == false).Count == 0)
            {
                this.EndGame();
            }
        }

        /// <summary>
        /// Handles whatever happends when clicking on one of the PictureBoxes(cards) on the playing field.
        /// First we have to run a couple checks to determine if we can proceed;
        /// - We need to check if the game is frozen, this happends after clicking on a card. We need to freeze the game
        ///   because if we do not do so the player has no time to see the second card he tried to match with the first.
        ///   So when we do not freeze the game the player has a (300)ms window to click other cards and mess up what is happenin
        /// - Check if the currently clicked card is already in the this.SelectedCards list, we do not want a user to be able
        ///   to gain points for matching the card with the card he just clicked.
        /// - If a card is solved we do not want to be able to gain points for that either. 
        /// 
        /// When we have two cards in the this.SelectedCards list we want to proceed and check if they match.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CardClicked(object sender, System.EventArgs e)
        {
            CardPictureBox selectedCard = (CardPictureBox)sender;
            //First check all the conditions on which we want to exit early
            if (this.GameIsFrozen || this.SelectedCards.Contains(selectedCard) || selectedCard.IsSolved)
            {
                return;
            }
            else
            {
                //Show the image that we stored in CardImage
                selectedCard.Image = selectedCard.CardImage; 
                this.SelectedCards.Add(selectedCard);
            }
            //Only when 2 cards have been selected we want to freeze the game and check if they match
            if (this.SelectedCards.Count == 2)
            {
                this.GameIsFrozen = true;
                //Delay checking if they match with (300)ms. This is so that the user has a few ms to see what image they flipped
                //when they do not match. Without this its pretty much instant and the user wont be able to see what card they matched
                Task.Delay(300).ContinueWith(x =>
                {
                    this.CheckIfMatch();
                });
            }
        }
    }
}