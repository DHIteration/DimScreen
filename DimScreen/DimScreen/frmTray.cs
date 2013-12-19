using System;
using System.Windows.Forms;

namespace DimScreen
{
    public partial class frmTray : Form
    {
        // list of overlays currently displayed
        private System.Collections.Generic.List<frmMain> overlays = new System.Collections.Generic.List<frmMain>();

        public frmTray()
        {
            InitializeComponent();

        }

        private void configureOverlays(float initialValue)
        {
            // remove exiting overlays
            clearOverlays();

            // add screens if they don't already exist
            if (overlays.Count != Screen.AllScreens.Length)
            {
                // apply dimness onto all screens
                foreach (var screen in Screen.AllScreens)
                {
                    frmMain overlay = new frmMain();
                    overlay.Dimness = 0;
                    overlay.Area = screen.WorkingArea;
                    overlay.Show();

                    // add to list of overlays
                    overlays.Add(overlay);
                }
            }

            foreach (frmMain form in overlays)
                form.Dimness = initialValue;
        }

        private void clearOverlays()
        {
            foreach (var form in overlays)
                form.Dispose();

            overlays.Clear();
        }


        private void frmTray_Load(object sender, EventArgs e)
        {
            menuNormal.Click += numericMenus_Click;
            menu10.Click += numericMenus_Click;
            menu20.Click += numericMenus_Click;
            menu30.Click += numericMenus_Click;
            menu40.Click += numericMenus_Click;
            menu50.Click += numericMenus_Click;
            menu60.Click += numericMenus_Click;
            menu70.Click += numericMenus_Click;
            menu80.Click += numericMenus_Click;
            menu90.Click += numericMenus_Click;
            menu100.Click += numericMenus_Click;

            // get command line values
            var arg = "";
            var args = Environment.GetCommandLineArgs();
            if (args.Length > 1) arg = args[1];

            //TEST: force command line arg to test
            //arg = "50";

            if (arg != "")
            {
                try
                {
                    var val = float.Parse(arg) / 100;
                    if (val > 100 || val < 0) throw new Exception("Out of range");
                    configureOverlays(val);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Expecting number from 0 to 100 to represent percentage of dimming. 0 means no change, 100 being totally dark.");
                    configureOverlays(0);
                }
            }
            else
            {
                configureOverlays(0);
            }
        }


        private void menuExit_Click(object sender, EventArgs e)
        {
            //Display a Message box asking if the user wishes to exit.
            DialogResult reply = MessageBox.Show("Are you sure you want to exit?", "Close?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //If users answer was yes.
            if (reply == DialogResult.Yes)
            {
                //Clean up any used memeory.
                GC.Collect();

                // remove all overlays
                clearOverlays();

                //Remove tray Icon
                notifyIcon1.Dispose();

                //Close the Application.
                this.Dispose();
            }
        }

        private void numericMenus_Click(object sender, EventArgs e)
        {
            var value = float.Parse((((ToolStripMenuItem)sender).Tag.ToString()));

            foreach (frmMain form in overlays)
                form.Dimness = value / 100;
        }

        private void menuRestart_Click(object sender, EventArgs e)
        {
            var exePath = Application.ExecutablePath;
            System.Diagnostics.Process.Start(exePath, (overlays[0].Dimness * 100).ToString());
            Application.Exit();
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
             contextMenuStrip1.Show();
        }
    }
}
