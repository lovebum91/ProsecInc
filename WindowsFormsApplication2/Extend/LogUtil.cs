using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProsecInc.Extend
{
    public class LogUtil
    {
        public static void WriteLog(string log)
        {
            var path = Application.StartupPath + "\\logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var logFile = path + "\\" + DateTime.Now.ToString("yyyy.MM.dd") + ".txt";
            if (logFile == null) return;

            var strLog = string.Format("{0}\r\n", log);
            strLog += "-----------------------------------------------\r\n";

            var file = new StreamWriter(logFile, true, Encoding.UTF8);
            file.WriteLine(strLog);
            file.Close();
        }

        public static void WriteLogExeption(string log)
        {
            var path = Application.StartupPath + "\\logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var logFile = path + "\\" + DateTime.Now.ToString("yyyy.MM.dd") + ".report.txt";
            if (logFile == null) return;

            var strLog = string.Format("{0}\r\n", log);
            strLog += "-----------------------------------------------\r\n";

            var file = new StreamWriter(logFile, true, Encoding.UTF8);
            file.WriteLine(strLog);
            file.Close();
        }
    }
}
