using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using System.IO;

namespace ProsecInc.ControlPanel
{
    public partial class SicherheitUpdate : UserControl
    {
        private static string _url = string.Empty;
        private static string _appPath = Application.StartupPath + "\\prosecIncApp";

        private static SicherheitUpdate _instance;
        public static SicherheitUpdate Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SicherheitUpdate();
                return _instance;
            }
        }

        public static string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        public static string AppPath
        {
            get { return _appPath; }
            set { _appPath = value; }
        }

        public SicherheitUpdate()
        {
            InitializeComponent();
            // ProcessDownloadFile(Url);
        }

        WebClient webClient;               // Our WebClient that will be doing the downloading for us
        Stopwatch sw = new Stopwatch();    // The stopwatch which we will be using to calculate the download speed

        private void SicherheitUpdate_Load(object sender, EventArgs e)
        {
            ProcessDownloadFile(Url);
        }

        /// <summary>
        /// Ham xu ly download file tu tren server ve
        /// </summary>
        /// <param name="urlAddress">Duong dan file download</param>
        public void ProcessDownloadFile(string urlAddress)
        {
            var fileName = getFilename(urlAddress);
            if (!Directory.Exists(AppPath))
            {
                Directory.CreateDirectory(AppPath);
            }
            AppPath = AppPath + "\\" + fileName;
            using (webClient = new WebClient())
            {
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);

                // The variable that will be holding the url address (making sure it starts with http://)
                Uri URL = urlAddress.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ? new Uri(urlAddress) : new Uri("http://" + urlAddress);
                // Start the stopwatch which we will be using to calculate the download speed
                sw.Start();
                try
                {
                    // Start downloading the file
                    webClient.DownloadFileAsync(URL, AppPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// Lay ten file theo duong dan toi file
        /// </summary>
        /// <param name="urlAddress"></param>
        /// <returns></returns>
        private string getFilename(string urlAddress)
        {
            if (string.IsNullOrEmpty(urlAddress))
                return string.Empty;
            Uri uri = new Uri(urlAddress);
            string filename = System.IO.Path.GetFileName(uri.LocalPath);
            return filename;
        }

        /// <summary>
        /// Ham the hien % download file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // Update the progressbar percentage only when the value is not the same.
            bunifuProgressBarUpdate.Value = e.ProgressPercentage;

            // Show the percentage on our label.
            lbUpdatePercent.Text = e.ProgressPercentage.ToString() + "%";
        }

        /// <summary>
        /// Ham check khi thuc hien download xong thi run file exe len va tat luon app di
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            sw.Reset();
            if (e.Cancelled == true)
            {
                MessageBox.Show("Download has been canceled.");
            }
            else
            {
                Application.Exit();
                Process.Start(AppPath);
            }
        }
    }
}
