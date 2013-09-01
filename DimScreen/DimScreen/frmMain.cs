using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;



namespace DimScreen
{

    public partial class frmMain : Form
    {
        Timer timerPhase = new Timer() { Interval = 25, Enabled = false };
        public System.Drawing.Rectangle Area { get; set; }

        private float targetValue;
        private float currentValue;

        public float Dimness
        {
            get
            {
                return targetValue;
            }
            set
            {
                targetValue = value;
                timerPhase.Start();
            }
        }
        

#region Enum
        public enum GWL
        {
            ExStyle = -20
        }

        public enum WS_EX
        {
            Transparent = 0x20,
            Layered = 0x80000
        }

        public enum LWA
        {
            ColorKey = 0x1,
            Alpha = 0x2
        }
#endregion

#region DLLImport
        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        public static extern int GetWindowLong(IntPtr hWnd, GWL nIndex);

        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
        public static extern int SetWindowLong(IntPtr hWnd, GWL nIndex, int dwNewLong);

        [DllImport("user32.dll", EntryPoint = "SetLayeredWindowAttributes")]
        public static extern bool SetLayeredWindowAttributes(IntPtr hWnd, int crKey, byte alpha, LWA dwFlags);
#endregion


        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            int wl = GetWindowLong(this.Handle, GWL.ExStyle);
            wl = wl | 0x80000 | 0x20;
            SetWindowLong(this.Handle, GWL.ExStyle, wl);
            SetLayeredWindowAttributes(this.Handle, 0, 0, LWA.Alpha);
        }


        public frmMain()
        {
            InitializeComponent();
            timerPhase.Tick += timerPhase_Tick;
        }        


        private void Form1_Load(object sender, EventArgs e)
        {
            // use working space rectangle info
            this.Size = new System.Drawing.Size(Area.Width, Area.Height);
            this.Location = new System.Drawing.Point(Area.X, Area.Y);
        }

        private void timerPhase_Tick(object sender, EventArgs e)
        {
            applyTransparency();
        }

        private void applyTransparency()
        {
            float calculatedValue = currentValue + Math.Sign(targetValue - currentValue) * 0.02f;

            if (Math.Abs(targetValue - currentValue) < 0.02f * 2)
            {
                currentValue = targetValue;
                timerPhase.Stop();
            }

            byte value = (byte)(calculatedValue * 255);
            SetLayeredWindowAttributes(this.Handle, 0, value, LWA.Alpha);

            currentValue = calculatedValue;
        }


    }
}
