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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Player = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabMemory = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonPreGameHome = new System.Windows.Forms.Button();
            this.buttonStartMemoryGame = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabHighScores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabHome.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabThemeSelection.SuspendLayout();
            this.tabPreGame.SuspendLayout();
            this.tabMemory.SuspendLayout();
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
            this.tabHighScores.Controls.Add(this.dataGridView1);
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
            this.buttonHighScoresHome.Click += new System.EventHandler(this.buttonHighScoresHome_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Player,
            this.Score,
            this.Time});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(647, 410);
            this.dataGridView1.TabIndex = 1;
            // 
            // Player
            // 
            this.Player.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Player.HeaderText = "Player";
            this.Player.Name = "Player";
            // 
            // Score
            // 
            this.Score.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Score.HeaderText = "Score";
            this.Score.Name = "Score";
            // 
            // Time
            // 
            this.Time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Time.HeaderText = "Time";
            this.Time.Name = "Time";
            this.Time.Resizable = System.Windows.Forms.DataGridViewTriState.False;
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
            this.buttonSelectTheme.Click += new System.EventHandler(this.buttonSelectTheme_Click);
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
            this.buttonStartGame.Click += new System.EventHandler(this.buttonStartGame_Click);
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
            this.buttonThemeSelectionHome.Click += new System.EventHandler(this.buttonThemeSelectionHome_Click);
            // 
            // labelThemeSelect
            // 
            this.labelThemeSelect.AutoSize = true;
            this.labelThemeSelect.Location = new System.Drawing.Point(8, 8);
            this.labelThemeSelect.Name = "labelThemeSelect";
            this.labelThemeSelect.Size = new System.Drawing.Size(85, 13);
            this.labelThemeSelect.TabIndex = 0;
            this.labelThemeSelect.Text = "Theme selection";
            // 
            // tabPreGame
            // 
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
            this.tabMemory.Controls.Add(this.label4);
            this.tabMemory.Controls.Add(this.label3);
            this.tabMemory.Controls.Add(this.tableLayoutPanel1);
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
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(653, 413);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(11, 73);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(199, 20);
            this.textBox2.TabIndex = 3;
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
            this.buttonPreGameHome.Click += new System.EventHandler(this.buttonPreGameHome_Click);
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
            this.buttonStartMemoryGame.Click += new System.EventHandler(this.buttonStartMemoryGame_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "[PLAYER 1]: [SCORE]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Right;
            this.label4.Location = new System.Drawing.Point(540, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "[PLAYER 2]: [SCORE]";
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabHome.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabThemeSelection.ResumeLayout(false);
            this.tabThemeSelection.PerformLayout();
            this.tabPreGame.ResumeLayout(false);
            this.tabPreGame.PerformLayout();
            this.tabMemory.ResumeLayout(false);
            this.tabMemory.PerformLayout();
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
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Player;
        private System.Windows.Forms.DataGridViewTextBoxColumn Score;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}

