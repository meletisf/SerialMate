namespace SerialMate
{
    partial class server_settings
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(server_settings));
            this.label1 = new System.Windows.Forms.Label();
            this.server_ip = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.server_password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.server_save = new System.Windows.Forms.Button();
            this.server_status = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.server_port = new System.Windows.Forms.NumericUpDown();
            this.reconnect = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.server_port)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server IP:";
            // 
            // server_ip
            // 
            this.server_ip.Location = new System.Drawing.Point(10, 44);
            this.server_ip.Name = "server_ip";
            this.server_ip.Size = new System.Drawing.Size(209, 20);
            this.server_ip.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label2.Location = new System.Drawing.Point(6, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port:";
            // 
            // server_password
            // 
            this.server_password.Location = new System.Drawing.Point(10, 138);
            this.server_password.Name = "server_password";
            this.server_password.Size = new System.Drawing.Size(209, 20);
            this.server_password.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label3.Location = new System.Drawing.Point(6, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password:";
            // 
            // server_save
            // 
            this.server_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.server_save.Location = new System.Drawing.Point(60, 172);
            this.server_save.Name = "server_save";
            this.server_save.Size = new System.Drawing.Size(99, 34);
            this.server_save.TabIndex = 6;
            this.server_save.Text = "Save";
            this.server_save.UseVisualStyleBackColor = true;
            this.server_save.Click += new System.EventHandler(this.button1_Click);
            // 
            // server_status
            // 
            this.server_status.AutoSize = true;
            this.server_status.Location = new System.Drawing.Point(9, 241);
            this.server_status.Name = "server_status";
            this.server_status.Size = new System.Drawing.Size(35, 13);
            this.server_status.TabIndex = 7;
            this.server_status.Text = "label4";
            this.server_status.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.server_port);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.server_ip);
            this.groupBox1.Controls.Add(this.server_save);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.server_password);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(239, 226);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Network";
            // 
            // server_port
            // 
            this.server_port.Location = new System.Drawing.Point(10, 89);
            this.server_port.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.server_port.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.server_port.Name = "server_port";
            this.server_port.Size = new System.Drawing.Size(209, 20);
            this.server_port.TabIndex = 9;
            this.server_port.Value = new decimal(new int[] {
            58035,
            0,
            0,
            0});
            this.server_port.ValueChanged += new System.EventHandler(this.port_ValueChanged);
            // 
            // server_settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 262);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.server_status);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "server_settings";
            this.Text = "SerialMate Remote Server Settings";
            this.Load += new System.EventHandler(this.server_settings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.server_port)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox server_ip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox server_password;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button server_save;
        private System.Windows.Forms.Label server_status;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown server_port;
        private System.Windows.Forms.Timer reconnect;
    }
}