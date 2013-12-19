namespace DimScreen
{
    partial class frmTray
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTray));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuNormal = new System.Windows.Forms.ToolStripMenuItem();
            this.menu10 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu20 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu30 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu40 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu50 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu60 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu70 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu80 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu90 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu100 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuRestart = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Brightness";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNormal,
            this.menu10,
            this.menu20,
            this.menu30,
            this.menu40,
            this.menu50,
            this.menu60,
            this.menu70,
            this.menu80,
            this.menu90,
            this.menu100,
            this.toolStripSeparator1,
            this.menuRestart,
            this.menuExit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(142, 296);
            // 
            // menuNormal
            // 
            this.menuNormal.Name = "menuNormal";
            this.menuNormal.Size = new System.Drawing.Size(141, 22);
            this.menuNormal.Tag = "0";
            this.menuNormal.Text = "0% (Normal)";
            // 
            // menu10
            // 
            this.menu10.Name = "menu10";
            this.menu10.Size = new System.Drawing.Size(141, 22);
            this.menu10.Tag = "10";
            this.menu10.Text = "10%";
            // 
            // menu20
            // 
            this.menu20.Name = "menu20";
            this.menu20.Size = new System.Drawing.Size(141, 22);
            this.menu20.Tag = "20";
            this.menu20.Text = "20%";
            // 
            // menu30
            // 
            this.menu30.Name = "menu30";
            this.menu30.Size = new System.Drawing.Size(141, 22);
            this.menu30.Tag = "30";
            this.menu30.Text = "30%";
            // 
            // menu40
            // 
            this.menu40.Name = "menu40";
            this.menu40.Size = new System.Drawing.Size(141, 22);
            this.menu40.Tag = "40";
            this.menu40.Text = "40%";
            // 
            // menu50
            // 
            this.menu50.Name = "menu50";
            this.menu50.Size = new System.Drawing.Size(141, 22);
            this.menu50.Tag = "50";
            this.menu50.Text = "50%";
            // 
            // menu60
            // 
            this.menu60.Name = "menu60";
            this.menu60.Size = new System.Drawing.Size(141, 22);
            this.menu60.Tag = "60";
            this.menu60.Text = "60%";
            // 
            // menu70
            // 
            this.menu70.Name = "menu70";
            this.menu70.Size = new System.Drawing.Size(141, 22);
            this.menu70.Tag = "70";
            this.menu70.Text = "70%";
            // 
            // menu80
            // 
            this.menu80.Name = "menu80";
            this.menu80.Size = new System.Drawing.Size(141, 22);
            this.menu80.Tag = "80";
            this.menu80.Text = "80%";
            // 
            // menu90
            // 
            this.menu90.Name = "menu90";
            this.menu90.Size = new System.Drawing.Size(141, 22);
            this.menu90.Tag = "90";
            this.menu90.Text = "90%";
            // 
            // menu100
            // 
            this.menu100.Name = "menu100";
            this.menu100.Size = new System.Drawing.Size(141, 22);
            this.menu100.Tag = "100";
            this.menu100.Text = "100% (Black)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(138, 6);
            // 
            // menuRestart
            // 
            this.menuRestart.Name = "menuRestart";
            this.menuRestart.Size = new System.Drawing.Size(141, 22);
            this.menuRestart.Text = "Restart";
            this.menuRestart.Click += new System.EventHandler(this.menuRestart_Click);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(141, 22);
            this.menuExit.Text = "Exit";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // frmTray
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(116, 56);
            this.ControlBox = false;
            this.Name = "frmTray";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.frmTray_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem menuRestart;
        private System.Windows.Forms.ToolStripMenuItem menuNormal;
        private System.Windows.Forms.ToolStripMenuItem menu10;
        private System.Windows.Forms.ToolStripMenuItem menu20;
        private System.Windows.Forms.ToolStripMenuItem menu30;
        private System.Windows.Forms.ToolStripMenuItem menu40;
        private System.Windows.Forms.ToolStripMenuItem menu50;
        private System.Windows.Forms.ToolStripMenuItem menu60;
        private System.Windows.Forms.ToolStripMenuItem menu70;
        private System.Windows.Forms.ToolStripMenuItem menu80;
        private System.Windows.Forms.ToolStripMenuItem menu90;
        private System.Windows.Forms.ToolStripMenuItem menu100;
    }
}