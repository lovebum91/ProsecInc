using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace ProsecInc.ControlPanel
{
    public partial class SystemProcess : UserControl
    {
        private static SystemProcess _instance;
        public static SystemProcess Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SystemProcess();
                return _instance;
            }
        }
        public SystemProcess()
        {
            InitializeComponent();
        }

        private void SystemProcess_Load(object sender, EventArgs e)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            //double total = 0;
            //double totalFree = 0;
            //foreach (DriveInfo drive in drives)
            //{
            //    total += drive.TotalSize;
            //    totalFree += drive.TotalFreeSpace;
            //}
            //int percent = (int)(100 * ((total - totalFree) / total));
            //bunifuCircleProgressbarHHD.Value = percent;
        }

        private void timerPerformance_Tick(object sender, EventArgs e)
        {
            float cpu = performanceCounterCPU.NextValue();
            float ram = performanceCounterRAM.NextValue();
            int disk = (int)performanceCounterDisk.NextValue();
            if (disk > 100)
                disk = 100;

            bunifuCircleProgressbarCPU.Value = (int)cpu;
            bunifuCircleProgressbarRAM.Value = (int)ram;
            bunifuCircleProgressbarHHD.Value = disk;
        }
    }
}
