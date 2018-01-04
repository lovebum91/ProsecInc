using NativeWifi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace ProsecInc.Extend
{
    public class InfoDevice
    {

        #region Lay thong tin Wifi, Ethernet, Bluetooth
        public string GetWifiName()
        {
            string wifiName = string.Empty;
            try
            {
                WlanClient wlan = new WlanClient();
                WlanClient.WlanInterface wlanIface = wlan.Interfaces.FirstOrDefault();
                if (wlanIface.InterfaceState.ToString() == "Connected")
                {
                    wifiName = wlanIface.CurrentConnection.profileName;
                }
                return wifiName;
            }
            catch (Exception)
            {
                wifiName = string.Empty;
            }
            return wifiName;

        }

        public string GetEthernetName()
        {
            string ethernetName = string.Empty;
            try
            {
                var interfaces = NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault();
                if (interfaces.OperationalStatus.ToString() == "Up" && interfaces.NetworkInterfaceType.ToString() == "Ethernet")
                {
                    ethernetName = interfaces.Name;
                }
                return ethernetName;
            }
            catch (Exception)
            {
                ethernetName = string.Empty;
            }
            return ethernetName;
        }

        public string GetBluetoothName()
        {
            string bluetoothName = string.Empty;
            try
            {
                var interfaces = NetworkInterface.GetAllNetworkInterfaces()[1];
                if (interfaces.OperationalStatus.ToString() == "Up" && interfaces.NetworkInterfaceType.ToString() == "Ethernet")
                {
                    bluetoothName = interfaces.Name;
                }
                return bluetoothName;
            }
            catch (Exception)
            {
                bluetoothName = string.Empty;
            }
            return bluetoothName;
        }
        #endregion

        #region Get IP, ETERN, MAC
        public string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return string.Empty;
        }

        //public string GetMACAddress()
        //{
        //    string mac = string.Empty;
        //    foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
        //    {

        //        if (nic.OperationalStatus == OperationalStatus.Up && (!nic.Description.Contains("Virtual") && !nic.Description.Contains("Pseudo")))
        //        {
        //            if (nic.GetPhysicalAddress().ToString() != "")
        //            {
        //                mac = nic.GetPhysicalAddress().ToString();
        //            }
        //        }
        //    }
        //    return mac;
        //}

        public string GetMACAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            } return sMacAddress;
        }

        public string GetExternalIp()
        {
            try
            {
                string externalIP;
                externalIP = (new WebClient()).DownloadString("http://checkip.dyndns.org/");
                externalIP = (new Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}"))
                             .Matches(externalIP)[0].ToString();
                return externalIP;
            }
            catch { return null; }
        }
        #endregion
    }
}
