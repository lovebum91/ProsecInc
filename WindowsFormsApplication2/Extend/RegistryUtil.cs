using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace ProsecInc.Extend
{
    public class RegistryUtil
    {
        public const string REGISTRY_PATH_CONFIG = "Software\\Prosec Inc\\Configuration";
        public const string REGISTRY_PATH_STARTUP = "Software\\Microsoft\\Windows\\CurrentVersion\\Run";

        public const string KEY_CONNECT_STATUS = "ConnectStatus";
        public const string KEY_LOG_TIME = "LogTime";
        public const string KEY_LOG_SEND = "LogSend";
        public const string KEY_DATE_LOG_SEND = "DateLogSend";
        public const string KEY_SERVER_URL = "ServerUrl";
        public const string KEY_TIME_SCHEDULER = "TimeScheduler";

        public static void SetCongifValueToRegistry(RegistryType type, string value)
        {
            RegistryKey key;

            if (!CheckRegistryKeyInCurrentUser(REGISTRY_PATH_CONFIG))
            {
                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGISTRY_PATH_CONFIG, RegistryKeyPermissionCheck.ReadWriteSubTree);
            }
            else
            {
                key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(REGISTRY_PATH_CONFIG, RegistryKeyPermissionCheck.ReadWriteSubTree);
            }

            if (key != null)
            {
                key.SetValue(GetKeyName(type), value);
            }
            else
            {
                key.SetValue(GetKeyName(type), string.Empty);
            }
        }

        /// <summary>
        /// Lấy các giá trị cấu hình lưu trong Registry
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetConfigValueFromRegistry(RegistryType type)
        {
            var keyName = GetKeyName(type);
            if (!CheckRegistryKeyInCurrentUser(REGISTRY_PATH_CONFIG))
            {
                return null;
            }
            var key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(REGISTRY_PATH_CONFIG, RegistryKeyPermissionCheck.ReadWriteSubTree);
            var result = key != null ? key.GetValue(keyName) : null;

            if (result != null)
            {
                return result.ToString();
            }
            return string.Empty;
        }

        /// <summary>
        /// Lấy giá trị Key theo keyPath và keyName
        /// </summary>
        /// <param name="keyPath"></param>
        /// <param name="keyName"></param>
        /// <returns></returns>
        private object GetKeyValue(string keyPath, string keyName)
        {
            if (!CheckRegistryKeyInCurrentUser(keyPath))
            {
                return null;
            }
            var key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(keyPath, RegistryKeyPermissionCheck.ReadWriteSubTree);
            return key != null ? key.GetValue(keyName) : null;
        }

        private static bool CheckRegistryKeyInCurrentUser(string registryPath)
        {
            try
            {
                var tmpKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(registryPath, false);
                return tmpKey != null ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static string GetKeyName(RegistryType type)
        {
            switch (type)
            {
                case RegistryType.ConnectStatus:
                    return KEY_CONNECT_STATUS;
                case RegistryType.LogTime:
                    return KEY_LOG_TIME;
                case RegistryType.LogSend:
                    return KEY_LOG_SEND;
                case RegistryType.DateLogSend:
                    return KEY_DATE_LOG_SEND;
                case RegistryType.ServerUrl:
                    return KEY_SERVER_URL;
                case RegistryType.TimeScheduler:
                    return KEY_TIME_SCHEDULER;
                default:
                    return "";
            }
        }

    }

    public enum RegistryType
    {
        ConnectStatus,
        LogTime,
        LogSend,
        DateLogSend,
        ServerUrl,
        TimeScheduler
    }
}
