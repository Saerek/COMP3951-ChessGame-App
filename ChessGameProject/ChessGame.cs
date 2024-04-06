using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChessGameProject.Properties;

/// <summary>
/// Student Name: Eddie Xu, Samuel Park, Jeffery M Joseph 
/// Student Number: A01188464, A01342847, A01357857
/// Professor: Mirela Gutica
/// Date: 2024-03-23
/// </summary>

namespace ChessGameProject
{
    public partial class Chessboard : Form
    {
        public Button[,] squares = new Button[8, 8];   // 8x8 grid of buttons
        public Piece[,] pieces = new Piece[8, 8];      // 8x8 grid of pieces
        public Button lastClicked = null;              // Last clicked button
        public int lastClickedX, lastClickedY;         // Last clicked button's coordinates
        public string currentPlayerTurn = "white";     // Current player's turn
        internal static int whiteMoveCount = 0;          // White move count
        internal static int blackMoveCount = 0;         // Black move count
        public ChessLog form2;                            // Form2 object  


        public Chessboard()
        {
            InitializeComponent();      // Initialize the form
            InitializeChessboard();     // Initialize the chessboard
            InitializePieces();         // Initialize the pieces
            SetInitialImages();         // Set the initial images
            Piece.SetBoard(pieces);     // Set the board for the pieces
            form2 = new ChessLog(this);        // Create a new Form2 object
            form2.Show();               // Show Form2
            this.LocationChanged += Chessboard_LocationChanged;     // Add event handler for LocationChanged
            this.FormClosing += Chessboard_FormClosing;             // Add event handler for FormClosing
        }

        public void UpdateSquareColors(int trackBar1Value, int trackBar2Value)
        {
            // Convert trackBar values to color shades
            Color lightColor = CalculateColor(trackBar1Value, true);
            Color darkColor = CalculateColor(trackBar2Value, false);

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    squares[i, j].BackColor = (i + j) % 2 == 0 ? lightColor : darkColor;
                }
            }
        }

        // This method calculates the color based on the value and whether it's for light or dark squares.
        public Color CalculateColor(int value, bool isForLightSquares)
        {
            // Return default chessboard colors if value is 0 (original segment)
            if (value == 0)
            {
                return isForLightSquares ? Color.White : Color.LightGray; // Using LightGray for a lighter dark square
            }

            // Determine the color segment
            int segment = value / 5; // Integer division to categorize into segments

            // Adjust for the final segment having an extra level
            if (value == 23) segment = 4; // Ensure the highest value maps to the last color segment

            // Updated color arrays with lighter shades
            Color[] lightColors = new Color[] { Color.White, Color.LightSkyBlue, Color.LavenderBlush, Color.LightYellow, Color.MistyRose };
            Color[] darkColors = new Color[] { Color.LightGray, Color.PowderBlue, Color.Thistle, Color.PaleGoldenrod, Color.Pink };

            // Choose color based on the segment
            Color chosenColor = isForLightSquares ? lightColors[segment] : darkColors[segment];

            return chosenColor;
        }

        // This method handles the click event of the chessboard buttons.
        public void Button_Click(object sender, EventArgs e)
        {
            // Attempt to cast the sender object to a Button
            Button clickedButton = sender as Button;
            if (clickedButton == null) return; // If casting fails, return

            // Extract the location information from the button's Tag property
            if (!(clickedButton.Tag is Point location)) return; // If the Tag is not a Point, return

            // Extract the coordinates (x, y) from the Point
            int x = location.X;
            int y = location.Y;

            // Check if the coordinates are within the valid range of the chessboard (8x8 grid)
            if (x < 0 || y < 0 || x >= 8 || y >= 8) return;

            // If no previous button was clicked
            if (lastClicked == null)
            {
                // Check if there's a piece on the clicked button and if it's the current player's turn
                if (pieces[x, y] == null || pieces[x, y].Color != currentPlayerTurn) return;

                // Set the clicked button as the last clicked button
                lastClicked = clickedButton;
                lastClickedX = x;
                lastClickedY = y;
                clickedButton.BackColor = Color.LightBlue; // Change background color to indicate selection
            }
            else // If a previous button was clicked
            {
                if (x != lastClickedX || y != lastClickedY) // If the clicked button is different from the last clicked button
                {
                    // Attempt to move the piece to the clicked button's location
                    MovePiece(lastClickedX, lastClickedY, x, y); // Pass the coordinates of both buttons
                    squares[lastClickedX, lastClickedY].BackColor = (lastClickedX + lastClickedY) % 2 == 0 ? Color.White : Color.Gray;
                    lastClicked = null; // Reset the last clicked button
                }
                else // If the same button was clicked again
                {
                    // Deselect the button
                    lastClicked.BackColor = (lastClickedX + lastClickedY) % 2 == 0 ? Color.White : Color.Gray;
                    lastClicked = null; // Reset the last clicked button
                }
            }
        }

        // This method moves a piece from its starting position to an end position on the chessboard.
        public void MovePiece(int startX, int startY, int endX, int endY)
        {
            // Check if there is a valid last clicked button or if there is a piece at the starting position
            if (lastClicked == null || pieces[startX, startY] == null) return;

            // Get the piece to be moved from the starting position
            Piece pieceToMove = pieces[startX, startY];

            // Check if the move is valid according to the rules of the piece
            if (pieceToMove.IsValidMove(startX, startY, endX, endY))
            {
                // Log the movement description
                string pieceColor = pieceToMove.Color;
                string pieceType = pieceToMove.GetType().Name;
                string startSquare = ConvertToChessNotation(startX, startY);
                string endSquare = ConvertToChessNotation(endX, endY);
                string moveDescription = $"{pieceColor} {pieceType} moved from {startSquare} to {endSquare}";
                form2.LogMovement(moveDescription);

                // Check if the piece captured the opponent's king
                if (pieces[endX, endY] is King)
                {
                    string winner = pieceToMove.Color == "white" ? "White" : "Black";
                    MessageBox.Show($"{winner} is the Winner", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetBoard(); // Reset the board to its initial state
                    return;
                }

                // Update the piece's position on the board
                pieces[endX, endY] = pieceToMove;
                pieces[startX, startY] = null;

                // Update the visual representation of the piece on the chessboard
                squares[endX, endY].BackgroundImage = squares[startX, startY].BackgroundImage;
                squares[endX, endY].BackgroundImageLayout = ImageLayout.Stretch;
                squares[startX, startY].BackgroundImage = null;

                // Handle castling if the moved piece is a king and castling is performed
                if (pieceToMove is King && Math.Abs(endY - startY) == 2)
                {
                    int rookY = endY == 6 ? 7 : 0;
                    int rookTargetY = endY == 6 ? 5 : 3;
                    Piece rook = pieces[startX, rookY];
                    squares[startX, rookTargetY].BackgroundImage = squares[startX, rookY].BackgroundImage;
                    pieces[startX, rookTargetY] = rook;
                    pieces[startX, rookY] = null;
                    squares[startX, rookY].BackgroundImage = null;
                }

                // After moving the piece and any other logic in MovePiece
                if (pieceToMove is Pawn && (endX == 0 || endX == 7)) // Check for pawn reaching the opposite end
                {
                    // Show the promotion selection form
                    using (var promotionForm = new PromotionSelectionForm())
                    {
                        var result = promotionForm.ShowDialog();

                        // Determine the chosen piece based on the dialog result
                        Piece promotedPiece = null;
                        switch (result)
                        {
                            case DialogResult.Yes: // Assume this means Queen
                                promotedPiece = new Queen(pieceToMove.Color);
                                break;
                            case DialogResult.No: // Assume this means Rook
                                promotedPiece = new Rook(pieceToMove.Color);
                                break;
                            case DialogResult.OK: // Assume this means Bishop
                                promotedPiece = new Bishop(pieceToMove.Color);
                                break;
                            case DialogResult.Cancel: // Assume this means Knight
                                promotedPiece = new Knight(pieceToMove.Color);
                                break;
                        }

                        // Replace pawn with the chosen piece
                        if (promotedPiece != null)
                        {
                            pieces[endX, endY] = promotedPiece;

                            // Construct the image key for the new piece
                            string pieceImageKey = $"{promotedPiece.Color}_{promotedPiece.GetType().Name.ToLower()}";
                            var promotionImage = (Image)Properties.Resources.ResourceManager.GetObject(pieceImageKey);
                            if (promotionImage != null)
                            {
                                squares[endX, endY].BackgroundImage = promotionImage;
                            }
                        }
                    }
                }



                // Switch to the next player's turn
                currentPlayerTurn = currentPlayerTurn == "white" ? "black" : "white";

                // Reset the background color of the last clicked button
                lastClicked.BackColor = (startX + startY) % 2 == 0 ? Color.White : Color.Gray;
                Refresh(); // Refresh the form to update the UI
            }
            else
            {
                // If the move is not valid, reset the background color of the last clicked button
                lastClicked.BackColor = (startX + startY) % 2 == 0 ? Color.White : Color.Gray;
            }
        }

        // This method adjusts the position of form2 (terminal window) when the main chessboard form is moved.
        public void Chessboard_LocationChanged(object sender, EventArgs e)
        {
            // Check if form2 exists and is not disposed
            if (form2 != null && !form2.IsDisposed)
            {
                // Calculate the new location for form2 based on the main chessboard form's location and size
                int borderWidth = SystemInformation.FrameBorderSize.Width;
                Point newLocation = new Point(this.Location.X + this.Width - borderWidth, this.Location.Y);

                // Set the new location for form2
                form2.Location = newLocation;
            }
        }

        // This method converts the coordinates (x, y) of a square on the chessboard to chess notation (e.g., A1, B2).
        public string ConvertToChessNotation(int x, int y)
        {
            // Calculate the column letter based on the y-coordinate
            char column = (char)('A' + y);

            // Calculate the row number based on the x-coordinate
            int row = 8 - x;

            // Combine the column letter and row number to form the chess notation
            return $"{column}{row}";
        }

        // This method is triggered when the chessboard form is closing, and it closes the form2 (terminal window) if it exists.
        public void Chessboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Check if form2 exists and is not disposed
            if (form2 != null && !form2.IsDisposed)
            {
                // Close form2
                form2.Close();
            }
        }

        // This method resets the chessboard to its initial state by removing all pieces from the board and reinitializing them.
        public void ResetBoard()
        {
            // Clear all pieces from the board and reset the background images of squares
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    pieces[i, j] = null; // Remove piece from the logical representation
                    squares[i, j].BackgroundImage = null; // Reset the visual representation
                }
            }

            // Reinitialize pieces on the board
            InitializePieces();

            // Set the current player's turn to white
            currentPlayerTurn = "white";
        }

        public void InitializePieces()
        {
            pieces = new Piece[8, 8];
            for (int i = 0; i < 8; i++)
            {
                pieces[1, i] = new Pawn("black");       
                squares[1, i].BackgroundImage = Properties.Resources.black_pawn;    // Set the image of the black pawn
            }
            pieces[0, 0] = new Rook("black");
            pieces[0, 7] = new Rook("black");
            pieces[0, 1] = new Knight("black");
            pieces[0, 6] = new Knight("black");
            pieces[0, 2] = new Bishop("black");
            pieces[0, 5] = new Bishop("black");
            pieces[0, 3] = new Queen("black");
            pieces[0, 4] = new King("black");

            for (int i = 0; i < 8; i++)
            {
                pieces[6, i] = new Pawn("white");
                squares[6, i].BackgroundImage = Properties.Resources.white_pawn;    // Set the image of the white pawn
            }
            pieces[7, 0] = new Rook("white");
            pieces[7, 7] = new Rook("white");
            pieces[7, 1] = new Knight("white");
            pieces[7, 6] = new Knight("white");
            pieces[7, 2] = new Bishop("white");
            pieces[7, 5] = new Bishop("white");
            pieces[7, 3] = new Queen("white");
            pieces[7, 4] = new King("white");

            squares[0, 0].BackgroundImage = Properties.Resources.black_rook;
            squares[0, 7].BackgroundImage = Properties.Resources.black_rook;
            squares[0, 1].BackgroundImage = Properties.Resources.black_knight;
            squares[0, 6].BackgroundImage = Properties.Resources.black_knight;
            squares[0, 2].BackgroundImage = Properties.Resources.black_bishop;
            squares[0, 5].BackgroundImage = Properties.Resources.black_bishop;
            squares[0, 3].BackgroundImage = Properties.Resources.black_queen;
            squares[0, 4].BackgroundImage = Properties.Resources.black_king;
            squares[7, 0].BackgroundImage = Properties.Resources.white_rook;
            squares[7, 7].BackgroundImage = Properties.Resources.white_rook;
            squares[7, 1].BackgroundImage = Properties.Resources.white_knight;
            squares[7, 6].BackgroundImage = Properties.Resources.white_knight;
            squares[7, 2].BackgroundImage = Properties.Resources.white_bishop;
            squares[7, 5].BackgroundImage = Properties.Resources.white_bishop;
            squares[7, 3].BackgroundImage = Properties.Resources.white_queen;
            squares[7, 4].BackgroundImage = Properties.Resources.white_king;
        }

        public void SetInitialImages()
        {
            // Iterate through each square on the chessboard
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    // Reset the background image of the square
                    squares[i, j].BackgroundImage = null;

                    // If there is a piece at the current square
                    if (pieces[i, j] != null)
                    {
                        // Get the type and color of the piece
                        string pieceType = pieces[i, j].GetType().Name.ToLower();
                        string color = pieces[i, j].Color.ToLower();

                        // Construct the resource name based on piece type and color
                        string resourceName = $"{color}_{pieceType}";

                        // Get the corresponding image from the resources
                        var image = (Image)Properties.Resources.ResourceManager.GetObject(resourceName);

                        // If the image is found in the resources
                        if (image != null)
                        {
                            // Set the background image of the square with the piece image
                            squares[i, j].BackgroundImage = image;
                            squares[i, j].BackgroundImageLayout = ImageLayout.Stretch; // Stretch the image to fit the square
                        }
                    }
                }
            }
        }
    }

    // Abstract class representing a chess piece
    public abstract class Piece
    {
        // Color of the piece
        public string Color { get; private set; }

        // Flag indicating if the piece has moved
        public bool HasMoved { get; protected set; }

        // Static property representing the chessboard
        public static Piece[,] Board { get; private set; }

        // Constructor to initialize color and HasMoved flag
        protected Piece(string color)
        {
            Color = color;
            HasMoved = false;
        }

        // Method to set the chessboard
        public static void SetBoard(Piece[,] b) => Board = b;

        // Abstract method to check if a move is valid for the specific piece
        public abstract bool IsValidMove(int startX, int startY, int endX, int endY);
    }

    // Class representing a Pawn piece
    public class Pawn : Piece
    {
        // Constructor to initialize Pawn with color
        public Pawn(string color) : base(color) { }

        // Method to check if a move is valid for the Pawn
        public override bool IsValidMove(int startX, int startY, int endX, int endY)
        {
            // Determine the direction based on the color of the Pawn
            int direction = this.Color == "white" ? -1 : 1;

            // Check if it's the Pawn's first move
            bool isFirstMove = (this.Color == "white" && startX == 6) || (this.Color == "black" && startX == 1);

            // Check if the Pawn is moving one square forward
            bool isForwardOne = startX + direction == endX && startY == endY && Board[endX, endY] == null;

            // Check if the Pawn is moving two squares forward (only on the first move)
            bool isForwardTwo = isFirstMove && startX + 2 * direction == endX && startY == endY && Board[endX, endY] == null && Board[startX + direction, startY] == null;

            // Check if the Pawn is capturing a piece diagonally
            bool isCapture = startX + direction == endX && Math.Abs(endY - startY) == 1 && Board[endX, endY] != null && Board[endX, endY].Color != this.Color;

            // Check if the Pawn is performing an en passant capture
            bool isEnPassant = startX + direction == endX && Math.Abs(endY - startY) == 1 && Board[endX, endY] == null && Board[startX, endY] != null && Board[startX, endY] is Pawn && Board[startX, endY].Color != this.Color && ((this.Color == "white" && Chessboard.blackMoveCount == 1) || (this.Color == "black" && Chessboard.whiteMoveCount == 1));

            // Return true if any of the conditions for a valid move are met
            if (isForwardOne || isForwardTwo)
            {
                return true;
            }
            else if (isCapture)
            {
                return true;
            }
            else if (isEnPassant)
            {
                // Remove the captured Pawn in an en passant capture
                Board[startX, endY] = null;
                return true;
            }
            return false; // Otherwise, return false
        }
    }

    // Class representing a Rook piece
    public class Rook : Piece
    {
        // Constructor to initialize Rook with color
        public Rook(string color) : base(color) { }

        // Method to check if a move is valid for the Rook
        public override bool IsValidMove(int startX, int startY, int endX, int endY)
        {
            // Check if the move is along a straight line (either horizontally or vertically)
            if (startX != endX && startY != endY) return false;

            // Determine the minimum and maximum coordinates based on the direction of the move
            int min = startX == endX ? Math.Min(startY, endY) : Math.Min(startX, endX);
            int max = startX == endX ? Math.Max(startY, endY) : Math.Max(startX, endX);

            // Check for any pieces blocking the path of the Rook
            for (int i = min + 1; i < max; i++)
            {
                if (startX == endX && Board[endX, i] != null) return false;
                if (startY == endY && Board[i, endY] != null) return false;
            }

            // Return true if the destination square is empty or contains an opponent's piece
            return Board[endX, endY] == null || Board[endX, endY].Color != this.Color;
        }
    }

    // Class representing a Knight piece
    public class Knight : Piece
    {
        // Constructor to initialize Knight with color
        public Knight(string color) : base(color) { }

        // Method to check if a move is valid for the Knight
        public override bool IsValidMove(int startX, int startY, int endX, int endY)
        {
            // Check if the move follows the L-shaped pattern of the Knight
            if ((Math.Abs(startX - endX) == 2 && Math.Abs(startY - endY) == 1) ||
                (Math.Abs(startX - endX) == 1 && Math.Abs(startY - endY) == 2))
            {
                // Check if the destination square is empty or contains an opponent's piece
                if (Board[endX, endY] != null && Board[endX, endY].Color == this.Color)
                {
                    return false; // Cannot capture own piece
                }
                return true; // Valid move
            }
            return false; // Invalid move
        }
    }

    // Class representing a Bishop piece
    public class Bishop : Piece
    {
        // Constructor to initialize Bishop with color
        public Bishop(string color) : base(color) { }

        // Method to check if a move is valid for the Bishop
        public override bool IsValidMove(int startX, int startY, int endX, int endY)
        {
            // Check if the move follows the diagonal pattern of the Bishop
            if (Math.Abs(startX - endX) != Math.Abs(startY - endY)) return false;
            int stepX = (endX > startX) ? 1 : -1;
            int stepY = (endY > startY) ? 1 : -1;
            int distance = Math.Abs(endX - startX);
            for (int i = 1; i < distance; i++)
            {
                if (Board[startX + i * stepX, startY + i * stepY] != null) return false; // Check if the path is clear
            }
            return Board[endX, endY] == null || Board[endX, endY].Color != this.Color; // Check if the destination square is empty or contains an opponent's piece
        }
    }

    // Class representing a Queen piece
    public class Queen : Piece
    {
        // Constructor to initialize Queen with color
        public Queen(string color) : base(color) { }

        // Method to check if a move is valid for the Queen
        public override bool IsValidMove(int startX, int startY, int endX, int endY)
        {
            // Check if the move follows the pattern of either a Rook or a Bishop
            if (startX != endX && startY != endY && Math.Abs(startX - endX) != Math.Abs(startY - endY)) return false;
            int stepX = startX == endX ? 0 : (endX > startX ? 1 : -1);
            int stepY = startY == endY ? 0 : (endY > startY ? 1 : -1);
            int distance = Math.Max(Math.Abs(endX - startX), Math.Abs(endY - startY));
            for (int i = 1; i < distance; i++)
            {
                if (Board[startX + i * stepX, startY + i * stepY] != null) return false; // Check if the path is clear
            }
            if (Board[endX, endY] != null && Board[endX, endY].Color == this.Color) return false; // Cannot capture own piece
            return true; // Valid move
        }
    }

    // Class representing a King piece
    public class King : Piece
    {
        // Constructor to initialize King with color
        public King(string color) : base(color) { }

        // Method to check if a move is valid for the King
        public override bool IsValidMove(int startX, int startY, int endX, int endY)
        {
            // Check if the move is within one square in any direction
            if (Math.Abs(startX - endX) <= 1 && Math.Abs(startY - endY) <= 1)
            {
                return Board[endX, endY] == null || Board[endX, endY].Color != this.Color; // Check if the destination square is empty or contains an opponent's piece
            }
            // Check for castling move
            if (!HasMoved && Math.Abs(startY - endY) == 2 && startX == endX)
            {
                int direction = (endY - startY > 0) ? 1 : -1;
                int rookY = (direction == 1) ? 7 : 0;
                Piece potentialRook = Board[startX, rookY];
                if (potentialRook is Rook && !potentialRook.HasMoved)
                {
                    for (int y = Math.Min(startY, rookY) + 1; y < Math.Max(startY, rookY); y++)
                    {
                        if (Board[startX, y] != null)
                        {
                            return false; // Cannot castle through check or occupied squares
                        }
                    }
                    return true; // Valid castling move
                }
            }
            return false; // Invalid move
        }
    }
}