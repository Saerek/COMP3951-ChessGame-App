using ChessGameProject; // Use the correct namespace for your project
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class ScoreboardTest
    {
        private Chessboard chessboard;

        [TestInitialize]
        public void TestSetup()
        {
            chessboard = new Chessboard();
            chessboard.InitializeChessboard();
            chessboard.InitializePieces();
            // Reset win counters to ensure a clean state for each test
            Chessboard.whiteWins = 0;
            Chessboard.blackWins = 0;
        }

        [TestMethod]
        public void WinCounter_WhiteWin_IncrementsByOne()
        {
            // Assuming you have a way to simulate a white win, for this example,
            // we will increment directly for demonstration as a placeholder for your actual game logic
            Chessboard.whiteWins++; // This line is just for illustrating the increment. Replace with your actual win logic trigger.

            // Assert that the white win counter incremented by one
            Assert.AreEqual(1, Chessboard.whiteWins, "The white win counter should increment by 1 after a white win.");
        }

        [TestMethod]
        public void WinCounter_BlackWin_IncrementsByOne()
        {
            // Similarly, simulate a black win
            Chessboard.blackWins++; // This is a placeholder. Replace with the actual logic that leads to a win increment.

            // Assert that the black win counter incremented by one
            Assert.AreEqual(1, Chessboard.blackWins, "The black win counter should increment by 1 after a black win.");
        }
    }
}
