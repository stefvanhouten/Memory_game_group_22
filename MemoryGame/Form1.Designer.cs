namespace MemoryGame
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabHighScores = new System.Windows.Forms.TabPage();
            this.buttonHighScoresHome = new System.Windows.Forms.Button();
            this.HighScoresGridView = new System.Windows.Forms.DataGridView();
            this.Player = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelHighScores = new System.Windows.Forms.Label();
            this.tabHome = new System.Windows.Forms.TabPage();
            this.buttonSelectTheme = new System.Windows.Forms.Button();
            this.buttonHighScores = new System.Windows.Forms.Button();
            this.buttonStartGame = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabThemeSelection = new System.Windows.Forms.TabPage();
            this.buttonThemeSelectionHome = new System.Windows.Forms.Button();
            this.labelThemeSelect = new System.Windows.Forms.Label();
            this.tabPreGame = new System.Windows.Forms.TabPage();
            this.LoadSavedGameCheckBox = new System.Windows.Forms.CheckBox();
            this.GameSizeComboBox = new System.Windows.Forms.ComboBox();
            this.buttonStartMemoryGame = new System.Windows.Forms.Button();
            this.buttonPreGameHome = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabMemory = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PauseResumeBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PlayerOneScoreLabel = new System.Windows.Forms.Label();
            this.CurrentPlayerPlayingLabel = new System.Windows.Forms.Label();
            this.PlayerTwoScoreLabel = new System.Windows.Forms.Label();
            this.tabHighScores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HighScoresGridView)).BeginInit();
            this.tabHome.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabThemeSelection.SuspendLayout();
            this.tabPreGame.SuspendLayout();
            this.tabMemory.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tabHighScores
            // 
            this.tabHighScores.Controls.Add(this.buttonHighScoresHome);
            this.tabHighScores.Controls.Add(this.HighScoresGridView);
            this.tabHighScores.Controls.Add(this.labelHighScores);
            this.tabHighScores.Location = new System.Drawing.Point(4, 22);
            this.tabHighScores.Name = "tabHighScores";
            this.tabHighScores.Padding = new System.Windows.Forms.Padding(3);
            this.tabHighScores.Size = new System.Drawing.Size(653, 429);
            this.tabHighScores.TabIndex = 1;
            this.tabHighScores.Text = "HighScore";
            this.tabHighScores.UseVisualStyleBackColor = true;
            // 
            // buttonHighScoresHome
            // 
            this.buttonHighScoresHome.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonHighScoresHome.Location = new System.Drawing.Point(3, 376);
            this.buttonHighScoresHome.Name = "buttonHighScoresHome";
            this.buttonHighScoresHome.Size = new System.Drawing.Size(647, 50);
            this.buttonHighScoresHome.TabIndex = 2;
            this.buttonHighScoresHome.Text = "Home";
            this.buttonHighScoresHome.UseVisualStyleBackColor = true;
            this.buttonHighScoresHome.Click += new System.EventHandler(this.ButtonHighScoresHome_Click);
            // 
            // HighScoresGridView
            // 
            this.HighScoresGridView.AllowUserToAddRows = false;
            this.HighScoresGridView.AllowUserToDeleteRows = false;
            this.HighScoresGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.HighScoresGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HighScoresGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Player,
            this.Score});
            this.HighScoresGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HighScoresGridView.Location = new System.Drawing.Point(3, 16);
            this.HighScoresGridView.Name = "HighScoresGridView";
            this.HighScoresGridView.ReadOnly = true;
            this.HighScoresGridView.Size = new System.Drawing.Size(647, 410);
            this.HighScoresGridView.TabIndex = 1;
            // 
            // Player
            // 
            this.Player.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Player.HeaderText = "Player";
            this.Player.Name = "Player";
            this.Player.ReadOnly = true;
            // 
            // Score
            // 
            this.Score.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Score.HeaderText = "Score";
            this.Score.Name = "Score";
            this.Score.ReadOnly = true;
            // 
            // labelHighScores
            // 
            this.labelHighScores.AutoSize = true;
            this.labelHighScores.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelHighScores.Location = new System.Drawing.Point(3, 3);
            this.labelHighScores.Name = "labelHighScores";
            this.labelHighScores.Size = new System.Drawing.Size(60, 13);
            this.labelHighScores.TabIndex = 0;
            this.labelHighScores.Text = "Highscores";
            // 
            // tabHome
            // 
            this.tabHome.Controls.Add(this.buttonSelectTheme);
            this.tabHome.Controls.Add(this.buttonHighScores);
            this.tabHome.Controls.Add(this.buttonStartGame);
            this.tabHome.Location = new System.Drawing.Point(4, 22);
            this.tabHome.Name = "tabHome";
            this.tabHome.Padding = new System.Windows.Forms.Padding(3);
            this.tabHome.Size = new System.Drawing.Size(653, 429);
            this.tabHome.TabIndex = 0;
            this.tabHome.Text = "Home";
            this.tabHome.UseVisualStyleBackColor = true;
            // 
            // buttonSelectTheme
            // 
            this.buttonSelectTheme.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonSelectTheme.Location = new System.Drawing.Point(3, 139);
            this.buttonSelectTheme.Name = "buttonSelectTheme";
            this.buttonSelectTheme.Size = new System.Drawing.Size(647, 68);
            this.buttonSelectTheme.TabIndex = 2;
            this.buttonSelectTheme.Text = "Select new theme";
            this.buttonSelectTheme.UseVisualStyleBackColor = true;
            this.buttonSelectTheme.Click += new System.EventHandler(this.ButtonSelectTheme_Click);
            // 
            // buttonHighScores
            // 
            this.buttonHighScores.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonHighScores.Location = new System.Drawing.Point(3, 71);
            this.buttonHighScores.Name = "buttonHighScores";
            this.buttonHighScores.Size = new System.Drawing.Size(647, 68);
            this.buttonHighScores.TabIndex = 1;
            this.buttonHighScores.Text = "Highscores";
            this.buttonHighScores.UseVisualStyleBackColor = true;
            this.buttonHighScores.Click += new System.EventHandler(this.ButtonHighScores_Click);
            // 
            // buttonStartGame
            // 
            this.buttonStartGame.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonStartGame.Location = new System.Drawing.Point(3, 3);
            this.buttonStartGame.Name = "buttonStartGame";
            this.buttonStartGame.Size = new System.Drawing.Size(647, 68);
            this.buttonStartGame.TabIndex = 0;
            this.buttonStartGame.Text = "Start game";
            this.buttonStartGame.UseVisualStyleBackColor = true;
            this.buttonStartGame.Click += new System.EventHandler(this.ButtonStartGame_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabHome);
            this.tabControl1.Controls.Add(this.tabHighScores);
            this.tabControl1.Controls.Add(this.tabThemeSelection);
            this.tabControl1.Controls.Add(this.tabPreGame);
            this.tabControl1.Controls.Add(this.tabMemory);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(661, 455);
            this.tabControl1.TabIndex = 0;
            // 
            // tabThemeSelection
            // 
            this.tabThemeSelection.Controls.Add(this.buttonThemeSelectionHome);
            this.tabThemeSelection.Controls.Add(this.labelThemeSelect);
            this.tabThemeSelection.Location = new System.Drawing.Point(4, 22);
            this.tabThemeSelection.Name = "tabThemeSelection";
            this.tabThemeSelection.Padding = new System.Windows.Forms.Padding(3);
            this.tabThemeSelection.Size = new System.Drawing.Size(653, 429);
            this.tabThemeSelection.TabIndex = 2;
            this.tabThemeSelection.Text = "ThemeSelection";
            this.tabThemeSelection.UseVisualStyleBackColor = true;
            // 
            // buttonThemeSelectionHome
            // 
            this.buttonThemeSelectionHome.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonThemeSelectionHome.Location = new System.Drawing.Point(3, 376);
            this.buttonThemeSelectionHome.Name = "buttonThemeSelectionHome";
            this.buttonThemeSelectionHome.Size = new System.Drawing.Size(647, 50);
            this.buttonThemeSelectionHome.TabIndex = 3;
            this.buttonThemeSelectionHome.Text = "Home";
            this.buttonThemeSelectionHome.UseVisualStyleBackColor = true;
            this.buttonThemeSelectionHome.Click += new System.EventHandler(this.ButtonThemeSelectionHome_Click);
            // 
            // labelThemeSelect
            // 
            this.labelThemeSelect.AutoSize = true;
            this.labelThemeSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelThemeSelect.Location = new System.Drawing.Point(3, 3);
            this.labelThemeSelect.Name = "labelThemeSelect";
            this.labelThemeSelect.Size = new System.Drawing.Size(85, 13);
            this.labelThemeSelect.TabIndex = 0;
            this.labelThemeSelect.Text = "Theme selection";
            // 
            // tabPreGame
            // 
            this.tabPreGame.Controls.Add(this.LoadSavedGameCheckBox);
            this.tabPreGame.Controls.Add(this.GameSizeComboBox);
            this.tabPreGame.Controls.Add(this.buttonStartMemoryGame);
            this.tabPreGame.Controls.Add(this.buttonPreGameHome);
            this.tabPreGame.Controls.Add(this.textBox2);
            this.tabPreGame.Controls.Add(this.textBox1);
            this.tabPreGame.Controls.Add(this.label2);
            this.tabPreGame.Controls.Add(this.label1);
            this.tabPreGame.Location = new System.Drawing.Point(4, 22);
            this.tabPreGame.Name = "tabPreGame";
            this.tabPreGame.Size = new System.Drawing.Size(653, 429);
            this.tabPreGame.TabIndex = 4;
            this.tabPreGame.Text = "tabPreGame";
            this.tabPreGame.UseVisualStyleBackColor = true;
            // 
            // LoadSavedGameCheckBox
            // 
            this.LoadSavedGameCheckBox.AutoSize = true;
            this.LoadSavedGameCheckBox.Location = new System.Drawing.Point(11, 126);
            this.LoadSavedGameCheckBox.Name = "LoadSavedGameCheckBox";
            this.LoadSavedGameCheckBox.Size = new System.Drawing.Size(111, 17);
            this.LoadSavedGameCheckBox.TabIndex = 7;
            this.LoadSavedGameCheckBox.Text = "Load saved game";
            this.LoadSavedGameCheckBox.UseVisualStyleBackColor = true;
            this.LoadSavedGameCheckBox.CheckedChanged += new System.EventHandler(this.LoadSavedGameCheckBox_CheckedChanged);
            // 
            // GameSizeComboBox
            // 
            this.GameSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GameSizeComboBox.FormattingEnabled = true;
            this.GameSizeComboBox.Location = new System.Drawing.Point(11, 99);
            this.GameSizeComboBox.Name = "GameSizeComboBox";
            this.GameSizeComboBox.Size = new System.Drawing.Size(199, 21);
            this.GameSizeComboBox.TabIndex = 6;
            // 
            // buttonStartMemoryGame
            // 
            this.buttonStartMemoryGame.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonStartMemoryGame.Location = new System.Drawing.Point(0, 329);
            this.buttonStartMemoryGame.Name = "buttonStartMemoryGame";
            this.buttonStartMemoryGame.Size = new System.Drawing.Size(653, 50);
            this.buttonStartMemoryGame.TabIndex = 5;
            this.buttonStartMemoryGame.Text = "Start game";
            this.buttonStartMemoryGame.UseVisualStyleBackColor = true;
            this.buttonStartMemoryGame.Click += new System.EventHandler(this.ButtonStartMemoryGame_Click);
            // 
            // buttonPreGameHome
            // 
            this.buttonPreGameHome.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPreGameHome.Location = new System.Drawing.Point(0, 379);
            this.buttonPreGameHome.Name = "buttonPreGameHome";
            this.buttonPreGameHome.Size = new System.Drawing.Size(653, 50);
            this.buttonPreGameHome.TabIndex = 4;
            this.buttonPreGameHome.Text = "Home";
            this.buttonPreGameHome.UseVisualStyleBackColor = true;
            this.buttonPreGameHome.Click += new System.EventHandler(this.ButtonPreGameHome_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(11, 73);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(199, 20);
            this.textBox2.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(11, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(199, 20);
            this.textBox1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Player 2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Player 1";
            // 
            // tabMemory
            // 
            this.tabMemory.Controls.Add(this.tableLayoutPanel1);
            this.tabMemory.Controls.Add(this.panel2);
            this.tabMemory.Controls.Add(this.panel1);
            this.tabMemory.Location = new System.Drawing.Point(4, 22);
            this.tabMemory.Name = "tabMemory";
            this.tabMemory.Size = new System.Drawing.Size(653, 429);
            this.tabMemory.TabIndex = 3;
            this.tabMemory.Text = "Memory";
            this.tabMemory.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 14);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(653, 387);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.PauseResumeBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 401);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(653, 28);
            this.panel2.TabIndex = 4;
            // 
            // PauseResumeBtn
            // 
            this.PauseResumeBtn.Location = new System.Drawing.Point(3, 3);
            this.PauseResumeBtn.Name = "PauseResumeBtn";
            this.PauseResumeBtn.Size = new System.Drawing.Size(75, 23);
            this.PauseResumeBtn.TabIndex = 0;
            this.PauseResumeBtn.Text = "Pause";
            this.PauseResumeBtn.UseVisualStyleBackColor = true;
            this.PauseResumeBtn.Click += new System.EventHandler(this.PauseResumeBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.PlayerOneScoreLabel);
            this.panel1.Controls.Add(this.CurrentPlayerPlayingLabel);
            this.panel1.Controls.Add(this.PlayerTwoScoreLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(653, 14);
            this.panel1.TabIndex = 3;
            // 
            // PlayerOneScoreLabel
            // 
            this.PlayerOneScoreLabel.AutoSize = true;
            this.PlayerOneScoreLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.PlayerOneScoreLabel.Location = new System.Drawing.Point(0, 0);
            this.PlayerOneScoreLabel.Name = "PlayerOneScoreLabel";
            this.PlayerOneScoreLabel.Size = new System.Drawing.Size(113, 13);
            this.PlayerOneScoreLabel.TabIndex = 0;
            this.PlayerOneScoreLabel.Text = "[PLAYER 1]: [SCORE]";
            // 
            // CurrentPlayerPlayingLabel
            // 
            this.CurrentPlayerPlayingLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CurrentPlayerPlayingLabel.AutoSize = true;
            this.CurrentPlayerPlayingLabel.Location = new System.Drawing.Point(312, 0);
            this.CurrentPlayerPlayingLabel.Name = "CurrentPlayerPlayingLabel";
            this.CurrentPlayerPlayingLabel.Size = new System.Drawing.Size(35, 13);
            this.CurrentPlayerPlayingLabel.TabIndex = 2;
            this.CurrentPlayerPlayingLabel.Text = "label5";
            // 
            // PlayerTwoScoreLabel
            // 
            this.PlayerTwoScoreLabel.AutoSize = true;
            this.PlayerTwoScoreLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.PlayerTwoScoreLabel.Location = new System.Drawing.Point(540, 0);
            this.PlayerTwoScoreLabel.Name = "PlayerTwoScoreLabel";
            this.PlayerTwoScoreLabel.Size = new System.Drawing.Size(113, 13);
            this.PlayerTwoScoreLabel.TabIndex = 1;
            this.PlayerTwoScoreLabel.Text = "[PLAYER 2]: [SCORE]";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 455);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabHighScores.ResumeLayout(false);
            this.tabHighScores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HighScoresGridView)).EndInit();
            this.tabHome.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabThemeSelection.ResumeLayout(false);
            this.tabThemeSelection.PerformLayout();
            this.tabPreGame.ResumeLayout(false);
            this.tabPreGame.PerformLayout();
            this.tabMemory.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabPage tabHighScores;
        private System.Windows.Forms.TabPage tabHome;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabThemeSelection;
        private System.Windows.Forms.Label labelHighScores;
        private System.Windows.Forms.Button buttonSelectTheme;
        private System.Windows.Forms.Button buttonHighScores;
        private System.Windows.Forms.Button buttonStartGame;
        private System.Windows.Forms.DataGridView HighScoresGridView;
        private System.Windows.Forms.Label labelThemeSelect;
        private System.Windows.Forms.TabPage tabMemory;
        private System.Windows.Forms.TabPage tabPreGame;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonHighScoresHome;
        private System.Windows.Forms.Button buttonThemeSelectionHome;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonStartMemoryGame;
        private System.Windows.Forms.Button buttonPreGameHome;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label PlayerTwoScoreLabel;
        private System.Windows.Forms.Label PlayerOneScoreLabel;
        private System.Windows.Forms.Label CurrentPlayerPlayingLabel;
        private System.Windows.Forms.ComboBox GameSizeComboBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button PauseResumeBtn;
        private System.Windows.Forms.CheckBox LoadSavedGameCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Player;
        private System.Windows.Forms.DataGridViewTextBoxColumn Score;
    }
}

