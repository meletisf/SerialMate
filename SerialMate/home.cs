using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Drawing;
/*
 * No comments? 
 * Code hard to write must be hard to read!
 */
namespace SerialMate
{
    public partial class home : Form
    {
        Boolean off = false;
        Boolean auto_refresh = false;
        Boolean log_time = false;
        Boolean hide_advanced = false;
        Boolean log_to_file = false;
        public string title = "SerialMate";
        public string ReadTo = "\n";
        public string read_method = "readto";
        public string dataIn;
        public string file_path;
        public string file_name;
        version version = new version();
        netCheck netCheck = new netCheck();
        Boolean HasInternet = netCheck.CheckForInternet();
        public StreamWriter writer;
        Boolean hasLoadedLogFile = false;
        
        /// <Version>
        public string AppVersion = "1.0.0";
        /// <Version>

        int stop_bits = 8;
        int font_size;
        Boolean io_x = false;
        SerialPort serial = null;
        public home()
        {    
            InitializeComponent();
            console.ReadOnly = true;
            ports_list.ReadOnly = true;
            start_loging.Enabled = false;
            label2.Visible = false;
            comboBox2.SelectedIndex = 6;
            console.Clear();
            console.AppendText("============================\n");
            console.AppendText("SerialMate is initialized!\n");
            console.AppendText("Thanks for using this.program \n");
            console.AppendText("============================\n");
            timer2.Start();
            timer2.Interval = 5000;
            getPorts();

            font_size = Properties.Settings.Default.font_size;
            console.Font = new Font("", font_size);

            Color font_color = Properties.Settings.Default.font_color;
            console.ForeColor = font_color;

            Color bg_color = Properties.Settings.Default.bg_color;
            console.BackColor = bg_color;


            if (HasInternet && version.RequestVersion() != null) 
            {
                string[] v_in = version.RequestVersion();
                if (AppVersion != v_in[0]) 
                {
                    console.AppendText(cur_time() + "An update is available (" + AppVersion + "==>" + v_in[0] + ")\n");
                    console.AppendText(cur_time() + "Release: " + v_in[1] + " Desc: " + v_in[2] + "\n");
                }
            }
            else
            {
                console.AppendText(cur_time() + "[Update check] Failed to contact master server... \n");
            }

        }

        public void kill()
        {
            System.Windows.Forms.Application.Exit();
        }

        public string cur_time()
        {
            string time = "[" + DateTime.Now.ToString("hh:mm:ss tt") + "] ";
            return time;
        }

        public void Serial (Boolean s_state)
        {
            try
            {

                if (s_state)
                {
                    serial = new SerialPort(this.comboBox1.Text);
                    int baud = Int32.Parse(comboBox2.Text);

                    serial.BaudRate = baud;
                    serial.Parity = Parity.None;
                    serial.StopBits = StopBits.One;
                    serial.DataBits = stop_bits;
                    serial.Handshake = Handshake.None;

                    serial.DataReceived += new SerialDataReceivedEventHandler(SerialDataReceivedHandler);

                    try {
                        serial.Open();
                    } catch {
                        serial.Close();
                        io_x = true;                        
                    }
                }
                else
                {
                    serial.Close();
                }
            }
            catch (Exception e)
            {
                console.AppendText(cur_time() + e + "\n");
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                start_loging.Text = "Start Logging";
                Text = title + " [Stoped] ";
                io_x = true;
                Serial(false);
            }
        }

        public void SerialDataReceivedHandler(object sender, SerialDataReceivedEventArgs e) 
        {
            SerialPort sp = (SerialPort)sender;
            try
            {
                switch (read_method) 
                {
                    case "readto":
                        dataIn = sp.ReadTo(ReadTo);
                    break;

                    case "read_existing":
                        dataIn = sp.ReadExisting();
                    break;
                    
                    default:
                        dataIn = sp.ReadTo(ReadTo);
                    break;
                }
                    
                
                if (consolelog_checkbox.Checked)
                {
                    if (log_time)
                    {
                        this.console.AppendText(cur_time() + dataIn + "\n");
                        if (log_to_file) 
                        {
                            string file_input_packed = cur_time() + dataIn;
                            write_to_file(file_input_packed);
                        }
                    }
                    else
                    {
                        this.console.AppendText(dataIn + "\n");
                        if (log_to_file)
                        {
                            write_to_file(dataIn.ToString());
                        }
                    }
                }
            }
            catch (Exception rndex)
            {
                console.AppendText(cur_time() + rndex + "\n");
            }
        }

        public void getPorts() {
            ports_list.Clear();
            string[] ports = SerialPort.GetPortNames();
            ports_list.Clear();
            foreach (string port in ports)
            {
                ports_list.AppendText(port + "\n");
                ports_list.ForeColor = Color.Green;
            }
            this.console.AppendText(cur_time() + "Refreshing port list.... \n");
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //  If the program is activated
            if (off == false)
            {
                home.CheckForIllegalCrossThreadCalls = false;
                start_loging.Text = "Stop Logging";
                Text = title + " [Logging (" + comboBox1.Text + ")] ";
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                console.Focus();
                Serial(true);
                if (io_x) 
                {
                    notifyIcon1.ShowBalloonTip(2000, "SerialMate", "Failed to load data from " + comboBox1.Text, ToolTipIcon.Error);
                    console.AppendText(cur_time() + "Could not connect to serial port " + this.comboBox1.Text + "\n");
                }
                else
                {
                    notifyIcon1.ShowBalloonTip(2000, "SerialMate", "SerialMate in now logging data (" + comboBox1.Text + ")", ToolTipIcon.Info);
                    console.AppendText(cur_time() + "SerialMate in now logging data from " + comboBox1.Text + " (" + comboBox2.Text + "). \n");
                    
                }
                off = true;
                
            }
            //  If the program is deactivated
            else
            {   
                Serial(false);
                start_loging.Text = "Start Logging";
                Text = title + " [Stopped] ";
                notifyIcon1.ShowBalloonTip(2000, "SerialMate", "SerialMate has stopped.", ToolTipIcon.Warning);
                console.AppendText(cur_time() + "SerialMate has stopped. \n");
                console.Focus();
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                off = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (comboBox1.Text.Length < 3)
            {
                start_loging.Enabled = false;
            }
            else
            {
                start_loging.Enabled = true;
            }

            if (ReadTo.Length < 1)
            {
                ReadTo = "\n";
            }

        }

        public void write_to_file(string file_input)
        {

            try
            {
                if (!hasLoadedLogFile) {
                    string path = @"sm_log.txt";
                    writer = new StreamWriter(path, true);
                    hasLoadedLogFile = true;
                }
                writer.WriteLine(file_input);
                writer.Write(file_input);
                console.AppendText(cur_time() + "Trying to write: " + file_input + "\n");
            }
            catch (Exception write_x)
            {
                console.AppendText(cur_time() + write_x + "\n");
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
            if (savetofile_checkbox.Checked) {
                log_to_file = true;
                label2.Visible = true;
                console.AppendText(cur_time() + "Logging input to sm_log.txt \n");
            }
            else
            {
                log_to_file = false;
            }
             
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kill();  
        }

        private void killToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kill();
        }

        private void clearConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            console.Clear();
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getPorts();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void autoRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void onToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (!auto_refresh) 
            {
                auto_refresh = true;
            }
            onToolStripMenuItem.Checked = true;
            offToolStripMenuItem.Checked = false;

            console.AppendText(cur_time() + "Auto-refresh in on! \n");
        }

        private void offToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (auto_refresh) 
            {
                auto_refresh = false;
            }
            offToolStripMenuItem.Checked = true;
            onToolStripMenuItem.Checked = false;
            
            console.AppendText(cur_time() + "Auto-refresh in off! \n");
        }

        private void logTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(logTimeToolStripMenuItem.Checked)
            {
                log_time = false;
                logTimeToolStripMenuItem.Checked = false;
                console.AppendText(cur_time() + "SerialMate has stopped logging time! \n");
            }
            else
            {
                log_time = true;
                logTimeToolStripMenuItem.Checked = true;
                console.AppendText(cur_time() + "SerialMate is now logging time! \n");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            console.Focus();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (onToolStripMenuItem.Checked)
            {
                getPorts();
            }
        }

        private void interfaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            interface_help intf_h = new interface_help();
            intf_h.Show();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {

        }

        private void serialPortsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            serial_help srl_h = new serial_help();
            srl_h.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (readtokey_checkbox.Checked)
            {
                if (readto_input.Text.Length < 1)
                {
                    ReadTo = "\n";
                }
                else
                {
                    ReadTo = readto_input.Text;
                    console.AppendText(cur_time() + "ReadTo key changed to: " + ReadTo + "\n");
                }
            }
            else
            {
                ReadTo = "\n";
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (readtokey_checkbox.Checked)
            {
                readto_input.Enabled = true;
                savereadtokey_button.Enabled = true;
            }
            else 
            {
                readto_input.Enabled = false;
                savereadtokey_button.Enabled = false;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            serial_help srl_h = new serial_help();
            srl_h.Show();
        }

        private void showAdvancedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (hide_advanced)
            {
                showAdvancedToolStripMenuItem.Checked = false;
                advanced_groupbox.Visible = false;
                hide_advanced = false;
            }
            else
            {
                showAdvancedToolStripMenuItem.Checked = true;
                advanced_groupbox.Visible = true;
                hide_advanced = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length < 1) 
            {
                stop_bits = 8;
                console.AppendText(cur_time() + "Error... \n");
                console.Focus();
            }
            else
            {
                stop_bits = Int32.Parse(textBox2.Text);
                console.AppendText(cur_time() + "Stop bits changed to " + stop_bits + "\n");
                console.Focus();
            }
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (HasInternet && version.RequestVersion() != null)
            {
                string[] v_in = version.RequestVersion();
                console.AppendText(cur_time() + "Trying to contact update server... \n");
                if (AppVersion == v_in[0])
                {
                    console.AppendText("You have the newest version (" + AppVersion + ")\n");
                }
                else
                {
                    console.AppendText(cur_time() + "An update is available (" + AppVersion + "==>" + v_in[0] + ")\n");
                    console.AppendText(cur_time() + "Release: " + v_in[1] + " Desc: " + v_in[2] + "\n");
                }
            }
            else
            {
                console.AppendText(cur_time() + "Failed to contact master server... \n");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (readexisting_checkbox.Checked) {
                readto_input.Enabled = false;
                readtokey_checkbox.Enabled = false;
                savereadtokey_button.Enabled = false;
                readtokey_checkbox.Checked = false;
                read_method = "read_existing";
                console.AppendText(cur_time() + "Using read ReadExisting() \n");
                console.Focus();
            }
            else
            {
                readto_input.Enabled = true;
                readtokey_checkbox.Enabled = true;
                savereadtokey_button.Enabled = true;
                read_method = "readto";
                console.AppendText(cur_time() + "Using read ReadTo() \n");
                console.Focus();
            }
        }

        private void deleteSxistingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void hostServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is currently not available", "Not available");
        }

        

        private void editServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            server_settings server = new server_settings();
            server.Show();
        }

        //Sets the console background color
        private Boolean setConsoleBGColor(Color selColor) //selColor = selected color
        {
            if (console.BackColor != selColor)
            {
                console.BackColor = selColor;
                Properties.Settings.Default.bg_color = selColor;
                Properties.Settings.Default.Save();
                return true;
            }
            return false;
        }

        //Sets the console foreground color
        private Boolean setConsoleFGColor(Color selColor) //selColor = selected color
        {
            if (console.ForeColor != selColor)
            {
                console.ForeColor = selColor;
                Properties.Settings.Default.font_color = selColor;
                Properties.Settings.Default.Save();
                return true;
            }
            return false;
        }

        //Sets the console font size
        private Boolean setConsoleFSize(int selSize) //selSize = selected size
        {
            if (console.Font.Size != selSize)
            {
                console.Font = new Font("", selSize);
                Properties.Settings.Default.font_size = selSize;
                Properties.Settings.Default.Save();
                return true;
            }
            return false;
        }

        private void pxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setConsoleFSize(9);
        }

        private void pxToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            setConsoleFSize(12);
        }

        private void pxToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            setConsoleFSize(15);
        }

        private void pxToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            setConsoleFSize(20);
        }

        private void pxToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            setConsoleFSize(22);
        }

        private void pxToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            setConsoleFSize(25);
        }

        private void pxToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            setConsoleFSize(30);
        }

        private void consoleColorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setConsoleFGColor(Color.Blue);
        }

        private void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setConsoleFGColor(Color.Black);
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setConsoleFGColor(Color.Red);
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setConsoleFGColor(Color.Green);
        }

        private void grayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setConsoleFGColor(Color.Gray);
        }

        private void pinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setConsoleFGColor(Color.Pink);
        }

        private void brownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setConsoleFGColor(Color.Brown);
        }

        private void orangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setConsoleFGColor(Color.Orange);
        }

        private void yellowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setConsoleFGColor(Color.Yellow);
        }

        private void whiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setConsoleFGColor(Color.White);
        }

        private void blackToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            setConsoleBGColor(Color.Black);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            setConsoleBGColor(Color.Blue);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            setConsoleBGColor(Color.Red);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            setConsoleBGColor(Color.Green);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            setConsoleBGColor(Color.Gray);
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            setConsoleBGColor(Color.Pink);
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            setConsoleBGColor(Color.Brown);
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            setConsoleBGColor(Color.Orange);
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            setConsoleBGColor(Color.Yellow);
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            setConsoleBGColor(Color.White);
        }

        private void systemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setConsoleBGColor(System.Drawing.SystemColors.Control);
        }


    }
}
