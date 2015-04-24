namespace SerialMate
{
    partial class serial_help
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Connectors");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Hardware", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Baud");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Data bits");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Parity");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Stop bits");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Flow control");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Settings", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Serial Protocol", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Usage");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Remote Server");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Recipes");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("About");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("SerialMate", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(serial_help));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.backbone = new System.Windows.Forms.RichTextBox();
            this.help_browser = new System.Windows.Forms.WebBrowser();
            this.status_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.SystemColors.Control;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "connectors";
            treeNode1.Text = "Connectors";
            treeNode2.Name = "hardware";
            treeNode2.Text = "Hardware";
            treeNode3.Name = "baud";
            treeNode3.Text = "Baud";
            treeNode4.Name = "db";
            treeNode4.Text = "Data bits";
            treeNode5.Name = "parity";
            treeNode5.Text = "Parity";
            treeNode6.Name = "sb";
            treeNode6.Text = "Stop bits";
            treeNode7.Name = "fc";
            treeNode7.Text = "Flow control";
            treeNode8.Name = "settings";
            treeNode8.Text = "Settings";
            treeNode9.Name = "serial_prot";
            treeNode9.Text = "Serial Protocol";
            treeNode10.Name = "usage";
            treeNode10.Text = "Usage";
            treeNode11.Name = "remoteserver";
            treeNode11.Text = "Remote Server";
            treeNode12.Name = "recipes";
            treeNode12.Text = "Recipes";
            treeNode13.Name = "about";
            treeNode13.Text = "About";
            treeNode14.Name = "serialmate";
            treeNode14.Text = "SerialMate";
            treeNode14.ToolTipText = "Help about the application itself";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode14});
            this.treeView1.Size = new System.Drawing.Size(167, 564);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // backbone
            // 
            this.backbone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.backbone.Location = new System.Drawing.Point(185, 12);
            this.backbone.Name = "backbone";
            this.backbone.Size = new System.Drawing.Size(581, 564);
            this.backbone.TabIndex = 1;
            this.backbone.Text = "";
            // 
            // help_browser
            // 
            this.help_browser.Location = new System.Drawing.Point(194, 21);
            this.help_browser.MinimumSize = new System.Drawing.Size(20, 20);
            this.help_browser.Name = "help_browser";
            this.help_browser.ScriptErrorsSuppressed = true;
            this.help_browser.Size = new System.Drawing.Size(565, 546);
            this.help_browser.TabIndex = 2;
            this.help_browser.Url = new System.Uri("", System.UriKind.Relative);
            this.help_browser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // status_label
            // 
            this.status_label.AutoSize = true;
            this.status_label.Location = new System.Drawing.Point(12, 579);
            this.status_label.Name = "status_label";
            this.status_label.Size = new System.Drawing.Size(111, 13);
            this.status_label.TabIndex = 3;
            this.status_label.Text = "Fetching online help...";
            // 
            // serial_help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 597);
            this.Controls.Add(this.status_label);
            this.Controls.Add(this.help_browser);
            this.Controls.Add(this.backbone);
            this.Controls.Add(this.treeView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "serial_help";
            this.Text = "SerialMate - Protocol Help";
            this.Load += new System.EventHandler(this.serial_help_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.RichTextBox backbone;
        private System.Windows.Forms.WebBrowser help_browser;
        private System.Windows.Forms.Label status_label;
    }
}