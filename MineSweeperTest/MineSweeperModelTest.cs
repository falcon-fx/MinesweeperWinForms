using Microsoft.VisualStudio.TestTools.UnitTesting;
using MineSweeper.Model;

namespace MineSweeperTest {
    [TestClass]
    public class MineSweeperModelTest {
        private MineSweeperModel model;
        private int[,] table;

        public object It { get; private set; }

        [TestInitialize]
        public void Initialize() {
            model = new MineSweeperModel();
            table = new int[,] {
                { 1,1,1,0,0,0},
                {1,-1,1,1,1,1 },
                {1,1,1,1,-1,1 },
                {1,1,1,1,1,1 },
                {1,-1,1,0,0,0 },
                { 1,1,1,0,0,0}
            };
        }
        [TestMethod]
        public void MineSweeperModelNewGameSmallTest() {
            model.NewGame(6);
            int count = 0;
            int tmpi = 0;
            int tmpj = 0;
            for(int i = 0; i < model.GameSize; i++) {
                for(int j = 0; j < model.GameSize; j++) {
                    if(model.GameTable[i,j] == -1) {
                        tmpi = i;
                        tmpj = j;
                        count++;
                    }
                }
            }
            Assert.AreEqual(count, 6);
            if (tmpi < model.GameSize - 1 && tmpi > 0 && tmpj < model.GameSize-1 && tmpj > 0) {
                Assert.IsTrue(model.GameTable[tmpi + 1, tmpj + 1] >= 1);
                Assert.IsTrue(model.GameTable[tmpi, tmpj + 1] >= 1);
                Assert.IsTrue(model.GameTable[tmpi + 1, tmpj] >= 1);
                Assert.IsTrue(model.GameTable[tmpi - 1, tmpj - 1] >= 1);
                Assert.IsTrue(model.GameTable[tmpi + 1, tmpj - 1] >= 1);
                Assert.IsTrue(model.GameTable[tmpi - 1, tmpj + 1] >= 1);
                Assert.IsTrue(model.GameTable[tmpi - 1, tmpj] >= 1);
                Assert.IsTrue(model.GameTable[tmpi, tmpj - 1] >= 1);

            }
        }
        [TestMethod]
        public void MineSweeperModelNewGameMediumTest() {
            model.NewGame(10);
            int count = 0;
            int tmpi = 0;
            int tmpj = 0;
            for (int i = 0; i < model.GameSize; i++) {
                for (int j = 0; j < model.GameSize; j++) {
                    if (model.GameTable[i, j] == -1) {
                        tmpi = i;
                        tmpj = j;
                        count++;
                    }
                }
            }
            Assert.AreEqual(count, 10);
            if (tmpi < model.GameSize - 1 && tmpi > 0 && tmpj < model.GameSize-1 && tmpj > 0) {
                Assert.IsTrue(model.GameTable[tmpi + 1, tmpj + 1] >= 1);
                Assert.IsTrue(model.GameTable[tmpi, tmpj + 1] >= 1);
                Assert.IsTrue(model.GameTable[tmpi + 1, tmpj] >= 1);
                Assert.IsTrue(model.GameTable[tmpi - 1, tmpj - 1] >= 1);
                Assert.IsTrue(model.GameTable[tmpi + 1, tmpj - 1] >= 1);
                Assert.IsTrue(model.GameTable[tmpi - 1, tmpj + 1] >= 1);
                Assert.IsTrue(model.GameTable[tmpi - 1, tmpj] >= 1);
                Assert.IsTrue(model.GameTable[tmpi, tmpj - 1] >= 1);

            }
        }
        [TestMethod]
        public void MineSweeperModelNewGameLargeTest() {
            model.NewGame(16);
            int count = 0;
            int tmpi = 0;
            int tmpj = 0;
            for (int i = 0; i < model.GameSize; i++) {
                for (int j = 0; j < model.GameSize; j++) {
                    if (model.GameTable[i, j] == -1) {
                        tmpi = i;
                        tmpj = j;
                        count++;
                    }
                }
            }
            Assert.AreEqual(count, 16);
            if (tmpi < model.GameSize - 1 && tmpi > 0 && tmpj < model.GameSize-1 && tmpj > 0) {
                Assert.IsTrue(model.GameTable[tmpi + 1, tmpj + 1] >= 1);
                Assert.IsTrue(model.GameTable[tmpi, tmpj + 1] >= 1);
                Assert.IsTrue(model.GameTable[tmpi + 1, tmpj] >= 1);
                Assert.IsTrue(model.GameTable[tmpi - 1, tmpj - 1] >= 1);
                Assert.IsTrue(model.GameTable[tmpi + 1, tmpj - 1] >= 1);
                Assert.IsTrue(model.GameTable[tmpi - 1, tmpj + 1] >= 1);
                Assert.IsTrue(model.GameTable[tmpi - 1, tmpj] >= 1);
                Assert.IsTrue(model.GameTable[tmpi, tmpj - 1] >= 1);

            }
        }
        [TestMethod]
        public void MineSweeperModelStepOnTest() {
            model.NewGame(6);
            model.SetGameTable(table);
            model.StepOn(5, 4);
            bool[,] rev = new bool[,] {
                { false,false,false,false,false,false},
                {false,false,false,false,false,false},
                {false,false,false,false,false,false},
                {false,false,true,true,true,true},
                {false,false,true,true,true,true},
                { false,false,true,true,true,true}
            };
            for(int i = 0; i < 6; i++) {
                for(int j = 0; j < 6; j++) {
                    Assert.AreEqual(rev[i, j], model.RevealedFields[i, j]);
                    System.Diagnostics.Debug.Write(rev[i, j] + " ");
                    System.Diagnostics.Debug.Write(model.RevealedFields[i, j] + " ");
                }
                System.Diagnostics.Debug.WriteLine("");
            }
        }
        [TestMethod]
        public void MineSweeperModelPlayerChangeTest() {
            model.NewGame(6);
            model.SetGameTable(table);
            model.StepOn(5, 4);
            Assert.IsTrue(model.CurrentPlayer == Player.p2);
            model.StepOn(0, 0);
            Assert.IsTrue(model.CurrentPlayer == Player.p1);
        }
    }
}
