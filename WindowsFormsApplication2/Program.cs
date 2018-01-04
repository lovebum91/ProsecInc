using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using ProsecInc.Extend;

namespace ProsecInc
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmProSec());
            var asm = Assembly.GetExecutingAssembly();
            var guid = asm.GetType().GUID.ToString();

            using (var mutex = new Mutex(false, "Global\\" + guid))
            {
                if (mutex.WaitOne(0, false))
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    // Show the system tray icon.					
                    using (ProSecIcon pi = new ProSecIcon())
                    {
                        pi.Display();

                        // Make sure the application runs!
                        Application.Run(new frmProSec());
                    }
                }
                else
                {
                    MessageBox.Show("This tool is running");
                    return;
                }
            }
        }
    }
}
