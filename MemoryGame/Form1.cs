﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class Form1 : Form
    {
        readonly Memory game;
        delegate void SetPlayerScoreCallback(string playerOneLabel, string playerTwoLabel);
        delegate void SetCurrentPlayerCallback(string currentPlayer);


        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load; //Add our custom load method 
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
        }

        public void UpdateScore(string playerOneLabel, string playerTwoLabel)
        {
            /*  We need to use some magic to make this work. C# Won't allow changing the value outside of the UI thread.
             *  for this reason we need to make use of deligates.
             *  
             *  InvokeRequired required compares the thread ID of the
             *  calling thread to the thread ID of the creating thread.
             *  If these threads are different, it returns true.
             */
            if (this.label3.InvokeRequired || this.label4.InvokeRequired || this.label5.InvokeRequired)
            {
                SetPlayerScoreCallback d = new SetPlayerScoreCallback(UpdateScore);
                this.Invoke(d, new object[] { playerOneLabel, playerTwoLabel });
            }
            else
            {
                this.label3.Text = playerOneLabel;
                this.label4.Text = playerTwoLabel;
            }
        }

        public void UpdateCurrentPlayer(string currentPlayer)
        {
            //Update the value of the label that shows which player is currently playing. 
            if (this.label5.InvokeRequired)
            {
                SetCurrentPlayerCallback d = new SetCurrentPlayerCallback(UpdateCurrentPlayer);
                this.Invoke(d, new object[] { currentPlayer });
            }
            else
            {
                this.label5.Text = currentPlayer;
            }
        }

        private void ButtonStartMemoryGame_Click(object sender, EventArgs e)
        {
            /* Validates that two player names have been provided. 
             * If so create two new instances of Player and add them to the Memory.Players array.
             * Personalize the memory game playing field by changing the labels to the player names. 
             * 
             * Call for the memory class to start the game, this will create a playing field. 
             * After this is done we switch to the playing field.
             * 
             * Raises: 
             *        MessageBox: MessageBox.Show is called whenever user fails to provide two player names
             */
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
            label3.Text = $"{this.game.Players[0].Name} : {this.game.Players[0].ScoreBoard.Score}";
            label4.Text = $"{this.game.Players[1].Name} : {this.game.Players[1].ScoreBoard.Score}";
            label5.Text = $"Current player: {this.game.Players[0].Name}";
            this.game.StartGame();
            tabControl1.SelectedTab = tabMemory;
        }

        //<-----------------------------------------------------------NAVIGATION----------------------------------------------------------->
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
