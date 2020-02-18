using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DimScreen
{
    public partial class frmOverlay : Form
    {
        public frmOverlay()
        {
            InitializeComponent();
        }

        int alph = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (alph < 255)
            {
                lblCounter.ForeColor = Color.FromArgb(alph, Color.Red);
                alph += 10;
            }
        }

        private void frmOverlay_Load(object sender, EventArgs e)
        {

        }
    }
}
