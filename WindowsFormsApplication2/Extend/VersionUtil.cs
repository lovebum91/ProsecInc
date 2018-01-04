using Newtonsoft.Json;
using ProsecInc.Classes;
using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace ProsecInc.Extend
{
    public class VersionUtil
    {
        /// <summary>
        /// QuangNHD: Get version, path
        /// </summary>
        public static VersionApp GetVerionsFromServer()
        {
            var client = new HttpClient();
            var version = new VersionApp();
            try
            {
                // {"file_path":"http://h2618679.stratoserver.net:8080/update/setup.exe","version":"2.6"}
                var response = client.GetAsync("http://h2618679.stratoserver.net:8080/api/apps/version").Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    version = JsonConvert.DeserializeObject<VersionApp>(result);
                }
                return version;
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        /// <summary>
        /// QuangNHD: Get version in app current
        /// </summary>
        public static string GetVersionApp()
        {
            string strVersion = string.Empty;
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                strVersion = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
            else
            {
                strVersion = Environment.Version.ToString();
            }
            return strVersion;
        }

        /// <summary>
        /// Neu check 2 version khac nhau thi tra ve true vi da co ban moi nguoc lai tra ve false
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public static bool CheckNewVersion(string version)
        {
            if (version == GetVersionApp())
                return false;
            else
                return true;
        }
    }
}
