using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MineSweeper.Model;

namespace MineSweeper
{
    public partial class MineSweeperView : Form
    {
        #region Fields

        private MineSweeperModel _model;
        private Button[,] _buttonGrid;
        private Panel gamePanel;

        #endregion

        #region Constructor

        public MineSweeperView() {
            InitializeComponent();
            _model = new MineSweeperModel();
            _model.UpdateUI += _model_UpdateUI;
            _model.SwitchPlayer += _model_SwitchPlayer;
            _model.GameOver += _model_GameOver;
            _model.Tie += _model_Tie;
            _model.UpdateAfterSave += _model_UpdateAfterSave;
            gamePanel = new Panel();
            Controls.Add(gamePanel);
            NewGame(10);
        }

        #endregion

        #region Grid event handlers
        private void ButtonGrid_MouseClick(Object sender, MouseEventArgs e) {
            Point p = (Point)((sender as Button).Tag);
            int x = p.X;
            int y = p.Y;
            _model.StepOn(x, y);
        }

        #endregion

        #region Private methods

        private void GenerateTable() {
            _buttonGrid = new Button[_model.GameSize, _model.GameSize];
            gamePanel.Controls.Clear();
            for (Int32 i = 0; i < _model.GameSize; i++) {
                for (Int32 j = 0; j < _model.GameSize; j++) {
                    _buttonGrid[i, j] = new Button();
                    _buttonGrid[i, j].Location = new Point(5 + 50 * j, 35 + 50 * i);
                    _buttonGrid[i, j].Size = new Size(50, 50);
                    _buttonGrid[i, j].Font = new Font(FontFamily.GenericSansSerif, 25, FontStyle.Bold);
                    _buttonGrid[i, j].Tag = new Point(i, j);
                    _buttonGrid[i, j].MouseClick += new MouseEventHandler(ButtonGrid_MouseClick);
                    gamePanel.Controls.Add(_buttonGrid[i, j]);
                }
            }
            Size = new Size(_model.GameSize * 50+25, _model.GameSize * 50 + 100);
            gamePanel.Size = Size;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
        }
        private void NewGame(int newSize) {
            _model.NewGame(newSize);
            GenerateTable();
            msStatusCurrPlayer.Text = "Player 1";
        }

        #endregion

        #region Event handlers
        private void _model_UpdateAfterSave() {
            GenerateTable();
            _model_UpdateUI();
        }

        private void _model_GameOver() {
            if (msStatusCurrPlayer.Text == "Player 1") {
                if (MessageBox.Show("Player 2 won! Sadly, Player 1 won't be going home for dinner tonight...\nPress OK to play again!", "Victory?", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK) {
                    NewGame(_model.GameSize);
                }
            } else {
                if(MessageBox.Show("Player 1 won! They should help organize Player 2's funeral...\nPress OK to play again!", "Victory?", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK) {
                    NewGame(_model.GameSize);
                }
            }
        }
        private void _model_Tie() {
            if (MessageBox.Show("It's a tie! Congrats, neither of you has blown up!\nPress OK to play again!", "Victory!", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK) {
                NewGame(_model.GameSize);
            }
        }

        private void _model_SwitchPlayer() {
            if (msStatusCurrPlayer.Text == "Player 1") {
                msStatusCurrPlayer.Text = "Player 2";
            } else {
                msStatusCurrPlayer.Text = "Player 1";
            }
        }
        private void _model_UpdateUI() {
            for (int i = 0; i < _model.GameSize; i++) {
                for (int j = 0; j < _model.GameSize; j++) {
                    if (_model.RevealedFields[i, j]) {

                        _buttonGrid[i, j].BackColor = Color.LightGray;
                        if (_model.GameTable[i, j] == 0) {
                            _buttonGrid[i, j].Text = "";

                        } else if (_model.GameTable[i, j] == -1) {
                            _buttonGrid[i, j].Text = "💣";
                        } else {
                            _buttonGrid[i, j].Text = _model.GameTable[i, j].ToString();
                        }
                        _buttonGrid[i, j].Enabled = false;
                    }
                }
            }
        }
        private void NewGameSmallClicked(Object sender, EventArgs e) {
            NewGame(6);
        }
        private void NewGameMediumClicked(Object sender, EventArgs e) {
            NewGame(10);
        }
        private void NewGameLargeClicked(Object sender, EventArgs e) {
            NewGame(16);
        }
        private void LoadGame(Object sender, EventArgs e) {
            if(openFileDialog1.ShowDialog() == DialogResult.OK) {
                try {
                    _model.LoadGame(openFileDialog1.FileName);
                } catch {
                    MessageBox.Show("Load unsuccessful.\nIncorrect path, or you do not have permissions to write to this folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                msStatusCurrPlayer.Text = "Player " + (_model.CurrentPlayer.ToString() == "p1" ? "1" : "2");
            }

        }
        private void SaveGame(Object sender, EventArgs e) {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                try {
                    _model.SaveGame(saveFileDialog1.FileName);
                } catch {
                    MessageBox.Show("Save unsuccessful.\nIncorrect path, or you do not have permissions to write to this folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void QuitGame(Object sender, EventArgs e) {
            Close();
        }
        #endregion
    }
}
