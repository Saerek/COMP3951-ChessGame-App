namespace ChessGameProject
{
    partial class Form2
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
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 272);
            this.Controls.Add(this.form2_listbox_terminal);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListBox form2_listbox_terminal;
    }
}