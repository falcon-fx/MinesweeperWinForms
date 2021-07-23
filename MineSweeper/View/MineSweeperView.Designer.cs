
namespace MineSweeper
{
    partial class MineSweeperView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.msMenuStrip = new System.Windows.Forms.MenuStrip();
            this.msMenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.msMenuFileNewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.msMenuFileNewGameSmall = new System.Windows.Forms.ToolStripMenuItem();
            this.msMenuFileNewGameMedium = new System.Windows.Forms.ToolStripMenuItem();
            this.msMenuFileNewGameLarge = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.msMenuFileLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.msMenuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.msMenuFileQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.msStatusCurrLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.msStatusCurrPlayer = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.msMenuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMenuStrip
            // 
            this.msMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msMenuFile});
            this.msMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.msMenuStrip.Name = "msMenuStrip";
            this.msMenuStrip.Size = new System.Drawing.Size(800, 24);
            this.msMenuStrip.TabIndex = 0;
            this.msMenuStrip.Text = "menuStrip1";
            // 
            // msMenuFile
            // 
            this.msMenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msMenuFileNewGame,
            this.toolStripSeparator1,
            this.msMenuFileLoad,
            this.msMenuFileSave,
            this.toolStripSeparator2,
            this.msMenuFileQuit});
            this.msMenuFile.Name = "msMenuFile";
            this.msMenuFile.Size = new System.Drawing.Size(37, 20);
            this.msMenuFile.Text = "File";
            // 
            // msMenuFileNewGame
            // 
            this.msMenuFileNewGame.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msMenuFileNewGameSmall,
            this.msMenuFileNewGameMedium,
            this.msMenuFileNewGameLarge});
            this.msMenuFileNewGame.Name = "msMenuFileNewGame";
            this.msMenuFileNewGame.Size = new System.Drawing.Size(134, 22);
            this.msMenuFileNewGame.Text = "New Game";
            // 
            // msMenuFileNewGameSmall
            // 
            this.msMenuFileNewGameSmall.Name = "msMenuFileNewGameSmall";
            this.msMenuFileNewGameSmall.Size = new System.Drawing.Size(160, 22);
            this.msMenuFileNewGameSmall.Text = "Small (6x6)";
            this.msMenuFileNewGameSmall.Click += new System.EventHandler(this.NewGameSmallClicked);
            // 
            // msMenuFileNewGameMedium
            // 
            this.msMenuFileNewGameMedium.Name = "msMenuFileNewGameMedium";
            this.msMenuFileNewGameMedium.Size = new System.Drawing.Size(160, 22);
            this.msMenuFileNewGameMedium.Text = "Medium (10x10)";
            this.msMenuFileNewGameMedium.Click += new System.EventHandler(this.NewGameMediumClicked);
            // 
            // msMenuFileNewGameLarge
            // 
            this.msMenuFileNewGameLarge.Name = "msMenuFileNewGameLarge";
            this.msMenuFileNewGameLarge.Size = new System.Drawing.Size(160, 22);
            this.msMenuFileNewGameLarge.Text = "Large (16x16)";
            this.msMenuFileNewGameLarge.Click += new System.EventHandler(this.NewGameLargeClicked);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(131, 6);
            // 
            // msMenuFileLoad
            // 
            this.msMenuFileLoad.Name = "msMenuFileLoad";
            this.msMenuFileLoad.Size = new System.Drawing.Size(134, 22);
            this.msMenuFileLoad.Text = "Load Game";
            this.msMenuFileLoad.Click += new System.EventHandler(this.LoadGame);
            // 
            // msMenuFileSave
            // 
            this.msMenuFileSave.Name = "msMenuFileSave";
            this.msMenuFileSave.Size = new System.Drawing.Size(134, 22);
            this.msMenuFileSave.Text = "Save Game";
            this.msMenuFileSave.Click += new System.EventHandler(this.SaveGame);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(131, 6);
            // 
            // msMenuFileQuit
            // 
            this.msMenuFileQuit.Name = "msMenuFileQuit";
            this.msMenuFileQuit.Size = new System.Drawing.Size(134, 22);
            this.msMenuFileQuit.Text = "Quit";
            this.msMenuFileQuit.Click += new System.EventHandler(this.QuitGame);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msStatusCurrLabel,
            this.msStatusCurrPlayer});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // msStatusCurrLabel
            // 
            this.msStatusCurrLabel.Name = "msStatusCurrLabel";
            this.msStatusCurrLabel.Size = new System.Drawing.Size(85, 17);
            this.msStatusCurrLabel.Text = "Current player:";
            // 
            // msStatusCurrPlayer
            // 
            this.msStatusCurrPlayer.Name = "msStatusCurrPlayer";
            this.msStatusCurrPlayer.Size = new System.Drawing.Size(48, 17);
            this.msStatusCurrPlayer.Text = "Player 1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Minesweeper Game Save (*.mgs)|*.mgs";
            this.openFileDialog1.Title = "Load saved game";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Minesweeper Game Save (*.mgs)|*.mgs";
            this.saveFileDialog1.Title = "Save current game";
            // 
            // MineSweeperView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.msMenuStrip);
            this.MainMenuStrip = this.msMenuStrip;
            this.Name = "MineSweeperView";
            this.Text = "Minesweeper";
            this.msMenuStrip.ResumeLayout(false);
            this.msMenuStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem msMenuFile;
        private System.Windows.Forms.ToolStripMenuItem msMenuFileNewGame;
        private System.Windows.Forms.ToolStripMenuItem msMenuFileNewGameSmall;
        private System.Windows.Forms.ToolStripMenuItem msMenuFileNewGameMedium;
        private System.Windows.Forms.ToolStripMenuItem msMenuFileNewGameLarge;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem msMenuFileLoad;
        private System.Windows.Forms.ToolStripMenuItem msMenuFileSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem msMenuFileQuit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel msStatusCurrLabel;
        private System.Windows.Forms.ToolStripStatusLabel msStatusCurrPlayer;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

