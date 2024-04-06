using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Student Name: Eddie Xu, Samuel Park, Jeffery M Joseph 
/// Student Number: A01188464, A01342847, A01357857
/// Professor: Mirela Gutica
/// Date: 2024-03-23
/// </summary>

namespace ChessGameProject
{
    public partial class ChessLog : Form
    {
        public Chessboard chessboard;

        public ChessLog(Chessboard chessboard)
        {
            InitializeComponent();
            this.chessboard = chessboard;

            // Initialize trackbars
            InitializeTrackBars();
        }

        public void InitializeTrackBars()
        {
            trackBar_1.Minimum = 0;
            trackBar_1.Maximum = 23; // 24 levels, from 0 to 23
            trackBar_1.Value = 0; // Default to the original color segment
            trackBar_1.ValueChanged += TrackBar_ValueChanged;

            trackBar_2.Minimum = 0;
            trackBar_2.Maximum = 23; // 24 levels, from 0 to 23
            trackBar_2.Value = 0; // Default to the original color segment
            trackBar_2.ValueChanged += TrackBar_ValueChanged;
        }



        public void TrackBar_ValueChanged(object sender, EventArgs e)
        {
            // Ensure the chessboard reference is not null
            if (chessboard != null)
            {
                // Update chessboard square colors based on the current trackbar values
                chessboard.UpdateSquareColors(trackBar_1.Value, trackBar_2.Value);
            }
        }

        // Method to log a movement in the terminal (as previously defined)
        public void LogMovement(string movement)
        {
            if (this.form2_listbox_terminal.InvokeRequired)
            {
                this.form2_listbox_terminal.Invoke(new Action(() => LogMovementSafe(movement)));
            }
            else
            {
                LogMovementSafe(movement);
            }
        }

        // Safe log method (as previously defined)
        public void LogMovementSafe(string movement)
        {
            this.form2_listbox_terminal.Items.Add(movement);
            this.form2_listbox_terminal.SelectedIndex = this.form2_listbox_terminal.Items.Count - 1;
        }
    }
}