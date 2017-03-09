using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RRC_Forms
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        private void btn_onOff_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button.BackColor == Color.Lime)
            {
                button.Text = "Odłacz";
                button.BackColor = Color.OrangeRed;
            }
            else
            {
                button.Text = "Połącz";
                button.BackColor = Color.Lime;
            }
            lb_log.Focus();
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 37:
                    leftAction();
                break;
                case 38:
                    upAction();
                    break;
                case 39:
                    rightAction();
                    break;
                case 40:
                    downAction();
                    break;
            }

        }
        private void btn_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            switch (btn.Name)
            {
                case "btn_left":
                    leftAction();
                    break;
                case "btn_up":
                    upAction();
                    break;
                case "btn_right":
                    rightAction();
                    break;
                case "btn_down":
                    downAction();
                    break;
            }
            lb_log.Focus();
        }

        private void btn_Key(object sender, EventArgs e)
        {
            lb_log.Focus();
        }

        private void leftAction()
        {
            tb_log.Text = "left";
        }
        private void upAction()
        {
            tb_log.Text = "up";
        }
        private void rightAction()
        {
            tb_log.Text = "right";
        }
        private void downAction()
        {
            tb_log.Text = "down";
        }
    }
}
