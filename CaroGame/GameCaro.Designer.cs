namespace CaroGame
{
    partial class GameCaro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameCaro));
            this.BoardPanel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerXPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerXComToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StringPanel = new System.Windows.Forms.Panel();
            this.StringLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.StringTimer = new System.Windows.Forms.Timer(this.components);
            this.ExitButton = new System.Windows.Forms.Button();
            this.PlayerXPlayerButton = new System.Windows.Forms.Button();
            this.PlayerXComButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.StringPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BoardPanel
            // 
            this.BoardPanel.BackColor = System.Drawing.Color.LimeGreen;
            this.BoardPanel.Location = new System.Drawing.Point(238, 34);
            this.BoardPanel.Name = "BoardPanel";
            this.BoardPanel.Size = new System.Drawing.Size(670, 617);
            this.BoardPanel.TabIndex = 12;
            this.BoardPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.BoardPanel_Paint);
            this.BoardPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BoardPanel_MouseClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Khaki;
            this.menuStrip1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.optionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(919, 28);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playerXPlayerToolStripMenuItem,
            this.playerXComToolStripMenuItem});
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.newGameToolStripMenuItem.Text = "New Game";
            // 
            // playerXPlayerToolStripMenuItem
            // 
            this.playerXPlayerToolStripMenuItem.Name = "playerXPlayerToolStripMenuItem";
            this.playerXPlayerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.playerXPlayerToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
            this.playerXPlayerToolStripMenuItem.Text = "Player X Player";
            this.playerXPlayerToolStripMenuItem.Click += new System.EventHandler(this.playerXPlayerToolStripMenuItem_Click);
            // 
            // playerXComToolStripMenuItem
            // 
            this.playerXComToolStripMenuItem.Name = "playerXComToolStripMenuItem";
            this.playerXComToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F2)));
            this.playerXComToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
            this.playerXComToolStripMenuItem.Text = "Player X Com";
            this.playerXComToolStripMenuItem.Click += new System.EventHandler(this.playerXComToolStripMenuItem_Click);
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            this.optionToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
            this.optionToolStripMenuItem.Text = "Option";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // StringPanel
            // 
            this.StringPanel.BackColor = System.Drawing.Color.Silver;
            this.StringPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.StringPanel.Controls.Add(this.StringLabel);
            this.StringPanel.Location = new System.Drawing.Point(10, 260);
            this.StringPanel.Name = "StringPanel";
            this.StringPanel.Size = new System.Drawing.Size(222, 202);
            this.StringPanel.TabIndex = 11;
            // 
            // StringLabel
            // 
            this.StringLabel.AutoSize = true;
            this.StringLabel.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StringLabel.Location = new System.Drawing.Point(0, 0);
            this.StringLabel.Name = "StringLabel";
            this.StringLabel.Size = new System.Drawing.Size(31, 16);
            this.StringLabel.TabIndex = 0;
            this.StringLabel.Text = "abc";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(10, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(222, 220);
            this.panel1.TabIndex = 10;
            // 
            // StringTimer
            // 
            this.StringTimer.Interval = 25;
            this.StringTimer.Tick += new System.EventHandler(this.StringTimer_Tick);
            // 
            // ExitButton
            // 
            this.ExitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ExitButton.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.Location = new System.Drawing.Point(10, 599);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(222, 52);
            this.ExitButton.TabIndex = 16;
            this.ExitButton.TabStop = false;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // PlayerXPlayerButton
            // 
            this.PlayerXPlayerButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PlayerXPlayerButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.PlayerXPlayerButton.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerXPlayerButton.Location = new System.Drawing.Point(10, 468);
            this.PlayerXPlayerButton.Name = "PlayerXPlayerButton";
            this.PlayerXPlayerButton.Size = new System.Drawing.Size(222, 63);
            this.PlayerXPlayerButton.TabIndex = 14;
            this.PlayerXPlayerButton.TabStop = false;
            this.PlayerXPlayerButton.Text = "Player X Player";
            this.PlayerXPlayerButton.UseVisualStyleBackColor = true;
            this.PlayerXPlayerButton.Click += new System.EventHandler(this.PlayerXPlayerButton_Click);
            // 
            // PlayerXComButton
            // 
            this.PlayerXComButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PlayerXComButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.PlayerXComButton.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerXComButton.Location = new System.Drawing.Point(11, 537);
            this.PlayerXComButton.Name = "PlayerXComButton";
            this.PlayerXComButton.Size = new System.Drawing.Size(219, 56);
            this.PlayerXComButton.TabIndex = 13;
            this.PlayerXComButton.TabStop = false;
            this.PlayerXComButton.Text = "Player X Com";
            this.PlayerXComButton.UseVisualStyleBackColor = true;
            this.PlayerXComButton.Click += new System.EventHandler(this.PlayerXComButton_Click);
            // 
            // GameCaro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(919, 660);
            this.Controls.Add(this.BoardPanel);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.StringPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.PlayerXPlayerButton);
            this.Controls.Add(this.PlayerXComButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "GameCaro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Caro";
            this.Load += new System.EventHandler(this.GameCaro_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.StringPanel.ResumeLayout(false);
            this.StringPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel BoardPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playerXPlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playerXComToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.Panel StringPanel;
        private System.Windows.Forms.Label StringLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer StringTimer;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button PlayerXPlayerButton;
        private System.Windows.Forms.Button PlayerXComButton;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
    }
}

