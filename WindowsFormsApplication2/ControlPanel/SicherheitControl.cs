using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceProcess;
using System.IO;
using System.Timers;
using ProsecInc.Properties;
using ProsecInc.Extend;
using System.Globalization;
using System.Deployment.Application;

namespace ProsecInc.ControlPanel
{
    public partial class SicherheitControl : UserControl
    {
        private System.Timers.Timer _updateScheduler;
        private StringBuilder strLog = new StringBuilder();
        private const int EXCHANGE_INTERVAL = 1000 * 60 * 1;

        private static SicherheitControl _instance;

        public static SicherheitControl Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SicherheitControl();
                return _instance;
            }
        }
        public SicherheitControl()
        {
            InitializeComponent();
            bunifuImageButtonCloseHelp.Image = Resources.closehelp;
            bunifuImageButtonHelp.Image = Resources.help;
        }

        private void SetSicherheitSecurityDisplay()
        {
            if (!panelSicherheitContainer.Controls.Contains(SicherheitSecurity.Instance))
            {
                panelSicherheitContainer.Controls.Add(SicherheitSecurity.Instance);
                SicherheitSecurity.Instance.Dock = DockStyle.Fill;
                SicherheitSecurity.Instance.BringToFront();
            }
            else
                SicherheitSecurity.Instance.BringToFront();
        }

        public void SetSicherheitUpdateDisplay(string path)
        {
            SicherheitUpdate.Url = path;
            if (!panelSicherheitContainer.Controls.Contains(SicherheitUpdate.Instance))
            {
                panelSicherheitContainer.Controls.Add(SicherheitUpdate.Instance);
                SicherheitUpdate.Instance.Dock = DockStyle.Fill;
                SicherheitUpdate.Instance.BringToFront();
                SicherheitSecurity.Instance.SendToBack();
            }
            else
                SicherheitUpdate.Instance.BringToFront();
            bunifuImageButtonHelp.Visible = false;
            bunifuImageButtonCloseHelp.Visible = false;
        }

        private void bunifuImageButtonHelp_Click_1(object sender, EventArgs e)
        {
            // SetSicherheitUpdateDisplay("http://h2618679.stratoserver.net:8080/update/setup.exe");
            if (!panelSicherheitContainer.Controls.Contains(SicherheitHelp.Instance))
            {
                panelSicherheitContainer.Controls.Add(SicherheitHelp.Instance);
                SicherheitHelp.Instance.Dock = DockStyle.Fill;
                SicherheitHelp.Instance.BringToFront();
            }
            else
                SicherheitHelp.Instance.BringToFront();
            bunifuImageButtonHelp.Visible = false;
            bunifuImageButtonCloseHelp.Visible = true;
        }

        private void bunifuImageButtonCloseHelp_Click(object sender, EventArgs e)
        {
            SetSicherheitSecurityDisplay();
            bunifuImageButtonHelp.Visible = true;
            bunifuImageButtonCloseHelp.Visible = false;
        }

        // Ham load đầu tiên
        private void SicherheitControl_Load(object sender, EventArgs e)
        {
            ShowFormWithNewVersion(true);
            //an hien button voi kich ban tuong ung.
            bunifuImageButtonHelp.Visible = true;
            bunifuImageButtonCloseHelp.Visible = false;
        }

        /// <summary>
        /// Hàm hiển thị form dữ liệu tương ứng với trường hợp có version mới hay không có version mới
        /// </summary>
        private void ShowFormWithNewVersion(bool isScheduleCheckforUpdate)
        {
            // Đầu tiên thưc hiện check bật app nếu có version mới thì thực hiện chạy phần upload
            // Ngược lại sẽ chay phần check port
            var vServer = VersionUtil.GetVerionsFromServer();
            var checkVersion = VersionUtil.CheckNewVersion(vServer.version);
            if (checkVersion)
            {
                DialogResult dr = MessageBox.Show("An update is available. Would you like to update the application now?", "Update Available", MessageBoxButtons.OKCancel);
                if (DialogResult.OK == dr)
                {
                    //UpdateCheckInfo info = null;
                    //ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
                    //try
                    //{
                    //    info = ad.CheckForDetailedUpdate();
                    //}
                    //catch (DeploymentDownloadException dde)
                    //{
                    //    if (!isScheduleCheckforUpdate)
                    //    {
                    //        MessageBox.Show("The new version of the application cannot be downloaded at this time. \n\nPlease check your network connection, or try again later. Error: " + dde.Message);
                    //    }
                    //    return;
                    //}
                    //catch (InvalidDeploymentException ide)
                    //{
                    //    if (!isScheduleCheckforUpdate)
                    //    {
                    //        MessageBox.Show("Cannot check for a new version of the application. The ClickOnce deployment is corrupt. Please redeploy the application and try again. Error: " + ide.Message);
                    //    }
                    //    return;
                    //}
                    //catch (InvalidOperationException ioe)
                    //{
                    //    if (!isScheduleCheckforUpdate)
                    //    {
                    //        MessageBox.Show("This application cannot be updated. It is likely not a ClickOnce application. Error: " + ioe.Message);
                    //    }
                    //    return;
                    //}
                    //if (info.UpdateAvailable)
                    //{
                        strLog.AppendLine(string.Format("{0} - Update.....\r\n", DateTime.Now.ToString(CultureInfo.InvariantCulture)));
                        SetSicherheitUpdateDisplay(vServer.file_path);
                    // }
                }
                else
                    SetSicherheitSecurityDisplay();
            }
            else
                SetSicherheitSecurityDisplay();
        }

        private void timerCheckVersion_Tick(object sender, EventArgs e)
        {
            ShowFormWithNewVersion(true);
        }
    }
}
