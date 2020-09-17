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
        Memory game;
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load; //Add our custom load method 
            //Create an instace of the base class of our memory game
            this.game = new Memory();
        }
        private void Form1_Load(object sender, System.EventArgs e)
        {
            //Hide the tabs on the tabcontrol that we use to navigate our game
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            //Build the memory deck 
            tableLayoutPanel1.ColumnCount = this.game.Collumns;
            tableLayoutPanel1.RowCount = this.game.Rows;
            tableLayoutPanel1.BackColor = Color.SlateGray;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            tableLayoutPanel1.ColumnStyles.Clear(); //Clear default Toolbox settings
            tableLayoutPanel1.RowStyles.Clear();    //Clear default Toolbox settings
            //Apply the settings we want to the grid
            for (int x = 0; x < tableLayoutPanel1.RowCount; x++)
                tableLayoutPanel1.RowStyles.Add(new RowStyle() { Height = 50, SizeType = SizeType.Percent });
            for (int x = 0; x < tableLayoutPanel1.ColumnCount; x++)
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle() { Width = 50, SizeType = SizeType.Percent });
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
