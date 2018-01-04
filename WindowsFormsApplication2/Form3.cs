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
    public partial class frmProcess : Form
    {
        int togMove, X, Y;
        public frmProcess()
        {

            // LoadingProcess.StartLoading();
            InitializeComponent();
            // LoadingProcess.StopLoading();

        }

        private void frmProcess_Load(object sender, EventArgs e)
        {
            this.panelBtnSicherheit.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.head01_active));
            this.panelBtnSystem.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.head02));
            this.panelBtnKontakt.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.head03));
            SicherheitVisibleControl(true);
            SystemVisibleControl(false);
            KontaktVisibleControl(false);
        }

        #region Cho phep truyen vao cac control an hien theo kich ban
        private void SicherheitVisibleControl(bool enable)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                MultiControlProcess.VisibleControls(enable,
                    bunifuImageButtonWarning, bunifuImageButtonHelp);
            }));
        }

        private void SystemVisibleControl(bool enable)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                MultiControlProcess.VisibleControls(enable,
                    btnSystemNETZWERK, btnSystemSYSTEM, lbInfoWLAN, lbInfoEXTERN, lbInfoMAC,
                    lbSystemLabelWlan, lbSystemLabelExtern, lbSystemLabelMac);
            }));
        }

        private void KontaktVisibleControl(bool enable)
        {
            this.Invoke(new MethodInvoker(delegate
           {
               MultiControlProcess.VisibleControls(enable,
                   lbKontaktSecurityOPerationCenter, lbKontaktGerneMail, bunifuImageButtonKontaktPhone, bunifuImageButtonKontaktEmail,
                   lbKontaktPhone, lbKontaktEmail, bunifuImageButtonKontaktLine, bunifuImageButtonKontaktLocation, lbKontaktLocation, btnKontaktRoutenlaner);
           }));
        }
        #endregion

        #region Show/Hide control theo menu active
        // Visible SicherheitVisible
        private void SicherheitVisible()
        {
            SicherheitVisibleControl(true);
            SystemVisibleControl(false);
            KontaktVisibleControl(false);
        }

        // Visible SicherheitVisible
        private void SystemVisible()
        {
            SicherheitVisibleControl(false);
            SystemVisibleControl(true);
            KontaktVisibleControl(false);
        }

        // Visible SicherheitVisible
        private void KontaktVisible()
        {
            SicherheitVisibleControl(false);
            SystemVisibleControl(false);
            KontaktVisibleControl(true);
        }
        #endregion

        #region Function chức năng hiển thị
        private void panelBtnSicherheit_Click(object sender, EventArgs e)
        {
            LoadingProcess.StartLoading();
            this.panelBtnSicherheit.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.head01_active));
            this.panelBtnSystem.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.head02));
            this.panelBtnKontakt.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.head03));

            SicherheitVisible();
            LoadingProcess.StopLoading();
        }

        private void panelBtnSystem_Click(object sender, EventArgs e)
        {
            LoadingProcess.StartLoading();
            this.panelBtnSicherheit.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.head01));
            this.panelBtnSystem.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.head02_active));
            this.panelBtnKontakt.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.head03));

            SystemVisible();
            LoadingProcess.StopLoading();
        }

        private void panelBtnKontakt_Click(object sender, EventArgs e)
        {
            LoadingProcess.StartLoading();
            this.panelBtnSicherheit.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.head01));
            this.panelBtnSystem.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.head02));
            this.panelBtnKontakt.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.head03_active));

            KontaktVisible();
            LoadingProcess.StopLoading();
        }
        #endregion

        private void bunBtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButtonHelp_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Show gi do!");
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            togMove = 1;
            X = e.X;
            Y = e.Y;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            togMove = 0;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (togMove == 1)
                this.SetDesktopLocation(MousePosition.X - X, MousePosition.Y - Y);
        }
    }
}
