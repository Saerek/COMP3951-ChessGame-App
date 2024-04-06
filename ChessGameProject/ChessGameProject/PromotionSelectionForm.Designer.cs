namespace ChessGameProject
{
    partial class PromotionSelectionForm
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
            this.queenbutton = new System.Windows.Forms.Button();
            this.rookbutton = new System.Windows.Forms.Button();
            this.bishopbutton = new System.Windows.Forms.Button();
            this.knightbutton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // queenbutton
            // 
            this.queenbutton.Location = new System.Drawing.Point(135, 129);
            this.queenbutton.Name = "queenbutton";
            this.queenbutton.Size = new System.Drawing.Size(75, 33);
            this.queenbutton.TabIndex = 0;
            this.queenbutton.Text = "queen";
            this.queenbutton.UseVisualStyleBackColor = true;
            this.queenbutton.Click += new System.EventHandler(this.queenbutton_Click);
            // 
            // rookbutton
            // 
            this.rookbutton.Location = new System.Drawing.Point(216, 129);
            this.rookbutton.Name = "rookbutton";
            this.rookbutton.Size = new System.Drawing.Size(75, 33);
            this.rookbutton.TabIndex = 1;
            this.rookbutton.Text = "rook";
            this.rookbutton.UseVisualStyleBackColor = true;
            this.rookbutton.Click += new System.EventHandler(this.rookbutton_Click);
            // 
            // bishopbutton
            // 
            this.bishopbutton.Location = new System.Drawing.Point(54, 129);
            this.bishopbutton.Name = "bishopbutton";
            this.bishopbutton.Size = new System.Drawing.Size(75, 33);
            this.bishopbutton.TabIndex = 2;
            this.bishopbutton.Text = "bishop";
            this.bishopbutton.UseVisualStyleBackColor = true;
            this.bishopbutton.Click += new System.EventHandler(this.bishopbutton_Click);
            // 
            // knightbutton
            // 
            this.knightbutton.Location = new System.Drawing.Point(297, 129);
            this.knightbutton.Name = "knightbutton";
            this.knightbutton.Size = new System.Drawing.Size(75, 33);
            this.knightbutton.TabIndex = 3;
            this.knightbutton.Text = "knight";
            this.knightbutton.UseVisualStyleBackColor = true;
            this.knightbutton.Click += new System.EventHandler(this.knightbutton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(78, 58);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(273, 22);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "What piece do you want to promote to?";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // PromotionSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 200);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.knightbutton);
            this.Controls.Add(this.bishopbutton);
            this.Controls.Add(this.rookbutton);
            this.Controls.Add(this.queenbutton);
            this.Name = "PromotionSelectionForm";
            this.Text = "PromotionSelectionForm";
            this.Load += new System.EventHandler(this.PromotionSelectionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button queenbutton;
        private System.Windows.Forms.Button rookbutton;
        private System.Windows.Forms.Button bishopbutton;
        private System.Windows.Forms.Button knightbutton;
        private System.Windows.Forms.TextBox textBox1;
    }
}