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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        // Method to log a movement in the terminal
        public void LogMovement(string movement)
        {
            // Invoke if required to ensure thread safety
            if (this.form2_listbox_terminal.InvokeRequired)
            {
                this.form2_listbox_terminal.Invoke(new Action(() => LogMovementSafe(movement)));
            }
            else
            {
                LogMovementSafe(movement);
            }
        }

        // Method to log a movement safely
        private void LogMovementSafe(string movement)
        {
            // Add the movement to the terminal listbox
            this.form2_listbox_terminal.Items.Add(movement);
            // Set the index to the latest item
            this.form2_listbox_terminal.SelectedIndex = this.form2_listbox_terminal.Items.Count - 1;
        }
    }
}