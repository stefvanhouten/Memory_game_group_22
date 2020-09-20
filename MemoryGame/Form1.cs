using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public delegate void EventHandler();
namespace MemoryGame
{
    public partial class Form1 : Form
    {
        Memory game;

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load; //Add our custom load method 
            //Create an instace of the base class of our memory game
            //Not sure if adding Toolbox items to the class is the right way to go, might want to look into this. 
            this.game = new Memory(tableLayoutPanel1);
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            //Hide the tabs on the tabcontrol that we use to navigate our game
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;
        }

        //NAVIGATION 
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
            this.game.StartGame();
            tabControl1.SelectedTab = tabMemory;
        }

        private void ButtonStartGame_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPreGame;
        }

    }
}
