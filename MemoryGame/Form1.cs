using System;
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
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load; //Add our custom load method 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.RowCount = 4;
            //Create an instace of the base class of our memory game
            Memory game = new Memory();
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

        private void buttonSelectTheme_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabThemeSelection;
        }

        private void buttonHighScoresHome_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabHome;
        }
        private void buttonThemeSelectionHome_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabHome;
        }

        private void buttonPreGameHome_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabHome;

        }
        private void buttonStartMemoryGame_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabMemory;

        }

        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPreGame;
        }

    }
}
