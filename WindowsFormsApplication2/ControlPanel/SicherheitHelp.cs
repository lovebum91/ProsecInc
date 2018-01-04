using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProsecInc.ControlPanel
{
    public partial class SicherheitHelp : UserControl
    {
        private static SicherheitHelp _instance;
        public static SicherheitHelp Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SicherheitHelp();
                return _instance;
            }
        }

        public SicherheitHelp()
        {
            InitializeComponent();
        }

        private void SicherheitHelp_Load(object sender, EventArgs e)
        {

        }
    }
}
