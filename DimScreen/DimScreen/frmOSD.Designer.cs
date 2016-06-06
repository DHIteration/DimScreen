namespace DimScreen
{
    partial class frmOSD
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
            this.lblDimmed = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDimmed
            // 
            this.lblDimmed.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDimmed.ForeColor = System.Drawing.Color.White;
            this.lblDimmed.Location = new System.Drawing.Point(12, 9);
            this.lblDimmed.Name = "lblDimmed";
            this.lblDimmed.Size = new System.Drawing.Size(224, 28);
            this.lblDimmed.TabIndex = 1;
            this.lblDimmed.Text = "Dimmed:  0%";
            this.lblDimmed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmOSD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(248, 52);
            this.ControlBox = false;
            this.Controls.Add(this.lblDimmed);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOSD";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmDisplay_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lblDimmed;
    }
}