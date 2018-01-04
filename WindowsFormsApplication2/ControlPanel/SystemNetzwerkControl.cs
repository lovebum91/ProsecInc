using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NativeWifi;
using System.Net.NetworkInformation;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using ProsecInc.Extend;
using ProsecInc.Properties;

namespace ProsecInc.ControlPanel
{
    public partial class SystemNetzwerkControl : UserControl
    {
        public InfoDevice infoDevice = new InfoDevice();
        private static SystemNetzwerkControl _instance;
        public static SystemNetzwerkControl Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SystemNetzwerkControl();
                return _instance;
            }
        }
        public SystemNetzwerkControl()
        {
            InitializeComponent();
            bunifuImageButton4.Image = Resources.linesystem;
            bunifuImageButtonBluetooth.Image = Resources.bluetooth1;
            bunifuImageButtonEthernet.Image = Resources.ethernet1;
            bunifuImageButtonWifi.Image = Resources.wifi1;
        }

        #region Lay thong tin Wifi, Ethernet, Bluetooth
        public void GetWifiName()
        {
            string wifiName = infoDevice.GetWifiName();
            if (!string.IsNullOrEmpty(wifiName))
            {
                this.bunifuImageButtonWifi.Image = ((System.Drawing.Image)(Properties.Resources.wifi_active));
                lbInfoWifi.Text = infoDevice.GetWifiName();
            }
            else
            {
                this.bunifuImageButtonWifi.Image = ((System.Drawing.Image)(Properties.Resources.wifi1));
                lbInfoWifi.Text = string.Empty;
            }

        }

        public void GetEthernetName()
        {
            string ethernetName = infoDevice.GetEthernetName();
            if (!string.IsNullOrEmpty(ethernetName))
            {
                this.bunifuImageButtonEthernet.Image = ((System.Drawing.Image)(Properties.Resources.ethernet_active));
                lbInfoEthernet.Text = ethernetName;
            }
            else
            {
                this.bunifuImageButtonEthernet.Image = ((System.Drawing.Image)(Properties.Resources.ethernet1));
                lbInfoEthernet.Text = string.Empty;
            }
        }

        public void GetBluetoothName()
        {
            string bluetoothtName = infoDevice.GetBluetoothName();
            if (!string.IsNullOrEmpty(bluetoothtName))
            {
                this.bunifuImageButtonBluetooth.Image = ((System.Drawing.Image)(Properties.Resources.bluetooth_active));
                lbInfoBlueTooth.Text = bluetoothtName;
            }
            else
            {
                this.bunifuImageButtonBluetooth.Image = ((System.Drawing.Image)(Properties.Resources.bluetooth1));
                lbInfoBlueTooth.Text = string.Empty;
            }
        }
        #endregion

        private void SystemNetzwerkControl_Load(object sender, EventArgs e)
        {
            GetWifiName();
            GetEthernetName();
            GetBluetoothName();
            lbInfoWLAN.Text = infoDevice.GetLocalIPAddress();
            lbInfoEXTERN.Text = infoDevice.GetExternalIp();
            lbInfoMAC.Text = infoDevice.GetMACAddress();
        }
    }
}
