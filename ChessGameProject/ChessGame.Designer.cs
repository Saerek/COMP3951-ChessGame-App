using System.Drawing;
using System;
using System.Windows.Forms;

namespace ChessGameProject
{
    partial class Chessboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Chatbox components
        private TextBox txtChatInput;
        private RichTextBox lstChatHistory;
        private Button btnSendChat;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 800);
            this.MinimumSize = new System.Drawing.Size(1100, 800);
            this.MaximumSize = new System.Drawing.Size(1100, 800);
            this.Text = "Chess Game";
            this.Name = "Chessboard";

            TableLayoutPanel panel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 9,
                RowCount = 8,
            };

            panel.ColumnStyles.Clear();
            panel.RowStyles.Clear();

            for (int i = 0; i < 9; i++)
            {
                if (i < 8)
                {
                    panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
                    panel.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
                }
                else // The last column for additional content
                {
                    panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
                    panel.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
                }
            }

            this.Controls.Add(panel);

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    squares[i, j] = new Button
                    {
                        Dock = DockStyle.Fill,
                        Margin = new Padding(0),
                        Name = $"button{i}_{j}"
                    };
                    panel.Controls.Add(squares[i, j], j, i);
                }
            }

            // Initialize chat input TextBox
            txtChatInput = new TextBox
            {
                Dock = DockStyle.Bottom,
                Name = "txtChatInput",
                Size = new Size(200, 100), // Adjust size 
                Multiline = true
            };

            // Initialize chat history RichTextBox
            lstChatHistory = new RichTextBox
            {
                Dock = DockStyle.Fill,
                Name = "lstChatHistory",
                ReadOnly = true, // Make it read-only
                WordWrap = true, // Enable word wrap
                ScrollBars = RichTextBoxScrollBars.Vertical, // Enable vertical scroll bar
                BorderStyle = BorderStyle.None // Optional: Remove the border for aesthetic reasons
            };


            // Initialize send Button
            btnSendChat = new Button
            {
                Dock = DockStyle.Fill,
                BackColor = Color.LightGray,
                Text = "Send",
                Name = "btnSendChat"
            };

            // Add the chat controls to the panel   
            panel.Controls.Add(txtChatInput, 8, 6);     // Adding at the bottom of the 9th column
            panel.Controls.Add(lstChatHistory, 8, 0);   // Adding to span the 9th column
            panel.Controls.Add(btnSendChat, 8, 7);      // Adding above the TextBox

            // Set the row span for the chat history RichTextBox to take up the entire column height minus where the TextBox and Button are
            panel.SetRowSpan(lstChatHistory, 6);
        }

        public void InitializeChessboard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    squares[i, j].BackColor = (i + j) % 2 == 0 ? Color.White : Color.Gray;
                    squares[i, j].Click += new EventHandler(Button_Click);
                    squares[i, j].Tag = new Point(i, j);
                }
            }
        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>


        #endregion
    }
}

