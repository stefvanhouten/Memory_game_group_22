using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class Form1 : Form
    {
        private CheckBox lastChecked;

        /*  We use delegates to update Form1 from another Thread. 
         *  C# won't allow the UI thread to be update from another thread, for instance from our Memory game class. 
         *  
         *  To bypass this we create a delegate. When we call one of our delegates we do an invokeRequired check,
         *  all this does is it validates if the method was called from another thread. If so we invoke our delegate 
         *  which then handles whatever it is we want to do. 
         */
        public delegate void SetPlayerScoreCallback(string playerOneLabel, string playerTwoLabel);
        public delegate void SetCurrentPlayerCallback(string currentPlayer);
        public delegate void RedirectToHighScoresCallback();
        public delegate void ClearPanelsCallback();
        public delegate void ShowLoadSaveGameCallback();
        public delegate void UpdateHighScoresTableCallback();

        readonly Memory game;

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load; //Add our custom load method 
            this.GameSizeComboBox.SelectedIndexChanged += GameSizeComboBox_SelectedInexChanged;
            //Create an instace of the base class of our memory game
            //Not sure if adding Toolbox items to the class is the right way to go, might want to look into this. 
            this.game = new Memory(tableLayoutPanel1, this);
        }

        /// <summary>
        /// Custom handler that is called when Form1 is loaded for the first time. 
        /// Handles generating theme checkboxes based on available themes. 
        /// Also handles tabControls apearance. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, System.EventArgs e)
        {
            //Hide the tabs on the tabcontrol that we use to navigate our game
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;

            CheckBox box;
            int i = 0;
            foreach(KeyValuePair<int, string> theme in this.game.Theme)
            {
                box = new CheckBox();
                if(i == 0)
                {
                    box.Checked = true;
                    this.lastChecked = box;
                }
                box.Name = $"{theme.Key}";
                box.Text = theme.Value;
                box.AutoSize = true;
                box.Location = new Point(10, i * 20 + 20);
                box.Click += CheckBox_Click;
                tabThemeSelection.Controls.Add(box);
                i++;
            }
            this.GenerateGameSizeDropDownOptions();
            this.ShowLoadGameCheckbox();
            this.UpdateHighScoresTable();
        }

        /// <summary>
        /// We need to use some magic to make this work. C# Won't allow changing the value outside of the UI thread.
        /// for this reason we need to make use of deligates.
        /// InvokeRequired required compares the thread ID of the
        /// calling thread to the thread ID of the creating thread.
        /// If these threads are different, it returns true.
        /// </summary>
        /// <param name="playerOneLabel"></param>
        /// <param name="playerTwoLabel"></param>
        public void UpdateScore(string playerOneLabel, string playerTwoLabel)
        {
            if (this.PlayerOneScoreLabel.InvokeRequired || this.PlayerTwoScoreLabel.InvokeRequired || this.CurrentPlayerPlayingLabel.InvokeRequired)
            {
                SetPlayerScoreCallback d = new SetPlayerScoreCallback(UpdateScore);
                this.Invoke(d, new object[] { playerOneLabel, playerTwoLabel });
            }
            else
            {
                this.PlayerOneScoreLabel.Text = playerOneLabel;
                this.PlayerTwoScoreLabel.Text = playerTwoLabel;
            }
        }

        /// <summary>
        /// Responsible for displaying which player is currently playing. 
        /// Updates the value of the CurrentPlayerPlayingLabel.
        /// </summary>
        /// <param name="currentPlayer"></param>
        public void UpdateCurrentPlayer(string currentPlayer)
        {
            //Update the value of the label that shows which player is currently playing. 
            if (this.CurrentPlayerPlayingLabel.InvokeRequired)
            {
                this.Invoke(new SetCurrentPlayerCallback(UpdateCurrentPlayer), new object[] { currentPlayer });
            }
            else
            {
                this.CurrentPlayerPlayingLabel.Text = currentPlayer;
            }
        }

        /// <summary>
        /// Handles display for the LoadSavedGameCheckbox. Either hides or displays it based on
        /// available savegame data. 
        /// </summary>
        public void ShowLoadGameCheckbox()
        {
            if (LoadSavedGameCheckBox.InvokeRequired)
            {
                this.Invoke(new ShowLoadSaveGameCallback(ShowLoadGameCheckbox));
            }
            else
            {
                if (this.game.HasUnfinishedGame)
                {
                    LoadSavedGameCheckBox.Checked = false;
                    LoadSavedGameCheckBox.Visible = true;
                }
                else
                {
                    LoadSavedGameCheckBox.Visible = false;
                }
            }
        }

        /// <summary>
        /// Clear the HighScoresGridView and repopulate it with available data stored in the
        /// HighScores class. 
        /// </summary>
        public void UpdateHighScoresTable()
        {
            if (this.HighScoresGridView.InvokeRequired)
            {
                this.Invoke(new RedirectToHighScoresCallback(UpdateHighScoresTable));
            }
            else
            {
                this.HighScoresGridView.Rows.Clear();
                List<HighScoreListing> highScores = this.game.HighScores.highScores;
                foreach (HighScoreListing highScoreListing in highScores)
                {
                    this.HighScoresGridView.Rows.Add(highScoreListing.Name, highScoreListing.Score);
                }
                this.HighScoresGridView.RowCount = 20;
            }
        }
        /// <summary>
        /// Redirects user to the highscores tab.
        /// </summary>
        public void RedirectToHighScores()
        {
            if (this.tabControl1.InvokeRequired)
            {
                this.Invoke(new RedirectToHighScoresCallback(RedirectToHighScores));
            }
            else
            {
                this.tabControl1.SelectedTab = tabHighScores;
            }
        }

        /// <summary>
        /// Clear the memory board and remove all objects from the tableLayout.
        /// This ensures that when we start a new game of memory the board is ready to be used 
        /// with new and fresh objects. 
        /// </summary>
        public void ClearPanels()
        {
            if (this.tableLayoutPanel1.InvokeRequired)
            {
                this.Invoke(new ClearPanelsCallback(ClearPanels));
            }
            else
            {
                this.tableLayoutPanel1.Controls.Clear();
            }
        }

        /// <summary>
        /// Populate the dropdown menu with available gamesizes. 
        /// </summary>
        private void GenerateGameSizeDropDownOptions()
        {
            this.GameSizeComboBox.Items.Clear();
            int totalCards = this.game.TotalCardsInCurrentTheme();
            foreach(GameOptions item in this.game.GameOptions)
            {
                if (totalCards >= item.CardsRequired)
                {
                    this.GameSizeComboBox.Items.Add(item);
                }
            }
            this.GameSizeComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// This is bound to an event. This is pretty much an event listener that changes
        /// the Memory games Rows and Columns based on selected gamesize.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameSizeComboBox_SelectedInexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            GameOptions options = (GameOptions)comboBox.SelectedItem;
            this.game.Rows = options.Rows;
            this.game.Collumns = options.Columns;
        }

        /// <summary>
        /// Handles behaviour for themeselection. Forces one theme to be selected. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_Click(object sender, EventArgs e)
        {
            CheckBox activeCheckBox = sender as CheckBox;
            //Handle toggling behaviour in the checkboxes. Don't allow unselecting only active checkbox
            if (activeCheckBox != lastChecked && lastChecked != null)
                lastChecked.Checked = false;
            else
                lastChecked.Checked = true;

            lastChecked = activeCheckBox.Checked ? activeCheckBox : null;
            //Set the currently selected theme
            this.game.SelectedTheme = Convert.ToInt32(activeCheckBox.Name);
            //Re-generate the options that are displayed in the pre game view based on selected theme. 
            this.GenerateGameSizeDropDownOptions();
        }

        /// <summary>
        /// Handles pausing and resuming of our Memory game. 
        /// Updates PauseResumeBtn text value accordingly.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PauseResumeBtn_Click(object sender, EventArgs e)
        {
            if (PauseResumeBtn.Text.Contains("Pause"))
            {
                this.game.PauseGame();
                PauseResumeBtn.Text = "Resume";
            }
            else
            {
                this.game.ResumeGame();
                PauseResumeBtn.Text = "Pause";
            }
        }

        /// <summary>
        /// Event listener for when our LoadSaveGameCheckbox is clicked. 
        /// Calls method from Memory class to load in data from savefile. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadSavedGameCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.game.ResumeGame(loadFromSaveFile: true);
            tabControl1.SelectedTab = tabMemory;
        }

        //<-----------------------------------------------------------NAVIGATION----------------------------------------------------------->
        /// <summary>
        /// Validates that two player names have been provided. 
        /// If so create two new instances of Player and add them to the Memory.Players array.
        /// Personalize the memory game playing field by changing the labels to the player names.
        /// Call for the memory class to start the game, this will create a playing field.
        /// After this is done we switch to the playing field.
        /// Raises: 
        ///     MessageBox: MessageBox.Show is called whenever user fails to provide two player names
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonStartMemoryGame_Click(object sender, EventArgs e)
        {
            string playerOne = textBox1.Text;
            string playerTwo = textBox2.Text;
            if(String.IsNullOrEmpty(playerOne) || String.IsNullOrEmpty(playerTwo))
            {
                MessageBox.Show("Player names cannot be empty", "Validation error", MessageBoxButtons.OK);
                return;
            }
            
            if (playerOne.Equals(playerTwo))
            {
                MessageBox.Show("Player names cannot be the same!", "Input error", MessageBoxButtons.OK);
                return;
            }

            //Should probably make a method for adding new players to the game. This can be exploited
            this.game.Players[0] = new Player(playerOne);
            this.game.Players[1] = new Player(playerTwo);
            PlayerOneScoreLabel.Text = $"{this.game.Players[0].Name} : {this.game.Players[0].ScoreBoard.Score}";
            PlayerTwoScoreLabel.Text = $"{this.game.Players[1].Name} : {this.game.Players[1].ScoreBoard.Score}";
            CurrentPlayerPlayingLabel.Text = $"Current player: {this.game.Players[0].Name}";
            this.game.StartGame();
            tabControl1.SelectedTab = tabMemory;
        }

        /// <summary>
        /// Redirects to the pre-game tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonStartGame_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPreGame;
        }

        /// <summary>
        /// Redirects to the highscores tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonHighScores_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabHighScores;
        }

        /// <summary>
        /// Redirects to the theme selection tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSelectTheme_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabThemeSelection;
        }

        /// <summary>
        /// Redirects to the home tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonHighScoresHome_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabHome;
        }

        /// <summary>
        /// Redirects to the home tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonThemeSelectionHome_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabHome;
        }

        /// <summary>
        /// Redirects to the pre-game tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPreGameHome_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabHome;

        }

        //<--------------------------------------------------------END NAVIGATION--------------------------------------------------------->

    }
}
