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
            this.ClientSize = new System.Drawing.Size(800, 800);
            this.MinimumSize = new System.Drawing.Size(800, 800);
            this.MaximumSize = new System.Drawing.Size(800, 800);
            this.Text = "ChessGame";
            this.Name = "Chessboard";

            TableLayoutPanel panel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 8,
                RowCount = 8,
            };

            panel.ColumnStyles.Clear();
            panel.RowStyles.Clear();

            for (int i = 0; i < 8; i++)
            {
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
                panel.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
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

