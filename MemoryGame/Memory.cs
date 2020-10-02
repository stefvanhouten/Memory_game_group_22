using MemoryGame.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{

 
    /// <summary>
    /// Base class for the Memory game. 
    /// </summary>
    internal class Memory
    {
        private bool GameIsFrozen { get; set; } = false;
        private bool IsPlayerOnesTurn { get; set; } = true;
        private List<CardPictureBox> Deck { get; set; }
        private readonly Files SaveGameFile = new Files(Path.Combine(Directory.GetCurrentDirectory(), "savegame.txt"));
        //Probably need to look for a way to dynamicly do this
        private Dictionary<int, List<CardNameAndImage>> ThemeImages { get; set; } = new Dictionary<int, List<CardNameAndImage>>()
        {
            { 0, new List<CardNameAndImage>()
                {
                    new CardNameAndImage() { Name = "Aussie", Resource = Resources.aussie },
                    new CardNameAndImage() { Name = "Aussie", Resource = Resources.aussie },
                    new CardNameAndImage() { Name = "black wolf", Resource = Resources.black_wolf },
                    new CardNameAndImage() { Name = "black wolf", Resource = Resources.black_wolf },
                    new CardNameAndImage() { Name = "cavia", Resource = Resources.cavia },
                    new CardNameAndImage() { Name = "cavia", Resource = Resources.cavia },
                    new CardNameAndImage() { Name = "cheetah", Resource = Resources.cheetah },
                    new CardNameAndImage() { Name = "cheetah", Resource = Resources.cheetah },
                    new CardNameAndImage() { Name = "deer", Resource = Resources.deer },
                    new CardNameAndImage() { Name = "deer", Resource = Resources.deer },
                    new CardNameAndImage() { Name = "egel", Resource = Resources.egel },
                    new CardNameAndImage() { Name = "egel", Resource = Resources.egel },
                    new CardNameAndImage() { Name = "elephant", Resource = Resources.elephant },
                    new CardNameAndImage() { Name = "elephant", Resource = Resources.elephant },
                    new CardNameAndImage() { Name = "giraffe", Resource = Resources.giraffe },
                    new CardNameAndImage() { Name = "giraffe", Resource = Resources.giraffe },
                    new CardNameAndImage() { Name = "gorilla", Resource = Resources.gorilla },
                    new CardNameAndImage() { Name = "gorilla", Resource = Resources.gorilla },
                    new CardNameAndImage() { Name = "horse", Resource = Resources.horse },
                    new CardNameAndImage() { Name = "horse", Resource = Resources.horse },
                    new CardNameAndImage() { Name = "monkey", Resource = Resources.monkey },
                    new CardNameAndImage() { Name = "monkey", Resource = Resources.monkey },
                    new CardNameAndImage() { Name = "oerangutan", Resource = Resources.oerangutan },
                    new CardNameAndImage() { Name = "oerangutan", Resource = Resources.oerangutan },
                    new CardNameAndImage() { Name = "orca", Resource = Resources.orca },
                    new CardNameAndImage() { Name = "orca", Resource = Resources.orca },
                    new CardNameAndImage() { Name = "parrot", Resource = Resources.parrot },
                    new CardNameAndImage() { Name = "parrot", Resource = Resources.parrot },
                    new CardNameAndImage() { Name = "penguin", Resource = Resources.penguin },
                    new CardNameAndImage() { Name = "penguin", Resource = Resources.penguin },
                    new CardNameAndImage() { Name = "polar bear", Resource = Resources.polar_bear },
                    new CardNameAndImage() { Name = "polar bear", Resource = Resources.polar_bear },
                    new CardNameAndImage() { Name = "rabbit", Resource = Resources.rabbit },
                    new CardNameAndImage() { Name = "rabbit", Resource = Resources.rabbit },
                    new CardNameAndImage() { Name = "red canary", Resource = Resources.red_canary },
                    new CardNameAndImage() { Name = "red canary", Resource = Resources.red_canary },
                    new CardNameAndImage() { Name = "red panda", Resource = Resources.red_panda },
                    new CardNameAndImage() { Name = "red panda", Resource = Resources.red_panda },
                    new CardNameAndImage() { Name = "rhino", Resource = Resources.rhino },
                    new CardNameAndImage() { Name = "rhino", Resource = Resources.rhino },
                    new CardNameAndImage() { Name = "seal", Resource = Resources.seal },
                    new CardNameAndImage() { Name = "seal", Resource = Resources.seal },
                    new CardNameAndImage() { Name = "shark", Resource = Resources.shark },
                    new CardNameAndImage() { Name = "shark", Resource = Resources.shark },
                    new CardNameAndImage() { Name = "sloth", Resource = Resources.sloth },
                    new CardNameAndImage() { Name = "sloth", Resource = Resources.sloth },
                    new CardNameAndImage() { Name = "tiger", Resource = Resources.tiger },
                    new CardNameAndImage() { Name = "tiger", Resource = Resources.tiger },
                    new CardNameAndImage() { Name = "turtle", Resource = Resources.turtle },
                    new CardNameAndImage() { Name = "turtle", Resource = Resources.turtle },
                    new CardNameAndImage() { Name = "ugly fish", Resource = Resources.ugly_fish },
                    new CardNameAndImage() { Name = "ugly fish", Resource = Resources.ugly_fish },
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

        public bool HasUnfinishedGame { get; set; } = false;
        public int SelectedTheme { get; set; } = 0;
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

            //Check if there is a savefile that isn't empty
            if (this.SaveGameFile.GetFileContent().Length > 0)
                this.HasUnfinishedGame = true;
        }

        /// <summary>
        /// Launches the memory game!
        /// </summary>
        public void StartGame()
        {
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
            this.Form1.UpdateHighScoresTable();
        }

        public void PauseGame()
        {
            this.GameIsFrozen = true;
            dynamic gameState = new System.Dynamic.ExpandoObject();
            List<CardPictureBoxJson> jsonConvertableDeck = new List<CardPictureBoxJson>();
            List<CardPictureBoxJson> jsonConvertableSelectedCards = new List<CardPictureBoxJson>();

            foreach (CardPictureBox card in this.Deck)
            {
                jsonConvertableDeck.Add(new CardPictureBoxJson() { 
                    Name = card.Name, 
                    IsSolved = card.IsSolved, 
                    PairName = card.PairName, 
                    HasBeenVisible = card.HasBeenVisible ,
                    IsSelected = this.SelectedCards.Any(c => c.Name == card.Name)
                });
            }

            gameState.IsPlayerOnesTurn = this.IsPlayerOnesTurn;
            gameState.SelectedTheme = this.SelectedTheme;
            gameState.Deck = jsonConvertableDeck;
            gameState.Rows = this.Rows;
            gameState.Collumns = this.Collumns;
            gameState.Players = this.Players;
            string json = JsonConvert.SerializeObject(gameState, Formatting.Indented);
            //TODO: clean this up and maybe add it to constructor/default value. Should we store multiple games or just one?
            this.SaveGameFile.Create();
            this.SaveGameFile.WriteToFile(json);
        }

        /// <summary>
        /// Resumes paused game. If it needs to resume game from savefile load file contents back into the memory class
        /// and rebuild the deck. 
        /// </summary>
        /// <param name="loadFromSaveFile"></param>
        public void ResumeGame(bool loadFromSaveFile = false)
        {
            if (loadFromSaveFile)
            {
                //Since we are bypassing this.Populatedeck() we need to do some things again
                //Create new empty lists for deck and selectedcards
                this.Deck = new List<CardPictureBox>();
                this.SelectedCards = new List<CardPictureBox>();
                //Use a dynamic object for the next part, could also create a custom class for this
                dynamic gameState = new System.Dynamic.ExpandoObject();
                //Load the data from the savegamefile
                string json = this.SaveGameFile.GetFileContent();
                //Deserialize the json
                gameState = JsonConvert.DeserializeObject(json);
                //For the next part we need to cast/convert all properties that are stored in our dyanmic list to the appropriate type
                this.IsPlayerOnesTurn = (bool)gameState.IsPlayerOnesTurn;
                this.SelectedTheme = (int)gameState.SelectedTheme;
                this.Rows = (int)gameState.Rows;
                this.Collumns = (int)gameState.Collumns;
                this.Players = gameState.Players.ToObject<List<Player>>().ToArray(); //Seems dirty 
                //It is important that we style our deck after we loaded in all the settings, otherwise we get a default 4*4 playing field
                //even though the settings may state otherwise
                this.ConfigurateDeckStyling();
                List<CardPictureBoxJson> deck = new List<CardPictureBoxJson>();
                deck = gameState.Deck.ToObject<List<CardPictureBoxJson>>();

                foreach (CardPictureBoxJson jsonCard in deck)
                {
                    CardNameAndImage pairNameAndImage = this.ThemeImages[this.SelectedTheme].Find(item => item.Name == jsonCard.PairName);
                    CardPictureBox card = new CardPictureBox()
                    {
                        Dock = DockStyle.Fill,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Name = jsonCard.Name,
                        IsSolved = jsonCard.IsSolved,
                        HasBeenVisible = jsonCard.HasBeenVisible,
                        PairName = pairNameAndImage.Name,
                        CardImage = pairNameAndImage.Resource,
                        Image = (jsonCard.IsSolved) ? pairNameAndImage.Resource : null //Show image based on if it was solved 
                    };
                    card.Click += this.CardClicked;
                    //Check if the card is currently selected, if so add it to the selectedCards list.
                    if (jsonCard.IsSelected)
                    {
                        this.SelectedCards.Add(card);
                        card.Image = pairNameAndImage.Resource;
                    }
                    this.Deck.Add(card);
                }
                foreach (CardPictureBox card in this.Deck)
                {
                    this.Panel.Controls.Add(card);
                }
            }
            //Remove the savegame from the savefile to prevent abuse
            this.SaveGameFile.WriteToFile("", overwrite: true);
            this.HasUnfinishedGame = false;
            this.Form1.ShowLoadGameCheckbox();
            //Pass back control to the player
            this.GameIsFrozen = false;
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