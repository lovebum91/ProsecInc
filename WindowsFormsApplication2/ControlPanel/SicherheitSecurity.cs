using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;
using System.Windows.Forms;
using System.ServiceProcess;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using ProsecInc.Properties;
using System.Net.Sockets;
using Newtonsoft.Json;
using ProsecInc.Classes;
using Quobject.SocketIoClientDotNet.Client;
using Microsoft.Win32;
using ProsecInc.Extend;
using System.Deployment.Application;
using Timer = System.Timers.Timer;
using System.Timers;
using System.Diagnostics;

namespace ProsecInc.ControlPanel
{
    public partial class SicherheitSecurity : UserControl
    {
        public InfoDevice infoDevice = new InfoDevice();
        private const int EXCHANGE_INTERVAL = 1000 * 60 * 1;
        private Timer _exchangeScheduler;
        private Timer _updateScheduler;
        private bool _isLockedWhileExchangingFlag;
        private StringBuilder strLog = new StringBuilder();
        private string serverurl = "";

        private static SicherheitSecurity _instance;
        public static SicherheitSecurity Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SicherheitSecurity();
                return _instance;
            }
        }

        public SicherheitSecurity()
        {
            InitializeComponent();
        }

        private void bunifuImageButtonHelp_Click(object sender, EventArgs e)
        {

        }

        #region Check Firewall, WindownDefender
        private bool CheckFireWall()
        {
            Type FWManagerType = Type.GetTypeFromProgID("HNetCfg.FwMgr");
            dynamic FWManager = Activator.CreateInstance(FWManagerType);
            return FWManager.LocalPolicy.CurrentProfile.FirewallEnabled;
        }

        private bool CheckWindownDefender()
        {
            var serviceStatus = ServiceController.GetServices().FirstOrDefault(o => o.ServiceName == "WinDefend").Status;
            // Chck toàn bộ chỉ kiểm tra nếu đang chạy thì mới trả về true còn lại
            // Như Paused, Stopping, Starting thì đều trả về false hết.
            if (serviceStatus.ToString().ToUpper() == "RUNNING")
                return true;
            return false;
        }
        #endregion

        #region Connect to server
        private void InitExchangeScheduler()
        {
            _exchangeScheduler = new System.Timers.Timer(EXCHANGE_INTERVAL);
            _exchangeScheduler.Elapsed += OnExchangeElapsed;
            _exchangeScheduler.Interval = EXCHANGE_INTERVAL;
            //_exchangeScheduler.Enabled = false;
            _exchangeScheduler.Start();
        }

        private void stopExchangeScheduler()
        {
            if (_exchangeScheduler != null)
            {
                _exchangeScheduler.Enabled = false;
            }
        }

        private void startExchangeScheduler()
        {
            if (_exchangeScheduler != null)
            {
                _exchangeScheduler.Enabled = true;
            }
        }

        private void InitUpdateSchedulerAndRun()
        {
            _updateScheduler = new System.Timers.Timer(EXCHANGE_INTERVAL * 2);
            _updateScheduler.Elapsed += OnUpdateElapsed;
            _updateScheduler.Interval = EXCHANGE_INTERVAL * 2;
            _updateScheduler.Enabled = true;
        }

        private void OnUpdateElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            InstallUpdateSyncWithInfo(false, true);
        }

        private void InstallUpdateSyncWithInfo(bool isAutoInstall, bool isScheduleCheckforUpdate)
        {
            strLog.AppendLine(string.Format("{0} - Update.....\r\n", DateTime.Now.ToString(CultureInfo.InvariantCulture)));
            UpdateCheckInfo info = null;
            ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
            try
            {
                info = ad.CheckForDetailedUpdate();
            }
            catch (DeploymentDownloadException dde)
            {                
                if (!isScheduleCheckforUpdate)
                {
                    MessageBox.Show("The new version of the application cannot be downloaded at this time. \n\nPlease check your network connection, or try again later. Error: " + dde.Message);
                }
                return;
            }
            catch (InvalidDeploymentException ide)
            {
                if (!isScheduleCheckforUpdate)
                {
                    MessageBox.Show("Cannot check for a new version of the application. The ClickOnce deployment is corrupt. Please redeploy the application and try again. Error: " + ide.Message);
                }
                return;
            }
            catch (InvalidOperationException ioe)
            {
                if (!isScheduleCheckforUpdate)
                {
                    MessageBox.Show("This application cannot be updated. It is likely not a ClickOnce application. Error: " + ioe.Message);
                }
                return;
            }

            if (info.UpdateAvailable)
            {
                Boolean doUpdate = true;

                // Neu khong phai la tu dong cai dat thi hien confirm
                if (!isAutoInstall || !isScheduleCheckforUpdate)
                {
                    DialogResult dr = MessageBox.Show("An update is available. Would you like to update the application now?", "Update Available", MessageBoxButtons.OKCancel);
                    if (DialogResult.OK != dr)
                    {
                        doUpdate = false;
                    }
                }

                if (doUpdate)
                {
                    try
                    {
                        stopExchangeScheduler();

                        ad.Update();

                        if (!isScheduleCheckforUpdate)
                        {
                            MessageBox.Show("The application has been upgraded, and will now restart.");
                        }
                    }
                    catch (DeploymentDownloadException dde)
                    {
                        if (!isScheduleCheckforUpdate)
                        {
                            MessageBox.Show("Lỗi khi cài đặt phiên bản mới. \n\n Vui lòng kiểm tra lại kết nối mạng, hoặc thử lại sau. Lỗi: " + dde);
                        }
                        return;
                    }
                    finally
                    {
                        // TODO: Can xu ly qua trinh nay an toan hon. VD: Dang xu ly thi damg bao xu ly xong moi kich hoat viec restart nay.
                        Application.Restart();
                    }
                }
            }
            
        }

        private void OnExchangeElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            _exchangeScheduler.Interval = EXCHANGE_INTERVAL;
            _exchangeScheduler.Enabled = false;
            _isLockedWhileExchangingFlag = true;

            try
            {
                _exchangeScheduler.Stop();
                StartExchange();
            }
            catch (Exception ex)
            {
                //log.Info("OnExchangeElapsed->StartExchange - Exception: " + ex.Message + _keepRunningFlag);
            }
            finally
            {
                _exchangeScheduler.Interval = EXCHANGE_INTERVAL;
                _exchangeScheduler.Start();
                _exchangeScheduler.Enabled = true;
                _isLockedWhileExchangingFlag = false;
            }
        }

        private void StartExchange()
        {
            GetLogtime();
            CheckPort();
            PortLog();
        }
        public static string HKLM_GetString(string path, string key)
        {
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey(path);
                if (rk == null) return "";
                return (string)rk.GetValue(key);
            }
            catch { return ""; }
        }

        public void Connect()
        {
            try
            {
                this.listView1.Items.Clear();
                Ping ping = new Ping();
                PingReply pingReply = ping.Send("h2618679.stratoserver.net");
                if (pingReply.Status == IPStatus.Success)
                {
                    //bunifuImageButtonLogo.Image = Resources.p_logo001;
                    bunifuImageButtonKontaktPhone.Image = Resources.p_logo001;
                    bunifuImageButtonLogo.Image = Resources.suc_icon;
                    strLog.AppendLine(string.Format("{0} - Ping server success! \r\n", DateTime.Now.ToString(CultureInfo.InvariantCulture)));
                }
                else
                {
                    //bunifuImageButtonLogo.Image = Resources.p_logo002;
                    bunifuImageButtonKontaktPhone.Image = Resources.p_logo002;
                    bunifuImageButtonLogo.Image = Resources.er_icon;
                    strLog.AppendLine(string.Format("{0} - Ping server false! \r\n", DateTime.Now.ToString(CultureInfo.InvariantCulture)));
                }
                bunifuImageButton1.Image = Resources.suc_icon;
                bunifuImageButton2.Image = Resources.suc_icon;
                bunifuImageButton3.Image = Resources.suc_icon;
                var firewall = CheckFireWall();
                var windef = CheckWindownDefender();
                if (firewall)
                {
                    bibFireWall.Image = Resources.wr_icon;
                }
                else
                {
                    bibFireWall.Image = Resources.suc_icon;
                }
                if (windef)
                {
                    bibDef.Image = Resources.wr_icon;
                }
                else
                {
                    bibDef.Image = Resources.suc_icon;
                }
                if (firewall || windef)
                {
                    bunifuImageButtonKontaktPhone.Image = Resources.p_logo003;
                }
                else
                {
                    bunifuImageButtonKontaktPhone.Image = Resources.p_logo001;
                }
                //var ipaddress = GetLocalIPv4(NetworkInterfaceType.Ethernet);

                var ipaddress = infoDevice.GetLocalIPAddress();
                strLog.AppendLine(string.Format("Get Ip: {0}\r\n", ipaddress));
                var ipmac = infoDevice.GetMACAddress();
                strLog.AppendLine(string.Format("Get mac: {0}\r\n", ipmac.ToString()));

                var osname = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName");
                var productName = Environment.UserName;// HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "RegisteredOwner");

                var opt = new IO.Options();
                var query = String.Format("clientIp={0}&name={1}&mac={2}&os={3}&systemTime={4}&clientId={5}&description={6}&socket={7}", ipaddress, productName, ipmac, osname, DateTime.Now.ToString(), "", productName, "");
                opt.QueryString = query;
                opt.ForceNew = true;
                opt.Port = 8080;
                opt.Hostname = "h2618679.stratoserver.net";
                opt.Timeout = 300000;
                strLog.AppendLine(string.Format("Connect server:\r\n"));
                var socket = IO.Socket("http://h2618679.stratoserver.net:8080", opt);
                RegistryUtil.SetCongifValueToRegistry(RegistryType.ConnectStatus, "true");
                //var socket = IO.Socket("http://h2618679.stratoserver.net:8080");
                // Upon a connection event, update our status
                //socket.On(Socket.EVENT_CONNECT, () =>
                //{
                //    //UpdateStatus("Connected");
                //});
                // Upon temperature data, update our temperature status
                //socket.On("temperature", (data) =>
                //{
                //    var temperature = new { temperature = "" };
                //    var tempValue = JsonConvert.DeserializeAnonymousType((string)data, temperature);
                //    UpdateTemp((string)tempValue.temperature);
                //});

            }
            catch (System.Exception exall)
            {
                RegistryUtil.SetCongifValueToRegistry(RegistryType.ConnectStatus, "false");
                strLog.AppendLine(string.Format("{0} - Connect error: {1}\r\n", DateTime.Now.ToString(CultureInfo.InvariantCulture), exall.Message));
                LogUtil.WriteLogExeption(strLog.ToString());
            }
        }

        private void GetLogtime()
        {
            var client = new HttpClient();
            var logtime = new List<LogTime>();
            try
            {
                var response = client.GetAsync("http://h2618679.stratoserver.net:8080/api/logs/logtime").Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    var datajson = result.Substring(1, result.Length - 2).Replace(@"\", "");
                    logtime = JsonConvert.DeserializeObject<List<LogTime>>(datajson);
                    var logtimearr = logtime.ToArray();
                    var logtimeval = logtimearr[0].log_time;
                    RegistryUtil.SetCongifValueToRegistry(RegistryType.LogTime, logtimeval);
                }
            }
            catch (Exception ex)
            {

            }

        }

        private void CheckPort()
        {
            HidePort();
            var ports = new List<Address>();
            var ip = infoDevice.GetLocalIPAddress();
            bunifuImageButton1.Image = Resources.suc_icon;
            bunifuImageButton2.Image = Resources.suc_icon;
            bunifuImageButton3.Image = Resources.suc_icon;
            //Get ports
            try
            {
                using (var client = new WebClient())
                {
                    var result = "";
                    client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    var data = "clientIp=" + ip;
                    result = client.UploadString(serverurl + "/api/getPortCheck", "POST", data);
                    strLog.AppendLine(string.Format("{0} - Get port for Ip: {1}: {2}\r\n", DateTime.Now.ToString(CultureInfo.InvariantCulture), ip, result));

                    if (!string.IsNullOrEmpty(result))
                    {
                        var datajson = result.Substring(1, result.Length - 2).Replace(@"\", "");
                        ports = JsonConvert.DeserializeObject<List<Address>>(datajson);
                    }
                }
            }
            catch (Exception get)
            {
                strLog.AppendLine(string.Format("{0} - Get ports error: {1}\r\n", DateTime.Now.ToString(CultureInfo.InvariantCulture), get.Message));
                LogUtil.WriteLogExeption(strLog.ToString());
            }
            try
            {
                var countfalse = 0;
                var i = 0;
                foreach (var port in ports)
                {
                    i++;
                    port.IPAddress = ip;
                    using (TcpClient tcpClient = new TcpClient())
                    {
                        try
                        {
                            tcpClient.Connect(ip, port.port_number);
                            port.Statuscheck = "1";
                            //this.imageList.Images.Add(Resources.suc_icon);
                            ShowPort(i, true, port.port_number.ToString());
                            strLog.AppendLine(string.Format("{0} - Check port: {1}: Success!\r\n", DateTime.Now.ToString(CultureInfo.InvariantCulture), port.port_number));
                        }
                        catch (Exception)
                        {
                            port.Statuscheck = "0";
                            //this.imageList.Images.Add(Resources.er_icon);
                            countfalse++;
                            ShowPort(i, false, port.port_number.ToString());
                            strLog.AppendLine(string.Format("{0} - Check port: {1}: False!\r\n", DateTime.Now.ToString(CultureInfo.InvariantCulture), port.port_number));
                        }
                    }
                }


                //this.listView1.View = View.Details;
                //this.imageList.ImageSize = new Size(32, 32);
                //this.listView1.LargeImageList = this.imageList;
                //for (int j = 0; j < this.imageList.Images.Count; j++)
                //{
                //    var portarr = ports.ToArray();
                //    ListViewItem item = new ListViewItem(portarr[j].port_number.ToString(), j);
                //    item.ForeColor = Color.White;
                //    //this.listView1.Items.Add(item);
                //    ListViewItem it = new ListViewItem();
                //    it.ImageIndex = j;
                //    it.SubItems.Add(portarr[j].port_number.ToString());
                //    this.listView1.Items.Add(item);
                //}
                var firewall = CheckFireWall();
                var windef = CheckWindownDefender();
                if (firewall)
                {
                    bibFireWall.Image = Resources.wr_icon;
                }
                else
                {
                    bibFireWall.Image = Resources.suc_icon;
                }
                if (windef)
                {
                    bibDef.Image = Resources.wr_icon;
                }
                else
                {
                    bibDef.Image = Resources.suc_icon;
                }
                if (firewall || windef)
                {
                    bunifuImageButtonKontaktPhone.Image = Resources.p_logo003;
                }
                else
                {
                    if (countfalse > 0)
                    {
                        bunifuImageButtonKontaktPhone.Image = Resources.p_logo002;
                    }
                    else
                    {
                        bunifuImageButtonKontaktPhone.Image = Resources.p_logo001;
                    }
                }
            }
            catch (Exception ex)
            {
                strLog.AppendLine(string.Format("{0} - Check port error: {1}\r\n", DateTime.Now.ToString(CultureInfo.InvariantCulture), ex.Message));
                LogUtil.WriteLogExeption(strLog.ToString());
            }

        }

        private void HidePort()
        {
            bibPort1.Visible = false;
            lblPort1.Visible = false;
            bibPort2.Visible = false;
            lblPort2.Visible = false;
            bibPort3.Visible = false;
            lblPort3.Visible = false;
            bibPort4.Visible = false;
            lblPort4.Visible = false;
            bibPort5.Visible = false;
            lblPort5.Visible = false;
            bibPort6.Visible = false;
            lblPort6.Visible = false;
            bibPort7.Visible = false;
            lblPort7.Visible = false;
            bibPort8.Visible = false;
            lblPort8.Visible = false;
            bibPort9.Visible = false;
            lblPort9.Visible = false;
            bibPort10.Visible = false;
            lblPort10.Visible = false;
            bibPort11.Visible = false;
            lblPort11.Visible = false;
            bibPort12.Visible = false;
            lblPort12.Visible = false;
            bibPort13.Visible = false;
            lblPort14.Visible = false;
        }

        private void ShowPort(int i, bool status, string portname)
        {
            var firewall = CheckFireWall();
            var windef = CheckWindownDefender();
            if (firewall || windef)
            {
                switch (i)
                {
                    case 1:
                        bibPort1.Visible = true;
                        lblPort1.Visible = true;
                        lblPort1.Text = "Port " + portname;
                        bibPort1.Image = Resources.wr_icon;
                        break;
                    case 2:
                        bibPort2.Visible = true;
                        lblPort2.Visible = true;
                        lblPort2.Text = "Port " + portname;
                        bibPort2.Image = Resources.wr_icon;
                        break;
                    case 3:
                        bibPort3.Visible = true;
                        lblPort3.Visible = true;
                        lblPort3.Text = "Port " + portname;
                        bibPort3.Image = Resources.wr_icon;
                        break;
                    case 4:
                        bibPort4.Visible = true;
                        lblPort4.Visible = true;
                        lblPort4.Text = "Port " + portname;
                        bibPort4.Image = Resources.wr_icon;
                        break;
                    case 5:
                        bibPort5.Visible = true;
                        lblPort5.Visible = true;
                        lblPort5.Text = "Port " + portname;
                        bibPort5.Image = Resources.wr_icon;
                        break;
                    case 6:
                        bibPort6.Visible = true;
                        lblPort6.Visible = true;
                        lblPort6.Text = "Port " + portname;
                        bibPort6.Image = Resources.wr_icon;
                        break;
                    case 7:
                        bibPort7.Visible = true;
                        lblPort7.Visible = true;
                        lblPort7.Text = "Port " + portname;
                        bibPort7.Image = Resources.wr_icon;
                        break;
                    case 8:
                        bibPort8.Visible = true;
                        lblPort8.Visible = true;
                        lblPort8.Text = "Port " + portname;
                        bibPort8.Image = Resources.wr_icon;
                        break;
                    case 9:
                        bibPort9.Visible = true;
                        lblPort9.Visible = true;
                        lblPort9.Text = "Port " + portname;
                        bibPort9.Image = Resources.wr_icon;
                        break;
                    case 10:
                        bibPort10.Visible = true;
                        lblPort10.Visible = true;
                        lblPort10.Text = "Port " + portname;
                        bibPort10.Image = Resources.wr_icon;
                        break;
                    case 11:
                        bibPort11.Visible = true;
                        lblPort11.Visible = true;
                        lblPort11.Text = "Port " + portname;
                        bibPort11.Image = Resources.wr_icon;
                        break;
                    case 12:
                        bibPort12.Visible = true;
                        lblPort12.Visible = true;
                        lblPort12.Text = "Port " + portname;
                        bibPort12.Image = Resources.wr_icon;
                        break;
                    case 13:
                        bibPort13.Visible = true;
                        lblPort13.Visible = true;
                        lblPort13.Text = "Port " + portname;
                        bibPort13.Image = Resources.wr_icon;
                        break;
                    case 14:
                        bibPort14.Visible = true;
                        lblPort14.Visible = true;
                        lblPort14.Text = "Port " + portname;
                        bibPort14.Image = Resources.wr_icon;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                if (status)
                {
                    switch (i)
                    {
                        case 1:
                            bibPort1.Visible = true;
                            lblPort1.Visible = true;
                            lblPort1.Text = "Port " + portname;
                            bibPort1.Image = Resources.suc_icon;
                            break;
                        case 2:
                            bibPort2.Visible = true;
                            lblPort2.Visible = true;
                            lblPort2.Text = "Port " + portname;
                            bibPort2.Image = Resources.suc_icon;
                            break;
                        case 3:
                            bibPort3.Visible = true;
                            lblPort3.Visible = true;
                            lblPort3.Text = "Port " + portname;
                            bibPort3.Image = Resources.suc_icon;
                            break;
                        case 4:
                            bibPort4.Visible = true;
                            lblPort4.Visible = true;
                            lblPort4.Text = "Port " + portname;
                            bibPort4.Image = Resources.suc_icon;
                            break;
                        case 5:
                            bibPort5.Visible = true;
                            lblPort5.Visible = true;
                            lblPort5.Text = "Port " + portname;
                            bibPort5.Image = Resources.suc_icon;
                            break;
                        case 6:
                            bibPort6.Visible = true;
                            lblPort6.Visible = true;
                            lblPort6.Text = "Port " + portname;
                            bibPort6.Image = Resources.suc_icon;
                            break;
                        case 7:
                            bibPort7.Visible = true;
                            lblPort7.Visible = true;
                            lblPort7.Text = "Port " + portname;
                            bibPort7.Image = Resources.suc_icon;
                            break;
                        case 8:
                            bibPort8.Visible = true;
                            lblPort8.Visible = true;
                            lblPort8.Text = "Port " + portname;
                            bibPort8.Image = Resources.suc_icon;
                            break;
                        case 9:
                            bibPort9.Visible = true;
                            lblPort9.Visible = true;
                            lblPort9.Text = "Port " + portname;
                            bibPort9.Image = Resources.suc_icon;
                            break;
                        case 10:
                            bibPort10.Visible = true;
                            lblPort10.Visible = true;
                            lblPort10.Text = "Port " + portname;
                            bibPort10.Image = Resources.suc_icon;
                            break;
                        case 11:
                            bibPort11.Visible = true;
                            lblPort11.Visible = true;
                            lblPort11.Text = "Port " + portname;
                            bibPort11.Image = Resources.suc_icon;
                            break;
                        case 12:
                            bibPort12.Visible = true;
                            lblPort12.Visible = true;
                            lblPort12.Text = "Port " + portname;
                            bibPort12.Image = Resources.suc_icon;
                            break;
                        case 13:
                            bibPort13.Visible = true;
                            lblPort13.Visible = true;
                            lblPort13.Text = "Port " + portname;
                            bibPort13.Image = Resources.suc_icon;
                            break;
                        case 14:
                            bibPort14.Visible = true;
                            lblPort14.Visible = true;
                            lblPort14.Text = "Port " + portname;
                            bibPort14.Image = Resources.suc_icon;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (i)
                    {
                        case 1:
                            bibPort1.Visible = true;
                            lblPort1.Visible = true;
                            lblPort1.Text = "Port " + portname;
                            bibPort1.Image = Resources.er_icon;
                            break;
                        case 2:
                            bibPort2.Visible = true;
                            lblPort2.Visible = true;
                            lblPort2.Text = "Port " + portname;
                            bibPort2.Image = Resources.er_icon;
                            break;
                        case 3:
                            bibPort3.Visible = true;
                            lblPort3.Visible = true;
                            lblPort3.Text = "Port " + portname;
                            bibPort3.Image = Resources.er_icon;
                            break;
                        case 4:
                            bibPort4.Visible = true;
                            lblPort4.Visible = true;
                            lblPort4.Text = "Port " + portname;
                            bibPort4.Image = Resources.er_icon;
                            break;
                        case 5:
                            bibPort5.Visible = true;
                            lblPort5.Visible = true;
                            lblPort5.Text = "Port " + portname;
                            bibPort5.Image = Resources.er_icon;
                            break;
                        case 6:
                            bibPort6.Visible = true;
                            lblPort6.Visible = true;
                            lblPort6.Text = "Port " + portname;
                            bibPort6.Image = Resources.er_icon;
                            break;
                        case 7:
                            bibPort7.Visible = true;
                            lblPort7.Visible = true;
                            lblPort7.Text = "Port " + portname;
                            bibPort7.Image = Resources.er_icon;
                            break;
                        case 8:
                            bibPort8.Visible = true;
                            lblPort8.Visible = true;
                            lblPort8.Text = "Port " + portname;
                            bibPort8.Image = Resources.er_icon;
                            break;
                        case 9:
                            bibPort9.Visible = true;
                            lblPort9.Visible = true;
                            lblPort9.Text = "Port " + portname;
                            bibPort9.Image = Resources.er_icon;
                            break;
                        case 10:
                            bibPort10.Visible = true;
                            lblPort10.Visible = true;
                            lblPort10.Text = "Port " + portname;
                            bibPort10.Image = Resources.er_icon;
                            break;
                        case 11:
                            bibPort11.Visible = true;
                            lblPort11.Visible = true;
                            lblPort11.Text = "Port " + portname;
                            bibPort11.Image = Resources.er_icon;
                            break;
                        case 12:
                            bibPort12.Visible = true;
                            lblPort12.Visible = true;
                            lblPort12.Text = "Port " + portname;
                            bibPort12.Image = Resources.er_icon;
                            break;
                        case 13:
                            bibPort13.Visible = true;
                            lblPort13.Visible = true;
                            lblPort13.Text = "Port " + portname;
                            bibPort13.Image = Resources.er_icon;
                            break;
                        case 14:
                            bibPort14.Visible = true;
                            lblPort14.Visible = true;
                            lblPort14.Text = "Port " + portname;
                            bibPort14.Image = Resources.er_icon;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void PortLog()
        {
            try
            {
                var ipaddress = infoDevice.GetLocalIPAddress();
                var logtime = RegistryUtil.GetConfigValueFromRegistry(RegistryType.LogTime);
                var logSend = RegistryUtil.GetConfigValueFromRegistry(RegistryType.LogSend);
                var datelogsend = RegistryUtil.GetConfigValueFromRegistry(RegistryType.DateLogSend);
                var timesend = Convert.ToDateTime(logtime);
                var timenow = DateTime.Now;

                if (timenow > timesend)
                {
                    var filename = timenow.ToString("yyyy.MM.dd");
                    if (filename != datelogsend)
                    {
                        var logPath = Application.StartupPath + "\\logs\\" + filename + ".txt";
                        if (File.Exists(logPath))
                        {
                            var postlog = Upload(serverurl + "/api/logs/upload", ipaddress, logPath);
                            if (postlog)
                            {
                                RegistryUtil.SetCongifValueToRegistry(RegistryType.DateLogSend, timenow.ToString("yyyy.MM.dd"));
                                RegistryUtil.SetCongifValueToRegistry(RegistryType.LogSend, "false");
                            }
                        }
                    }
                    else
                    {
                        if (logSend == "true")
                        {
                            var logPath = Application.StartupPath + "\\logs\\" + filename + ".txt";
                            if (File.Exists(logPath))
                            {
                                var postlog = Upload(serverurl + "/api/logs/upload", ipaddress, logPath);
                                if (postlog)
                                {
                                    RegistryUtil.SetCongifValueToRegistry(RegistryType.DateLogSend, timenow.ToString("yyyy.MM.dd"));
                                    RegistryUtil.SetCongifValueToRegistry(RegistryType.LogSend, "false");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

        }

        #endregion

        #region Post log to server
        bool Upload(string url, string clientIp, string localFilename)
        {
            Boolean isFileUploaded = false;
            try
            {
                HttpClient httpClient = new HttpClient();
                var fileStream = File.Open(localFilename, FileMode.Open);
                var fileInfo = new FileInfo(localFilename);
                MultipartFormDataContent content = new MultipartFormDataContent();
                content.Headers.Add("clientIp", clientIp);
                content.Add(new StreamContent(fileStream), "\"file\"", string.Format("\"{0}\"", fileInfo.Name)
                        );
                strLog.AppendLine(string.Format("{0} - Sending log client ip: {1}\r\n", DateTime.Now.ToString(CultureInfo.InvariantCulture), clientIp));
                var result = httpClient.PostAsync(url, content).Result;
                if (result.StatusCode.ToString().ToUpper() == "OK")
                {
                    isFileUploaded = true;
                }
                httpClient.Dispose();

            }
            catch (Exception ex)
            {
                //	AddMessage(ex.Message);
                isFileUploaded = false;
            }
            return isFileUploaded;
        }
        #endregion

        private void SicherheitSecurity_Load(object sender, EventArgs e)
        {
            //var version = "";
            //if (ApplicationDeployment.IsNetworkDeployed)
            //{
            //    version = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            //}
            //else
            //{
            //    version = Environment.Version.ToString();
            //}
            //lblversion.Text = "";
            //lblversion.Visible = false;
            //bibConfig.Image = Resources.config;
            //bibConfig.Visible = false;
            //serverurl = RegistryUtil.GetConfigValueFromRegistry(RegistryType.ServerUrl);
            serverurl = "http://h2618679.stratoserver.net:8080";
            SetFormTitle();
            SetKeyRegistry();

            var connectStatus = RegistryUtil.GetConfigValueFromRegistry(RegistryType.ConnectStatus);

            //Conect to server
            if (connectStatus == "false")
            {
                Connect();
            }

            CheckPort();
            //PortLog();
            InitExchangeScheduler();
            InitUpdateSchedulerAndRun();
            LogUtil.WriteLog(strLog.ToString());
        }

        private void SetFormTitle()
        {
            this.Text = "Prosec Inc " + VersionUtil.GetVersionApp();
        }

        private void SetKeyRegistry()
        {
            RegistryUtil.SetCongifValueToRegistry(RegistryType.ConnectStatus, "false");
            RegistryUtil.SetCongifValueToRegistry(RegistryType.LogSend, "true");
        }
    }
}
