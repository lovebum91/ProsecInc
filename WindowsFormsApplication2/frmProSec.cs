using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ProsecInc.ControlPanel;
using ProsecInc.Extend;
using System.Deployment.Application;
using ProsecInc.Properties;

namespace ProsecInc
{
    public partial class frmProSec : Form
    {
        int togMove, X, Y;
        public frmProSec()
        {
            InitializeComponent();
            ntfProsec.Visible = false;
            panelBtnSystem.BackgroundImage = Resources.head02;
            panelBtnKontakt.BackgroundImage = Resources.head03;
            panelBtnSicherheit.BackgroundImage = Resources.head01_active;
        }
        private void SettingForm()
        {
            var link = RegistryUtil.GetConfigValueFromRegistry(RegistryType.ServerUrl);
            if (string.IsNullOrEmpty(link))
            {
                DialogResult dr = MessageBox.Show("This application cannot be start. Would you like to config the application now?", "Config", MessageBoxButtons.OK);
                if (DialogResult.OK == dr)
                {
                    (new Config()).ShowDialog(); 
                }
            }
        }
        #region Form load button follow active
        private void SicherheitActive()
        {
            this.panelBtnSicherheit.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.head01_active));
            this.panelBtnSystem.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.head02));
            this.panelBtnKontakt.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.head03));

            if (!panelContainer.Controls.Contains(SicherheitControl.Instance))
            {
                panelContainer.Controls.Add(SicherheitControl.Instance);
                SicherheitControl.Instance.Dock = DockStyle.Fill;
                SicherheitControl.Instance.BringToFront();
                SetFormTitle();
                //
            }
            else
                SicherheitControl.Instance.BringToFront();
        }

        private void frmProSec_Load(object sender, EventArgs e)
        {
            SettingForm();
            // Ham xu ly hien thi giao dien vao 1 goc nho
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width - 10,
                                      workingArea.Bottom - Size.Height - 10);
            SicherheitActive();
        }

        private void SetFormTitle()
        {
            string title = VersionUtil.GetVersionApp();

            this.Text = title;
            ntfProsec.Text = title;
            ntfProsec.Visible = true;
        }

        private void panelBtnSicherheit_Click(object sender, EventArgs e)
        {
            // LoadingProcess.StartLoading();
            SicherheitActive();
            //Thread.Sleep(300);
            //LoadingProcess.StopLoading();
        }

        private void panelBtnSystem_Click(object sender, EventArgs e)
        {
            // LoadingProcess.StartLoading();
            this.panelBtnSicherheit.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.head01));
            this.panelBtnSystem.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.head02_active));
            this.panelBtnKontakt.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.head03));

            if (!panelContainer.Controls.Contains(SystemControl.Instance))
            {
                panelContainer.Controls.Add(SystemControl.Instance);
                SystemControl.Instance.Dock = DockStyle.Fill;
                SystemControl.Instance.BringToFront();
            }
            else
                SystemControl.Instance.BringToFront();
            //Thread.Sleep(300);
            //LoadingProcess.StopLoading();
        }

        private void panelBtnKontakt_Click(object sender, EventArgs e)
        {
            // LoadingProcess.StartLoading();
            this.panelBtnSicherheit.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.head01));
            this.panelBtnSystem.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.head02));
            this.panelBtnKontakt.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.head03_active));
            
            if (!panelContainer.Controls.Contains(ContaktControl.Instance))
            {
                panelContainer.Controls.Add(ContaktControl.Instance);
                ContaktControl.Instance.Dock = DockStyle.Fill;
                ContaktControl.Instance.BringToFront();
            }
            else
                ContaktControl.Instance.BringToFront();
            //Thread.Sleep(300);
            //LoadingProcess.StopLoading();

        }

        private void bunBtnClose_Click(object sender, EventArgs e)
        {
           this.Hide();
           // Application.Exit();
        }

        
        #endregion

        #region Move drag form
        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            togMove = 1;
            X = e.X;
            Y = e.Y;
        }

        private void panelTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (togMove == 1)
                this.SetDesktopLocation(MousePosition.X - X, MousePosition.Y - Y);
        }

        private void panelTitle_MouseUp(object sender, MouseEventArgs e)
        {
            togMove = 0;
        }
        #endregion        

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TraySystem_ClickNotifyIcon(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }
    }
}
