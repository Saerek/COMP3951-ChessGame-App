using ChessGameProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;


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
            var chessboard = new Chessboard();
            var chessLog = new ChessLog(chessboard);

            string testMovement = "Pawn to E4";
            chessLog.LogMovement(testMovement);

            // Reflection to access the private ListBox control
            var listBoxField = chessLog.GetType().GetField("form2_listbox_terminal", BindingFlags.NonPublic | BindingFlags.Instance);
            var listBox = listBoxField.GetValue(chessLog) as ListBox;

            Assert.AreEqual(1, listBox.Items.Count);
            Assert.AreEqual(testMovement, listBox.Items[0].ToString());
        }
    }
}
