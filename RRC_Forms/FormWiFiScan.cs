using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NativeWifi;

namespace RRC_Forms
{
    public partial class FormWiFiScan : System.Windows.Forms.Form
    {
        public FormWiFiScan()
        {
            InitializeComponent();
        }

        public bool IsConnected { set; get; }
        public string ConnectedIP = Properties.Settings.Default.ConnectedIP;

        public int ConnectedPort = Properties.Settings.Default.ConnectedPort;

        WlanClient client = new WlanClient();

        private void Btn_Close(object sender, EventArgs e)
        {
            IsConnected = false;
            this.Close();
        }

        private void FormWiFiScan_Load(object sender, EventArgs e)
        {
            WifiScanShow();

        }

        private void WifiScanShow()
        {
            int row = 0;
            try
            {
                foreach (WlanClient.WlanInterface wlanIface in client.Interfaces)
                {
                    foreach (Wlan.WlanBssEntry network in wlanIface.GetNetworkBssList().OrderByDescending(n => n.linkQuality))
                    {
                        Label lbl = new Label() { Text = string.Format("{0}", Encoding.ASCII.GetString(network.dot11Ssid.SSID, 0, (int)network.dot11Ssid.SSIDLength)), Anchor = AnchorStyles.Left, AutoSize = true };
                        lbl.MouseEnter += (ss, ee) =>
                        {
                            Cursor = Cursors.Hand;
                            Label lab = (Label)ss;
                            lab.Font = new Font(lab.Font.Name, lab.Font.SizeInPoints, FontStyle.Bold);

                        };
                        lbl.MouseLeave += (ss, ee) =>
                        {
                            Cursor = Cursors.Arrow;
                            Label lab = (Label)ss;
                            lab.Font = new Font(lab.Font.Name, lab.Font.SizeInPoints, FontStyle.Regular);
                        };
                        lbl.Click += (ss, ee) =>
                        {
                            Label lab = (Label)ss;
                            ConnectToWiFi(wlanIface, lab.Text);
                            IsConnected = true;
                            this.Close();
                        };
                       
                        PictureBox wifiIcon = new PictureBox();
                        if (network.linkQuality >= 85)
                            wifiIcon.ImageLocation = "./Img/wifi_signal4.png";
                        else if (network.linkQuality >= 70)
                            wifiIcon.ImageLocation = "./Img/wifi_signal3.png";
                        else if (network.linkQuality >= 40)
                            wifiIcon.ImageLocation = "./Img/wifi_signal2.png";
                        else
                            wifiIcon.ImageLocation = "./Img/wifi_signal1.png";
                        wifiIcon.SizeMode = PictureBoxSizeMode.AutoSize;

                        tabPanel.Controls.Add(wifiIcon, 0, row);
                        tabPanel.Controls.Add(lbl, 1, row);
                        row++;
                        tabPanel.RowCount = row + 1;
                        tabPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ConnectToWiFi(WlanClient.WlanInterface wlanIface, string profileName)
        {
            try
            {
                wlanIface.Connect(Wlan.WlanConnectionMode.Profile, Wlan.Dot11BssType.Any, profileName);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
