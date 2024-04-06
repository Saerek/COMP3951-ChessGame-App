using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGameProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Windows.Forms;

namespace UnitTests
{
    [TestClass]
    public class ChessboardTests
    {
        private Chessboard chessboard;

        [TestInitialize]
        public void Setup()
        {
            chessboard = new Chessboard();
            chessboard.InitializeChessboard();
        }

        [TestMethod]
        public void UpdateSquareColors_ChangesBackgroundColors()
        {
            int lightSquareValue = 0;
            int darkSquareValue = 23;

            chessboard.UpdateSquareColors(lightSquareValue, darkSquareValue);

            Color expectedLightColor = chessboard.CalculateColor(lightSquareValue, true);
            Color actualLightColor = chessboard.squares[0, 0].BackColor;
            Assert.AreEqual(expectedLightColor, actualLightColor);

            Color expectedDarkColor = chessboard.CalculateColor(darkSquareValue, false);
            Color actualDarkColor = chessboard.squares[0, 1].BackColor;
            Assert.AreEqual(expectedDarkColor, actualDarkColor);
        }
    }
}