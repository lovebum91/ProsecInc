using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ProsecInc.Extend
{
    public class LoadingProcess
    {
        static Thread process;
        static Form frm;
        static void Show()
        {
            frmLoading frm = new frmLoading();
            frm.ShowDialog();
        }
        public static void StartLoading()
        {
            process = new Thread(Show);
            process.Start();
        }
        public static void StopLoading()
        {
            try
            {
                process.Abort();
                frm = null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
