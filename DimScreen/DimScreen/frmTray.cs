using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace DimScreen
{
    public partial class frmTray : Form
    {


        //Used to setup our registry access.
        RegistryKey regkey = null;
        public static RegistryKey regkey_ = null;

        float DimPercent = 0;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);


        enum KeyModifier
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            WinKey = 8
        }


        // list of overlays currently displayed
        private System.Collections.Generic.List<frmMain> overlays = new System.Collections.Generic.List<frmMain>();

        public frmTray()
        {
            InitializeComponent();


            //Connect to registry.
            regkey = Registry.CurrentUser.OpenSubKey("Software\\DimScreen", true);
            regkey_ = regkey;

            //If connection was Bad or First Run.
            if (regkey == null)
            {
                //Create or Regitry values.
                Registry.CurrentUser.CreateSubKey("Software\\DimScreen");
                regkey = Registry.CurrentUser.OpenSubKey("Software\\DimScreen", true);
                regkey_ = regkey;

                //Save our data.
                regkey.SetValue("DimAmount", 0);

                // Check the first item in the list
                var firstItem = (ToolStripMenuItem)contextMenuStrip1.Items[0];
                firstItem.Checked = true;
            }
            else
            {
                //Check item with value in use
                foreach (var i in contextMenuStrip1.Items)
                {
                    //Skip if Separator is found instead of Item
                    if (i.GetType().Equals(typeof(ToolStripSeparator)))
                    {
                        continue;
                    }

                    //Cast as Item and check appropriately
                    ToolStripMenuItem item = (ToolStripMenuItem)i;
                    int itemValue = int.Parse((string)item.Tag);
                    int regValue = int.Parse((string)regkey_.GetValue("DimAmount"));
                    if (itemValue == regValue)
                    {
                        item.Checked = true;
                        break;
                    }
                }
            }



            //Hotkey Registration.
            RegisterHotKey(this.Handle, 0, (int)KeyModifier.Control, Keys.Add.GetHashCode());       // Register Ctrl + Add as global hotkey. 
            RegisterHotKey(this.Handle, 1, (int)KeyModifier.Control, Keys.Subtract.GetHashCode());  // Register Ctrl + Subtract as global hotkey. 

        }


        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x0312)
            {
                /* Note that the three lines below are not needed if you only want to register one hotkey.
                 * The below lines are useful in case you want to register multiple keys, which you can use a switch with the id as argument, or if you want to know which key/modifier was pressed for some particular reason. */

                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);                  // The key of the hotkey that was pressed.
                KeyModifier modifier = (KeyModifier)((int)m.LParam & 0xFFFF);       // The modifier of the hotkey that was pressed.
                int id = m.WParam.ToInt32();                                        // The id of the hotkey that was pressed.

                //Increase Percrent of Dimming.
                if (key == Keys.Add && modifier == KeyModifier.Control)
                {
                    if (DimPercent == 100) return;
                    DimPercent += 10;
                    regkey.SetValue("DimAmount", DimPercent);
                }

                //Decrease Percent of Dimming.
                if (key == Keys.Subtract && modifier == KeyModifier.Control)
                {
                    if (DimPercent == 0) return;
                    DimPercent -= 10;
                    regkey.SetValue("DimAmount", DimPercent);

                }


                //Choose the Menu Item based on new percent and click.
                foreach (ToolStripMenuItem item in this.contextMenuStrip1.Items)
                {
                    if (item.Text.Contains(DimPercent.ToString()))
                    {
                        item.PerformClick();
                        return;
                    }
                }



            }
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
                    MessageBox.Show(this, "Expecting number from 0 to 100 to represent percentage of dimming. 0 means no change, 100 being totally dark.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    configureOverlays(0);
                }
            }
            else
            {
                try
                {
                    object regObject = regkey.GetValue("DimAmount", 0);
                    float savedValue = (float.Parse(regObject.ToString()) / 100);
                    if (savedValue > 100 || savedValue < 0) throw new Exception("Out of range");
                    configureOverlays(savedValue);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Expecting number from 0 to 100 to represent percentage of dimming. 0 means no change, 100 being totally dark.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    configureOverlays(0);
                }
            }
        }











        private void menuExit_Click(object sender, EventArgs e)
        {
            //Display a Message box asking if the user wishes to exit.
            DialogResult reply = MessageBox.Show(this, "Are you sure you want to exit?", "Close?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //If users answer was yes.
            if (reply == DialogResult.Yes)
            {
                // remove all overlays
                clearOverlays();

                //Remove tray Icon
                notifyIcon1.Dispose();

                //Remove Hotkey Hooks
                UnregisterHotKey(this.Handle, 0);
                UnregisterHotKey(this.Handle, 1);

                //Clean up any used memeory.
                GC.Collect();

                //Close the Application.
                this.Dispose();
            }
        }

        private void numericMenus_Click(object sender, EventArgs e)
        {
            //Get clicked item as Item
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;

            //Check new item and uncheck old items
            foreach (var i in contextMenuStrip1.Items)
            {
                //Skip if Separator is found instead of Item
                if (i.GetType().Equals(typeof(ToolStripSeparator)))
                {
                    continue;
                }

                //Cast as Item and check appropriately
                ToolStripMenuItem item = (ToolStripMenuItem)i;
                if (item == menuItem)
                    item.Checked = true;
                else
                    item.Checked = false;
            }

            //Get value of selected item
            var value = float.Parse((menuItem.Tag.ToString()));

            //Saving Percentage of dim value for use with hotkeys.
            DimPercent = value;
            regkey.SetValue("DimAmount", DimPercent);

            foreach (frmMain form in overlays)
                form.Dimness = value / 100;
        }

        private void menuRestart_Click(object sender, EventArgs e)
        {
            var exePath = Application.ExecutablePath;
            System.Diagnostics.Process.Start(exePath, (overlays[0].Dimness * 100).ToString());
            GC.Collect();
            Application.Exit();
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            contextMenuStrip1.Show();
        }


    }
}
