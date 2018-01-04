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
    public partial class SystemControl : UserControl
    {
        private static SystemControl _instance;
        public static SystemControl Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SystemControl();
                return _instance;
            }
        }

        private void SystemNetZwerkActive()
        {
            if (!panelSystemContainer.Controls.Contains(SystemNetzwerkControl.Instance))
            {
                panelSystemContainer.Controls.Add(SystemNetzwerkControl.Instance);
                SystemNetzwerkControl.Instance.Dock = DockStyle.Fill;
                SystemNetzwerkControl.Instance.BringToFront();
            }
            else
                SystemNetzwerkControl.Instance.BringToFront();
        }

        public SystemControl()
        {
            InitializeComponent();
            SystemNetZwerkActive();
        }

        private void btnSystemNETZWERK_Click(object sender, EventArgs e)
        {
            btnSystemNETZWERK.BackColor = Color.FromArgb(74, 144, 226);
            btnSystemNETZWERK.FlatAppearance.BorderColor = Color.FromArgb(74, 144, 226);
            btnSystemSYSTEM.BackColor = Color.Transparent;
            btnSystemSYSTEM.FlatAppearance.BorderColor = Color.FromArgb(255, 255, 255);
            //
            SystemNetZwerkActive();
        }

        private void btnSystemSYSTEM_Click(object sender, EventArgs e)
        {
            btnSystemNETZWERK.BackColor = Color.Transparent;
            btnSystemNETZWERK.FlatAppearance.BorderColor = Color.FromArgb(255, 255, 255);
            btnSystemSYSTEM.BackColor = Color.FromArgb(74, 144, 226);
            btnSystemSYSTEM.FlatAppearance.BorderColor = Color.FromArgb(74, 144, 226);
            //
            if (!panelSystemContainer.Controls.Contains(SystemProcess.Instance))
            {
                panelSystemContainer.Controls.Add(SystemProcess.Instance);
                SystemProcess.Instance.Dock = DockStyle.Fill;
                SystemProcess.Instance.BringToFront();
            }
            else
                SystemProcess.Instance.BringToFront();
        }
    }
}
