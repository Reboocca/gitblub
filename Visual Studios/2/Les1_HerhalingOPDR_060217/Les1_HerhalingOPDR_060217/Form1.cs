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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Colour form = new Colour();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Location form = new Location();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Size form = new Size();
            form.Show();
        }
    }
}
