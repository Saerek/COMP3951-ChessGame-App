using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGameProject
{
    public partial class PromotionSelectionForm : Form
    {
        public PromotionSelectionForm()
        {
            InitializeComponent();
        }

        private void queenbutton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        private void bishopbutton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void knightbutton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void rookbutton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void PromotionSelectionForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
