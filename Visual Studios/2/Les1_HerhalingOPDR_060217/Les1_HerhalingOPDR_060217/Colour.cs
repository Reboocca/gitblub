using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Les1_HerhalingOPDR_060217
{
    public partial class Colour : Form
    {
        public Colour()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {           
            foreach(Form form in Application.OpenForms)
            {
                switch (comboBox1.SelectedItem.ToString())
                {
                    case "Red":
                        form.BackColor = System.Drawing.Color.Tomato;
                        break;
                    case "Orange":
                        form.BackColor = System.Drawing.Color.Coral;
                        break;
                    case "Yellow":
                        form.BackColor = System.Drawing.Color.PaleGoldenrod;
                        break;
                    case "Green":
                        form.BackColor = System.Drawing.Color.LightGreen;
                        break;
                    case "Blue":
                        form.BackColor = System.Drawing.Color.PaleTurquoise;
                        break;
                    case "Purple":
                        form.BackColor = System.Drawing.Color.SlateBlue;
                        break;
                }
            }
        }
    }
}
