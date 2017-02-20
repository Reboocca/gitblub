namespace PInvokeThread
{
    partial class frmThread
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
            this.tmMain = new System.Windows.Forms.Timer(this.components);
            this.lblSecMain = new System.Windows.Forms.Label();
            this.lblMainCountSec = new System.Windows.Forms.Label();
            this.grBMain = new System.Windows.Forms.GroupBox();
            this.grpBoxSecond = new System.Windows.Forms.GroupBox();
            this.lblSecondCntSeconds = new System.Windows.Forms.Label();
            this.lblSecondSec = new System.Windows.Forms.Label();
            this.grBMain.SuspendLayout();
            this.grpBoxSecond.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmMain
            // 
            this.tmMain.Interval = 1000;
            this.tmMain.Tick += new System.EventHandler(this.tmMain_Tick);
            // 
            // lblSecMain
            // 
            this.lblSecMain.AutoSize = true;
            this.lblSecMain.Location = new System.Drawing.Point(6, 43);
            this.lblSecMain.Name = "lblSecMain";
            this.lblSecMain.Size = new System.Drawing.Size(76, 17);
            this.lblSecMain.TabIndex = 0;
            this.lblSecMain.Text = "Seconden:";
            // 
            // lblMainCountSec
            // 
            this.lblMainCountSec.AutoSize = true;
            this.lblMainCountSec.Location = new System.Drawing.Point(106, 43);
            this.lblMainCountSec.Name = "lblMainCountSec";
            this.lblMainCountSec.Size = new System.Drawing.Size(16, 17);
            this.lblMainCountSec.TabIndex = 1;
            this.lblMainCountSec.Text = "0";
            this.lblMainCountSec.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grBMain
            // 
            this.grBMain.Controls.Add(this.lblMainCountSec);
            this.grBMain.Controls.Add(this.lblSecMain);
            this.grBMain.Location = new System.Drawing.Point(38, 40);
            this.grBMain.Name = "grBMain";
            this.grBMain.Size = new System.Drawing.Size(200, 98);
            this.grBMain.TabIndex = 2;
            this.grBMain.TabStop = false;
            this.grBMain.Text = "Main";
            // 
            // grpBoxSecond
            // 
            this.grpBoxSecond.Controls.Add(this.lblSecondCntSeconds);
            this.grpBoxSecond.Controls.Add(this.lblSecondSec);
            this.grpBoxSecond.Location = new System.Drawing.Point(38, 202);
            this.grpBoxSecond.Name = "grpBoxSecond";
            this.grpBoxSecond.Size = new System.Drawing.Size(200, 100);
            this.grpBoxSecond.TabIndex = 3;
            this.grpBoxSecond.TabStop = false;
            this.grpBoxSecond.Text = "Thread";
            // 
            // lblSecondCntSeconds
            // 
            this.lblSecondCntSeconds.AutoSize = true;
            this.lblSecondCntSeconds.Location = new System.Drawing.Point(106, 43);
            this.lblSecondCntSeconds.Name = "lblSecondCntSeconds";
            this.lblSecondCntSeconds.Size = new System.Drawing.Size(16, 17);
            this.lblSecondCntSeconds.TabIndex = 3;
            this.lblSecondCntSeconds.Text = "0";
            this.lblSecondCntSeconds.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSecondSec
            // 
            this.lblSecondSec.AutoSize = true;
            this.lblSecondSec.Location = new System.Drawing.Point(6, 43);
            this.lblSecondSec.Name = "lblSecondSec";
            this.lblSecondSec.Size = new System.Drawing.Size(76, 17);
            this.lblSecondSec.TabIndex = 2;
            this.lblSecondSec.Text = "Seconden:";
            // 
            // frmThread
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 331);
            this.Controls.Add(this.grpBoxSecond);
            this.Controls.Add(this.grBMain);
            this.Name = "frmThread";
            this.Text = "Form1";
            this.grBMain.ResumeLayout(false);
            this.grBMain.PerformLayout();
            this.grpBoxSecond.ResumeLayout(false);
            this.grpBoxSecond.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmMain;
        private System.Windows.Forms.Label lblSecMain;
        private System.Windows.Forms.Label lblMainCountSec;
        private System.Windows.Forms.GroupBox grBMain;
        private System.Windows.Forms.GroupBox grpBoxSecond;
        private System.Windows.Forms.Label lblSecondCntSeconds;
        private System.Windows.Forms.Label lblSecondSec;
    }
}

