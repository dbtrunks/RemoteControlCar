using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using NativeWifi;

namespace RRC_Forms
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        private Socket _server;
        private IPEndPoint _endpoint;
        private string ip;
        private int port;

        private void Btn_onOff_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button.BackColor == Color.Lime)
            {

                using (var formWifiScan = new FormWiFiScan())
                {
                    formWifiScan.ShowDialog();
                    if (formWifiScan.IsConnected)
                    {
                        ip = formWifiScan.ConnectedIP;
                        port = formWifiScan.ConnectedPort;
                        button.Text = "Odłacz";
                        button.BackColor = Color.OrangeRed;
                    }
                }
                _server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                IPAddress broadcast = IPAddress.Parse(ip);
                _endpoint = new IPEndPoint(broadcast, port);
            }
            else
            {
                button.Text = "Połącz";
                button.BackColor = Color.Lime;
            }
            lb_log.Focus();
        }




        private bool pressUp, pressDown, pressLeft, pressRight;
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    pressLeft = true;
                    break;
                case Keys.Up:
                    pressUp = true;
                    break;
                case Keys.Right:
                    pressRight = true;
                    break;
                case Keys.Down:
                    pressDown = true;
                    pressUp = false;
                    break;
            }

            if (pressUp)
                UpAction();
            if (pressLeft)
                LeftAction();
            if (pressRight)
                RightAction();
            if (pressDown)
                DownAction();

        }

        private void Form_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    pressLeft = false;
                    break;
                case Keys.Up:
                    pressUp = false;
                    break;
                case Keys.Right:
                    pressRight = false;
                    break;
                case Keys.Down:
                    pressDown = false;
                    break;
            }

        }
        private void Btn_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            switch (btn.Name)
            {
                case "btn_left":
                    LeftAction();
                    break;
                case "btn_up":
                    UpAction();
                    break;
                case "btn_right":
                    RightAction();
                    break;
                case "btn_down":
                    DownAction();
                    break;
            }
            lb_log.Focus();
        }

        private void Btn_Key(object sender, EventArgs e)
        {
            lb_log.Focus();

        }

        private void LeftAction()
        {
            Log("left");
            SendMasage("L");
        }
        private void UpAction()
        {
            Log("up");
            SendMasage("U");
        }
        private void RightAction()
        {
            Log("right");
            SendMasage("R");
        }

        private void tb_log_TextChanged(object sender, EventArgs e)
        {
            tb_log.SelectionStart = tb_log.Text.Length;
            tb_log.ScrollToCaret();
        }

        private void DownAction()
        {
            Log("down");
            SendMasage("D");
        }

        private void SendMasage(string mes)
        {
            byte[] sendbuf = Encoding.ASCII.GetBytes(mes);
            if (_server != null)
                _server.SendTo(sendbuf, _endpoint);
        }

        private void Log(string text)
        {
            tb_log.Text += text;
        }

    }
}
