using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using MineSweeper.Persistence;

namespace MineSweeper.Model
{
    enum Player
    {
        p1 = 1, p2 = 2
    };
    class MineSweeperModel
    {
        #region Fields

        private int[,] _gameTable;
        private bool[,] _revealedFields;
        private int _gameSize;
        private Player _currentPlayer;
        private MineSweeperDataAccess _dataAccess;

        #endregion

        #region Properties

        public int[,] GameTable { get { return _gameTable; } }
        public bool[,] RevealedFields { get { return _revealedFields; } }
        public int GameSize { get { return _gameSize; } }
        public Player CurrentPlayer { get { return _currentPlayer; } }

        #endregion

        #region Constructors
        public MineSweeperModel() {
            _dataAccess = new MineSweeperDataAccess();
        }

        #endregion

        #region Public methods
        public void SetGameTable(int[,] gt) {
            if(gt.Length == _gameSize*_gameSize) {
                _gameTable = gt;
            }
        }
        public void NewGame(int size) {
            _currentPlayer = Player.p1;
            int mineCount = 0;
            _gameSize = size;
            var rand = new Random();
            _gameTable = new int[_gameSize, _gameSize];
            _revealedFields = new bool[_gameSize, _gameSize];
            for (int i = 0; i < _gameSize; i++) {
                for (int j = 0; j < _gameSize; j++) {
                    _revealedFields[i, j] = false;
                    _gameTable[i, j] = 0;
                }
            }
            while (mineCount < _gameSize) {
                int random1 = (int)(rand.NextDouble() * _gameSize);
                int random2 = (int)(rand.NextDouble() * _gameSize);
                if (_gameTable[random1, random2] == -1) {
                    continue;
                } else {
                    _gameTable[random1, random2] = -1;
                    mineCount++;
                }
            }
            for (int i = 0; i < _gameSize; i++) {
                for (int j = 0; j < _gameSize; j++) {
                    if (_gameTable[i, j] != -1) {
                        if(i == 0 && j == 0) { //bal felső
                            int mCount = FindMines(new List<int>{
                                _gameTable[i, j + 1]
                                , _gameTable[i + 1, j],
                                _gameTable[i + 1, j + 1]
                            });
                            _gameTable[i,j] = mCount;
                        } else if (i == _gameSize - 1 && j == 0) { //bal alsó
                            int mCount = FindMines(new List<int> { 
                                _gameTable[i, j + 1],
                                _gameTable[i - 1, j],
                                _gameTable[i - 1, j+ 1]
                            });
                            _gameTable[i, j] = mCount;
                        } else if (i == 0 && j == _gameSize - 1) { //jobb felső
                            int mCount = FindMines(new List<int> { 
                                _gameTable[i, j - 1],
                                _gameTable[i + 1, j], 
                                _gameTable[i + 1, j - 1]
                            });
                            _gameTable[i, j] = mCount;
                        } else if (i == _gameSize - 1 && j == _gameSize - 1) { //jobb alsó
                            int mCount = FindMines(new List<int> {
                                _gameTable[i, j - 1], 
                                _gameTable[i - 1, j], 
                                _gameTable[i - 1, j - 1] 
                            });
                            _gameTable[i, j] = mCount;
                        } else if (i == 0) { //felső sor
                            int mCount = FindMines(new List<int> { 
                                _gameTable[i, j + 1],
                                _gameTable[i + 1, j],
                                _gameTable[i + 1, j + 1],
                                _gameTable[i+1,j-1],
                                _gameTable[i,j-1] 
                            });
                            _gameTable[i, j] = mCount;
                        } else if(i == _gameSize-1) { //alsó sor
                            int mCount = FindMines(new List<int> {
                                _gameTable[i, j + 1],
                                _gameTable[i - 1, j],
                                _gameTable[i - 1, j + 1],
                                _gameTable[i - 1, j - 1],
                                _gameTable[i, j - 1] 
                            });
                            _gameTable[i, j] = mCount;
                        } else if(j == 0) { //bal sor
                            int mCount = FindMines(new List<int> { 
                                _gameTable[i, j + 1],
                                _gameTable[i - 1, j],
                                _gameTable[i + 1, j + 1],
                                _gameTable[i - 1, j + 1],
                                _gameTable[i+1, j] 
                            });
                            _gameTable[i, j] = mCount;
                        } else if(j == _gameSize-1) { //jobb sor
                            int mCount = FindMines(new List<int> {
                                _gameTable[i, j - 1],
                                _gameTable[i - 1, j],
                                _gameTable[i + 1, j - 1],
                                _gameTable[i - 1, j - 1],
                                _gameTable[i + 1, j] 
                            });
                            _gameTable[i, j] = mCount;
                        } else {
                            int mCount = FindMines(new List<int> { 
                                _gameTable[i-1, j - 1],
                                _gameTable[i - 1,j],
                                _gameTable[i - 1, j + 1],
                                _gameTable[i, j-1],
                                _gameTable[i, j + 1],
                                _gameTable[i+1, j - 1],
                                _gameTable[i+1, j],
                                _gameTable[i+1, j + 1] 
                            });
                            _gameTable[i, j] = mCount;
                        }
                    }
                }
            }
        }
        public void StepOn(int x, int y) {
            Reveal(x, y);
            //UpdateUI();
            bool allRevealed = false;
            int revealed = 0;
            for(int i = 0; i < _gameSize; i++) {
                for(int j = 0; j <_gameSize; j++) {
                    if(_gameTable[i,j] != -1 && _revealedFields[i,j] == true) {
                        revealed++;
                    }
                }
            }
            allRevealed = (revealed == (_gameSize * (_gameSize - 1)));
            if (_gameTable[x, y] == -1) {
                //GameOver();
            } else if (allRevealed) {
                //Tie();
            } else {
                _currentPlayer = _currentPlayer == Player.p1 ? Player.p2 : Player.p1;
                //SwitchPlayer();
            }
        }
        public void Reveal(int x, int y) {
            if(!_revealedFields[x,y]) {
                _revealedFields[x, y] = true;
                if(_gameTable[x,y] == 0) {
                    for (int i = Math.Max(x - 1, 0); i < _gameSize && i <= x + 1; i++) {
                        for (int j = Math.Max(y - 1, 0); j < _gameSize && j <= y + 1; j++) {
                            Reveal(i, j);
                        }
                    }
                }
            }
        }
        public void LoadGame(string path) {
            Tuple<int, int, int[,], bool[,]> data = _dataAccess.Load(path);
            NewGame(data.Item1);
            _currentPlayer = (Player)data.Item2;
            _gameTable = data.Item3;
            _revealedFields = data.Item4;
            UpdateAfterSave();
        }
        public void SaveGame(string path) {
            _dataAccess.Save(_gameSize, (int)_currentPlayer, _gameTable, _revealedFields, path);
        }
        #endregion

        #region Private methods

        private int FindMines(List<int> neighbors) {
            int counter = 0;
            foreach(int neighbor in neighbors) {
                if(neighbor == -1) {
                    counter++;
                }
            }
            return counter;
        }

        #endregion

        #region Actions

        public event Action GameOver;
        public event Action Tie;
        public event Action SwitchPlayer;
        public event Action UpdateUI;
        public event Action UpdateAfterSave;

        #endregion
    }
}
