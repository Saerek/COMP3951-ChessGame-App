using ChessGameProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.CompilerServices;


namespace UnitTests
{
    [TestClass]
    public class ChessGameTests
    {
        [TestMethod]
        public void TestCastling_RookEndsUpInCorrectPosition()
        {
            var chessboard = new Chessboard();
            var rook = chessboard.pieces[7, 7];
            chessboard.MovePiece(7, 4, 7, 6);
            Assert.IsInstanceOfType(rook, typeof(Rook));
        }

        [TestMethod]
        public void TestTerminal_LogMovement_AddsEntryToListBox()
        {
            var form2 = new Form2();
            string testMovement = "Pawn to E4";
            form2.LogMovement(testMovement);
            Assert.AreEqual(form2.form2_listbox_terminal.Items.Count, 1);
            Assert.AreEqual(form2.form2_listbox_terminal.Items[0], testMovement);
        }
    }
}
