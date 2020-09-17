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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tabHome = new System.Windows.Forms.TabPage();
            this.buttonSelectTheme = new System.Windows.Forms.Button();
            this.buttonHighScores = new System.Windows.Forms.Button();
            this.buttonStartGame = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabThemeSelection = new System.Windows.Forms.TabPage();
            this.Player = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabHighScores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabHome.SuspendLayout();
            this.tabControl1.SuspendLayout();
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
            this.tabHighScores.Controls.Add(this.dataGridView1);
            this.tabHighScores.Controls.Add(this.label1);
            this.tabHighScores.Location = new System.Drawing.Point(4, 22);
            this.tabHighScores.Name = "tabHighScores";
            this.tabHighScores.Padding = new System.Windows.Forms.Padding(3);
            this.tabHighScores.Size = new System.Drawing.Size(653, 429);
            this.tabHighScores.TabIndex = 1;
            this.tabHighScores.Text = "HighScore";
            this.tabHighScores.UseVisualStyleBackColor = true;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Highscores";
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
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabHome);
            this.tabControl1.Controls.Add(this.tabHighScores);
            this.tabControl1.Controls.Add(this.tabThemeSelection);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(661, 455);
            this.tabControl1.TabIndex = 0;
            // 
            // tabThemeSelection
            // 
            this.tabThemeSelection.Location = new System.Drawing.Point(4, 22);
            this.tabThemeSelection.Name = "tabThemeSelection";
            this.tabThemeSelection.Padding = new System.Windows.Forms.Padding(3);
            this.tabThemeSelection.Size = new System.Drawing.Size(653, 429);
            this.tabThemeSelection.TabIndex = 2;
            this.tabThemeSelection.Text = "ThemeSelection";
            this.tabThemeSelection.UseVisualStyleBackColor = true;
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabPage tabHighScores;
        private System.Windows.Forms.TabPage tabHome;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabThemeSelection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSelectTheme;
        private System.Windows.Forms.Button buttonHighScores;
        private System.Windows.Forms.Button buttonStartGame;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Player;
        private System.Windows.Forms.DataGridViewTextBoxColumn Score;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
    }
}

