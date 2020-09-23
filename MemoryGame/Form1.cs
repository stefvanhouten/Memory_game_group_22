using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class Form1 : Form
    {
        readonly Memory game;
        public delegate void SetPlayerScoreCallback(string playerOneLabel, string playerTwoLabel);
        public delegate void SetCurrentPlayerCallback(string currentPlayer);
        public delegate void RedirectToHighScoresCallback();
        public delegate void ClearPanelsCallback();
        private CheckBox lastChecked;

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load; //Add our custom load method 
            this.GameSizeComboBox.SelectedIndexChanged += GameSizeComboBox_SelectedInexChanged;
            //Create an instace of the base class of our memory game
            //Not sure if adding Toolbox items to the class is the right way to go, might want to look into this. 
            this.game = new Memory(tableLayoutPanel1, this);
        }

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

        public void UpdateCurrentPlayer(string currentPlayer)
        {
            //Update the value of the label that shows which player is currently playing. 
            if (this.CurrentPlayerPlayingLabel.InvokeRequired)
            {
                SetCurrentPlayerCallback d = new SetCurrentPlayerCallback(UpdateCurrentPlayer);
                this.Invoke(d, new object[] { currentPlayer });
            }
            else
            {
                this.CurrentPlayerPlayingLabel.Text = currentPlayer;
            }
        }

        public void RedirectToHighScores()
        {
            if (this.tabControl1.InvokeRequired)
            {
                RedirectToHighScoresCallback redirect = new RedirectToHighScoresCallback(RedirectToHighScores);
                this.Invoke(redirect);
            }
            else
            {
                this.tabControl1.SelectedTab = tabHighScores;
            }
        }

        public void ClearPanels()
        {
            if (this.tableLayoutPanel1.InvokeRequired)
            {
                ClearPanelsCallback clear = new ClearPanelsCallback(ClearPanels);
                this.Invoke(clear);
            }
            else
            {
                this.tableLayoutPanel1.Controls.Clear();
            }
        }

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

        private void GameSizeComboBox_SelectedInexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            GameOptions options = (GameOptions)comboBox.SelectedItem;
            this.game.Rows = options.Rows;
            this.game.Collumns = options.Columns;
        }


        private void CheckBox_Click(object sender, EventArgs e)
        {
            CheckBox activeCheckBox = sender as CheckBox;
            if (activeCheckBox != lastChecked && lastChecked != null)
                lastChecked.Checked = false;
            else
                lastChecked.Checked = true;

            lastChecked = activeCheckBox.Checked ? activeCheckBox : null;
            this.game.SelectedTheme = Convert.ToInt32(activeCheckBox.Name);
            this.GenerateGameSizeDropDownOptions();
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
            //Should probably make a method for adding new players to the game. This can be exploited
            this.game.Players[0] = new Player(playerOne);
            this.game.Players[1] = new Player(playerTwo);
            PlayerOneScoreLabel.Text = $"{this.game.Players[0].Name} : {this.game.Players[0].ScoreBoard.Score}";
            PlayerTwoScoreLabel.Text = $"{this.game.Players[1].Name} : {this.game.Players[1].ScoreBoard.Score}";
            CurrentPlayerPlayingLabel.Text = $"Current player: {this.game.Players[0].Name}";
            this.game.StartGame();
            tabControl1.SelectedTab = tabMemory;
        }

        private void ButtonStartGame_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPreGame;
        }

        private void ButtonHighScores_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabHighScores;
        }

        private void ButtonSelectTheme_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabThemeSelection;
        }

        private void ButtonHighScoresHome_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabHome;
        }
        private void ButtonThemeSelectionHome_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabHome;
        }

        private void ButtonPreGameHome_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabHome;

        }
        //<--------------------------------------------------------END NAVIGATION--------------------------------------------------------->

    }
}
