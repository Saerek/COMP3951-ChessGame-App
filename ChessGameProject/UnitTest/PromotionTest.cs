using ChessGameProject; // Use the correct namespace for your project
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTests
{

    [TestClass]
    public class PromotionTest
    {
        private Chessboard chessboard;

        [TestInitialize]
        public void TestSetup()
        {
            //Initialize a Chessboard         
            chessboard = new Chessboard();
            chessboard.InitializeChessboard(); 
            chessboard.InitializePieces(); 
        }

        [TestMethod]
        public void Promotion_ToQueen()
        {
            // Simulate moving a white pawn to the promotion row
            int startX = 6;
            int startY = 0;
            int endX = 0;
            int endY = 0;
            chessboard.MovePiece(startX, startY, endX, endY); 

            // Check if the pawn has been promoted to a Queen
            var promotedPiece = chessboard.pieces[endX, endY];
            Assert.IsTrue(promotedPiece is Queen, "Pawn was not promoted to a Queen.");

            // Optionally, check the piece's color or other properties
            Assert.AreEqual("white", promotedPiece.Color, "Promoted piece is not the correct color.");
        }

        [TestMethod]
        public void Promotion_ToBishop()
        {
            // Simulate moving a white pawn to the promotion row
            int startX = 6;
            int startY = 0;
            int endX = 0;
            int endY = 0;
            chessboard.MovePiece(startX, startY, endX, endY); 

            // Check if the pawn has been promoted to a Bishop
            var promotedPiece = chessboard.pieces[endX, endY];
            Assert.IsTrue(promotedPiece is Bishop, "Pawn was not promoted to a Bishop.");

            // Optionally, check the piece's color or other properties
            Assert.AreEqual("white", promotedPiece.Color, "Promoted piece is not the correct color.");
        }

        [TestMethod]
        public void Promotion_ToKnight()
        {
            // Simulate moving a white pawn to the promotion row
            int startX = 6;
            int startY = 0;
            int endX = 0;
            int endY = 0;
            chessboard.MovePiece(startX, startY, endX, endY); 
            // Check if the pawn has been promoted to a Knight
            var promotedPiece = chessboard.pieces[endX, endY];
            Assert.IsTrue(promotedPiece is Knight, "Pawn was not promoted to a Knight.");

            // Optionally, check the piece's color or other properties
            Assert.AreEqual("white", promotedPiece.Color, "Promoted piece is not the correct color.");
        }

        [TestMethod]
        public void Promotion_ToRook()
        {
            // Simulate moving a white pawn to the promotion row
            int startX = 6;
            int startY = 0;
            int endX = 0;
            int endY = 0;
            chessboard.MovePiece(startX, startY, endX, endY);
            // Check if the pawn has been promoted to a Rook
            var promotedPiece = chessboard.pieces[endX, endY];
            Assert.IsTrue(promotedPiece is Rook, "Pawn was not promoted to a Rook.");

            // Optionally, check the piece's color or other properties
            Assert.AreEqual("white", promotedPiece.Color, "Promoted piece is not the correct color.");
        }
    }
}
