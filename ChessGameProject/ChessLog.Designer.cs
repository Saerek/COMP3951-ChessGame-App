namespace ChessGameProject
{
    partial class ChessLog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.form2_listbox_terminal = new System.Windows.Forms.ListBox();
            this.trackBar_1 = new System.Windows.Forms.TrackBar();
            this.trackBar_2 = new System.Windows.Forms.TrackBar();
            this.tb1_label = new System.Windows.Forms.Label();
            this.tb2_label = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblWhiteWins = new System.Windows.Forms.Label();
            this.lblBlackWins = new System.Windows.Forms.Label();
            this.lblScoreBoard = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // form2_listbox_terminal
            // 
            this.form2_listbox_terminal.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.form2_listbox_terminal.FormattingEnabled = true;
            this.form2_listbox_terminal.ItemHeight = 17;
            this.form2_listbox_terminal.Location = new System.Drawing.Point(12, 12);
            this.form2_listbox_terminal.Name = "form2_listbox_terminal";
            this.form2_listbox_terminal.Size = new System.Drawing.Size(228, 242);
            this.form2_listbox_terminal.TabIndex = 0;
            // 
            // trackBar_1
            // 
            this.trackBar_1.Location = new System.Drawing.Point(9, 58);
            this.trackBar_1.Name = "trackBar_1";
            this.trackBar_1.Size = new System.Drawing.Size(209, 45);
            this.trackBar_1.TabIndex = 1;
            // 
            // trackBar_2
            // 
            this.trackBar_2.Location = new System.Drawing.Point(9, 164);
            this.trackBar_2.Name = "trackBar_2";
            this.trackBar_2.Size = new System.Drawing.Size(209, 45);
            this.trackBar_2.TabIndex = 2;
            // 
            // tb1_label
            // 
            this.tb1_label.AutoSize = true;
            this.tb1_label.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb1_label.Location = new System.Drawing.Point(9, 40);
            this.tb1_label.Name = "tb1_label";
            this.tb1_label.Size = new System.Drawing.Size(113, 15);
            this.tb1_label.TabIndex = 3;
            this.tb1_label.Text = "Light Squares Shade";
            // 
            // tb2_label
            // 
            this.tb2_label.AutoSize = true;
            this.tb2_label.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb2_label.Location = new System.Drawing.Point(9, 146);
            this.tb2_label.Name = "tb2_label";
            this.tb2_label.Size = new System.Drawing.Size(110, 15);
            this.tb2_label.TabIndex = 4;
            this.tb2_label.Text = "Dark Squares Shade";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb1_label);
            this.groupBox1.Controls.Add(this.tb2_label);
            this.groupBox1.Controls.Add(this.trackBar_1);
            this.groupBox1.Controls.Add(this.trackBar_2);
            this.groupBox1.Location = new System.Drawing.Point(12, 269);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 239);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Color Controls";
            // 
            // lblWhiteWins
            // 
            this.lblWhiteWins.AutoSize = true;
            this.lblWhiteWins.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWhiteWins.Location = new System.Drawing.Point(20, 583);
            this.lblWhiteWins.Name = "lblWhiteWins";
            this.lblWhiteWins.Size = new System.Drawing.Size(67, 20);
            this.lblWhiteWins.TabIndex = 6;
            this.lblWhiteWins.Text = "White: 0";
            // 
            // lblBlackWins
            // 
            this.lblBlackWins.AutoSize = true;
            this.lblBlackWins.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlackWins.Location = new System.Drawing.Point(165, 583);
            this.lblBlackWins.Name = "lblBlackWins";
            this.lblBlackWins.Size = new System.Drawing.Size(65, 20);
            this.lblBlackWins.TabIndex = 6;
            this.lblBlackWins.Text = "Black: 0";
            // 
            // lblScoreBoard
            // 
            this.lblScoreBoard.AutoSize = true;
            this.lblScoreBoard.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScoreBoard.Location = new System.Drawing.Point(68, 535);
            this.lblScoreBoard.Name = "lblScoreBoard";
            this.lblScoreBoard.Size = new System.Drawing.Size(114, 25);
            this.lblScoreBoard.TabIndex = 7;
            this.lblScoreBoard.Text = "Scoreboard";
            // 
            // ChessLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 662);
            this.Controls.Add(this.lblScoreBoard);
            this.Controls.Add(this.lblBlackWins);
            this.Controls.Add(this.lblWhiteWins);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.form2_listbox_terminal);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChessLog";
            this.Text = "ChessLog";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListBox form2_listbox_terminal;
        private System.Windows.Forms.TrackBar trackBar_1;
        private System.Windows.Forms.TrackBar trackBar_2;
        private System.Windows.Forms.Label tb1_label;
        private System.Windows.Forms.Label tb2_label;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblWhiteWins;
        private System.Windows.Forms.Label lblBlackWins;
        private System.Windows.Forms.Label lblScoreBoard;
    }
}