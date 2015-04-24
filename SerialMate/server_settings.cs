using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SerialMate
{
    public partial class server_settings : Form
    {
        public server_settings()
        {
            InitializeComponent();
            server_ip.Text = Properties.Settings.Default.server_ip;
            server_port.Text = Properties.Settings.Default.server_port;
            server_password.Text = Properties.Settings.Default.server_password;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (server_ip.Text.Length < 5 || server_port.Text.Length < 4 || server_password.Text.Length < 1)
            {
                MessageBox.Show("Make sure that every field is valid!", "SerialMate Server");
            }
            else
            {
                Properties.Settings.Default.server_ip = server_ip.Text;
                Properties.Settings.Default.server_port = server_port.Text;
                Properties.Settings.Default.server_password = server_password.Text;
                Properties.Settings.Default.Save();
                server_status.Text = "Settings successfully saved...";
                server_status.Visible = true;
                server_save.Enabled = false;
                server_ip.Enabled = false;
                server_port.Enabled = false;
                server_password.Enabled = false;
            }
        }

        private void server_settings_Load(object sender, EventArgs e)
        {

        }

        private void port_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
