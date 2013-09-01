using System;
using System.Windows.Forms;





namespace DimScreen
{
    public partial class frmTray : Form
    {
        // list of overlays currently displayed
        private System.Collections.Generic.List<Form> overlays = new System.Collections.Generic.List<Form>();

        public frmTray()
        {
            InitializeComponent();

        }

        public void DimWindow(byte value)
        {
            // remove exiting overlays
            clearOverlays();

            if (overlays.Count != Screen.AllScreens.Length)
            {
                // apply dimness onto all screens
                foreach (var screen in Screen.AllScreens)
                {
                    frmMain overlay = new frmMain();
                    overlay.Dimness = 0;
                    overlay.Area = screen.WorkingArea;
                    overlay.Show();

                    overlays.Add(overlay);
                }
            }

            foreach (frmMain form in overlays)
                form.Dimness = value;
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

            DimWindow(0);
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
    }
}
