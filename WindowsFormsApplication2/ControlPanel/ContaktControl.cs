using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProsecInc.Properties;

namespace ProsecInc.ControlPanel
{
    public partial class ContaktControl : UserControl
    {
        private static ContaktControl _instance;
        public static ContaktControl Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ContaktControl();
                return _instance;
            }
        }
        public ContaktControl()
        {
            InitializeComponent();
            bunifuImageButton5.Image = Resources.line;
            bunifuImageButtonKontaktEmail.Image = Resources.contact2;
            bunifuImageButtonKontaktPhone.Image = Resources.contact1;
            bunifuImageButton6.Image = Resources.contact3;
        }

        private void bunifuImageButtonKontaktPhone_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButtonKontaktEmail_Click(object sender, EventArgs e)
        {

        }
    }
}
