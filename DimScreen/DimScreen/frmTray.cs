﻿using System;
using System.Windows.Forms;





namespace DimScreen
{
    public partial class frmTray : Form
    {
        public frmTray()
        {
            InitializeComponent();

        }

        private void frmTray_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            //Display a Message box asking if the user wishes to exit.
            DialogResult reply = MessageBox.Show("Are you sure you want to exit?", "Close?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //If users answer was yes.
            if (reply == DialogResult.Yes)
            {
                //Clean up any used memeory.
                GC.Collect();

                Form fc = Application.OpenForms["frmMain"];
                if (fc != null) fc.Dispose(); 

                //Remove tray Icon
                notifyIcon1.Dispose();

                //Close the Application.
                this.Dispose();
            }   

        }


        public void DimWindow(byte DimAmount)
        {
            Form fc = Application.OpenForms["frmMain"];
            if (fc != null) fc.Dispose();


            frmMain Main = new frmMain();
            Main.Dimness = DimAmount;
            Main.Show();
        }




        private void frmTray_Load(object sender, EventArgs e)
        {
            DimWindow(0);
        }


        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //Exit the Application
            Application.Exit();
        }


        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            if (toolStripComboBox1.Text.ToString() == "Normal"){
                DimWindow(0);
            }else if (toolStripComboBox1.Text.ToString() == "10%"){
                DimWindow(25);
            }else if (toolStripComboBox1.Text.ToString() == "20%"){
                DimWindow(51);
            }else if (toolStripComboBox1.Text.ToString() == "30%"){
                DimWindow(76);
            }else if (toolStripComboBox1.Text.ToString() == "40%"){
                DimWindow(102);
            }else if (toolStripComboBox1.Text.ToString() == "50%"){
                DimWindow(127);
            }else if (toolStripComboBox1.Text.ToString() == "60%"){
                DimWindow(153);
            }else if (toolStripComboBox1.Text.ToString() == "70%"){
                DimWindow(178);
            }else if (toolStripComboBox1.Text.ToString() == "80%"){
                DimWindow(204);
            }else if (toolStripComboBox1.Text.ToString() == "90%"){
                DimWindow(229);
            }else if (toolStripComboBox1.Text.ToString() == "100%"){
                DimWindow(255);
            }
        }


        private void toolStripComboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
    }
}