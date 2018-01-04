using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProsecInc
{
    public partial class frmLoading : Form
    {
        public frmLoading()
        {
            InitializeComponent();
        }

        private void frmLoading_Load(object sender, EventArgs e)
        {
            // Ham xu ly hien thi giao dien vao 1 goc nho
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width - 10,
                                      workingArea.Bottom - Size.Height - 10);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
