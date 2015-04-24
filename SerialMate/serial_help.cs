using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace SerialMate
{
    public partial class serial_help : Form
    {
        String base_url = "http://internetlabs.eu/projects/serialmate/help_data/";
        netCheck netCheck = new netCheck();
        Boolean HasInternet = netCheck.CheckForInternet();
        Boolean offline = false;
        public serial_help()
        {
            InitializeComponent();
            treeView1.ExpandAll();
            backbone.ReadOnly = true;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode srl_h = treeView1.SelectedNode;
            if (HasInternet)
            {
                switch (string.Format(srl_h.Text))
                {
                    case "Hardware":
                        help_browser.Navigate(base_url + "hardware.html");
                        break;
                    case "Connectors":
                        help_browser.Navigate(base_url + "connectors.html");
                        break;
                    case "Settings":
                        help_browser.Navigate(base_url + "settings.html");
                        break;
                    case "Baud":
                        help_browser.Navigate(base_url + "baud.html");
                        break;
                    case "Data bits":
                        help_browser.Navigate(base_url + "databits.html");
                        break;
                    case "Parity":
                        help_browser.Navigate(base_url + "parity.html");
                        break;
                    case "Stop bits":
                        help_browser.Navigate(base_url + "stopbits.html");
                        break;
                    case "Flow control":
                        help_browser.Navigate(base_url + "flowcontrol.html");
                        break;
                    case "Usage":
                        help_browser.Navigate(base_url + "usage.html");
                        break;
                    case "Remote Server":
                        help_browser.Navigate(base_url + "remoteserver.html");
                        break;
                    case "Recipes":
                        help_browser.Navigate(base_url + "recipies.html");
                        break;
                    case "About":
                        help_browser.Navigate(base_url + "about.html");
                        break;
                    case "Serial Protocol":
                        help_browser.Navigate(base_url + "home.html");
                        break;
                    default:
                        help_browser.Navigate(base_url + "home.html");
                        break;
                }
                status_label.Text = "Done loaing...";
            }
            else
            {
                if (offline) 
                {
                    status_label.Text = "Switched to offline mode...";
                    help_browser.Visible = false;
                    switch (string.Format(srl_h.Text))
                    {
                        case "Hardware":
                            backbone.Clear();
                            backbone.AppendText("No offline pages available.");
                            break;
                        case "Connectors":
                            backbone.Clear();
                            backbone.AppendText("No offline pages available.");
                            break;
                        case "Settings":
                            backbone.Clear();
                            backbone.AppendText("No offline pages available.");
                            break;
                        case "Baud":
                            backbone.Clear();
                            backbone.AppendText("No offline pages available.");
                            break;
                        case "Data bits":
                            backbone.Clear();
                            backbone.AppendText("No offline pages available.");
                            break;
                        case "Parity":
                            backbone.Clear();
                            backbone.AppendText("No offline pages available.");
                            break;
                        case "Stop bits":
                            backbone.Clear();
                            backbone.AppendText("No offline pages available.");
                            break;
                        case "Flow control":
                            backbone.Clear();
                            backbone.AppendText("No offline pages available.");
                            break;
                        default:
                            backbone.Clear();
                            backbone.AppendText("No offline pages available.");
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Could not fetch online help pages. Switching to offline pages.", "Connection Error");
                    offline = true;
                    help_browser.Visible = false;
                    status_label.Text = "Failed to connect...";
                }
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
        }

        private void serial_help_Load(object sender, EventArgs e)
        {

        }
    }
}
