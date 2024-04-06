using ChessGameProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class PieceMovementTests
    {
        private Chessboard chessboard;

        [TestInitialize]
        public void Setup()
        {
            chessboard = new Chessboard();
            chessboard.InitializeChessboard();
        }

        [TestMethod]
        public void Pawn_ValidMove_Forward()
        {
            var pawn = new Pawn("white");
            chessboard.pieces[3, 1] = pawn;
            Assert.IsTrue(pawn.IsValidMove(3, 1, 4, 1));
        }

        [TestMethod]
        public void Rook_InvalidMove_Diagonal()
        {
            var rook = new Rook("white");
            chessboard.pieces[0, 0] = rook;
            Assert.IsFalse(rook.IsValidMove(0, 0, 1, 1));
        }

        [TestMethod]
        public void Knight_ValidMove()
        {
            var knight = new Knight("black");
            chessboard.pieces[0, 1] = knight;
            Assert.IsTrue(knight.IsValidMove(0, 1, 2, 2));
        }

        [TestMethod]
        public void Knight_InvalidMove()
        {
            var knight = new Knight("black");
            chessboard.pieces[0, 1] = knight;
            Assert.IsFalse(knight.IsValidMove(0, 1, 0, 2));
        }

        [TestMethod]
        public void Bishop_ValidMove()
        {
            var bishop = new Bishop("white");
            chessboard.pieces[0, 2] = bishop;
            Assert.IsTrue(bishop.IsValidMove(0, 2, 3, 5));
        }

        [TestMethod]
        public void Bishop_InvalidMove()
        {
            var bishop = new Bishop("white");
            chessboard.pieces[0, 2] = bishop;
            Assert.IsFalse(bishop.IsValidMove(0, 2, 4, 2));
        }

        [TestMethod]
        public void Queen_ValidMove_Diagonal()
        {
            var queen = new Queen("black");
            chessboard.pieces[0, 3] = queen;
            Assert.IsTrue(queen.IsValidMove(0, 3, 3, 0));
        }

        [TestMethod]
        public void Queen_InvalidMove_LikeKnight()
        {
            var queen = new Queen("black");
            chessboard.pieces[0, 3] = queen;
            Assert.IsFalse(queen.IsValidMove(0, 3, 2, 4));
        }

        [TestMethod]
        public void King_ValidMove_OneSquare()
        {
            var king = new King("white");
            chessboard.pieces[7, 4] = king;
            Assert.IsTrue(king.IsValidMove(7, 4, 7, 3));
        }

        [TestMethod]
        public void King_InvalidMove_TwoSquares()
        {
            var king = new King("white");
            chessboard.pieces[7, 4] = king;
            Assert.IsFalse(king.IsValidMove(7, 4, 7, 2));
        }
    }
}