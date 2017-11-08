namespace HerhalingLes1_060217
{
    partial class Form1
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
            this.btGrootte = new System.Windows.Forms.Button();
            this.btKleur = new System.Windows.Forms.Button();
            this.btLocatie = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btGrootte
            // 
            this.btGrootte.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGrootte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btGrootte.Location = new System.Drawing.Point(178, 43);
            this.btGrootte.Name = "btGrootte";
            this.btGrootte.Size = new System.Drawing.Size(160, 47);
            this.btGrootte.TabIndex = 0;
            this.btGrootte.Text = "Grootte";
            this.btGrootte.UseVisualStyleBackColor = true;
            // 
            // btKleur
            // 
            this.btKleur.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btKleur.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btKleur.Location = new System.Drawing.Point(12, 43);
            this.btKleur.Name = "btKleur";
            this.btKleur.Size = new System.Drawing.Size(160, 47);
            this.btKleur.TabIndex = 1;
            this.btKleur.Text = "Kleur";
            this.btKleur.UseVisualStyleBackColor = true;
            this.btKleur.Click += new System.EventHandler(this.btKleur_Click);
            // 
            // btLocatie
            // 
            this.btLocatie.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLocatie.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btLocatie.Location = new System.Drawing.Point(344, 43);
            this.btLocatie.Name = "btLocatie";
            this.btLocatie.Size = new System.Drawing.Size(160, 47);
            this.btLocatie.TabIndex = 2;
            this.btLocatie.Text = "Locatie";
            this.btLocatie.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 126);
            this.Controls.Add(this.btLocatie);
            this.Controls.Add(this.btKleur);
            this.Controls.Add(this.btGrootte);
            this.Name = "Form1";
            this.Text = "Sliderding!";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btGrootte;
        private System.Windows.Forms.Button btKleur;
        private System.Windows.Forms.Button btLocatie;
    }
}

