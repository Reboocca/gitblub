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
    public partial class Size : Form
    {
        public Size()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                form.Width = trackBar1.Value;
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                form.Height = trackBar2.Value;
            }
        }
    }
}
