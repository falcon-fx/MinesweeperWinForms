using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace MineSweeper.Persistence {
    class MineSweeperDataAccess {
        public Tuple<int, int, int[,], bool[,]> Load(string path) {
            List<string> lines = File.ReadAllLines(path).ToList<string>();
            int gameSize = int.Parse(lines[0]);
            int currPlayer = int.Parse(lines[1]);
            lines.RemoveAt(0);
            lines.RemoveAt(0);
            int[,] gameTable = new int[gameSize, gameSize];
            for(int i = 0; i < gameSize; i++) {
                List<string> line = lines[i].Split(' ').ToList<string>();
                for (int j = 0; j < gameSize; j++) {
                    int number = int.Parse(line[j]);
                    gameTable[i, j] = number;
                }
            }
            for(int i = 0; i < gameSize; i++) {
                lines.RemoveAt(0);
            }
            bool[,] revealed = new bool[gameSize, gameSize];
            for(int i = 0; i < gameSize; i++) {
                List<string> line = lines[i].Split(' ').ToList<string>();
                for (int j = 0; j < gameSize; j++) {
                    bool isRev = line[j] == "0" ? false : true;
                    revealed[i, j] = isRev;
                }
            }
            return new Tuple<int, int, int[,], bool[,]>(gameSize, currPlayer, gameTable, revealed);
        }
        public void Save(int size,int currPlayer, int[,] table, bool[,] revealed, string fname) {
            StreamWriter streamWriter = new StreamWriter(fname);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(size.ToString());
            stringBuilder.Append("\n");
            stringBuilder.Append(currPlayer.ToString());
            stringBuilder.Append("\n");

            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                    stringBuilder.Append(table[i,j].ToString());
                    if (j < size - 1) {
                        stringBuilder.Append(" ");
                    }
                }
                stringBuilder.Append("\n");
            }

            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                    int rev = revealed[i, j] == true ? 1 : 0;
                    stringBuilder.Append(rev.ToString());
                    if (j < size - 1) {
                        stringBuilder.Append(" ");
                    }
                }
                stringBuilder.Append("\n");
            }
            streamWriter.Write(stringBuilder.ToString());
            streamWriter.Close();
        }
    }
}
