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
    public partial class Location : Form
    {
        public Location()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                form.Location = new Point(trackBar1.Value, form.Location.Y);
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                form.Location = new Point(form.Location.X, trackBar2.Value);
            }
        }
    }
}
