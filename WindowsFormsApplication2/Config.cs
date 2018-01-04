using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProsecInc.Extend;

namespace ProsecInc
{
    public partial class Config : Form
    {
        public Config()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistryUtil.SetCongifValueToRegistry(RegistryType.ServerUrl, txtUrl.Text);
        }
    }
}
