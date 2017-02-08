using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OWL_LEARN
{
    /// <summary>
    /// Interaction logic for LesonderwerpToevoegen.xaml
    /// </summary>
    public partial class LesonderwerpToevoegen : Window
    {
        string VakID;
        LesOnderwerpCMS lastform = new LesOnderwerpCMS();
        public LesonderwerpToevoegen(LesOnderwerpCMS form, string SelectedVakID)
        {
            InitializeComponent();
            lastform = form;
            VakID = SelectedVakID;
        }

        DBS Class = new DBS();

        private void btTerug_Click(object sender, RoutedEventArgs e)
        {
            lastform.Show();
            this.Hide();
        }

        private void btOpslaan_Click(object sender, RoutedEventArgs e)
        {
            string sVakNaam = "";

            switch(VakID){
                case "1":
                    sVakNaam = "Geschiedenis";
                    break;
                case "2":
                    sVakNaam = "Rekenen";
                    break;
                case "3":
                    sVakNaam = "Biologie";
                    break;
                case "4":
                    sVakNaam = "Nederlands";
                    break;
                case "5":
                    sVakNaam = "Engels";
                    break;
            }

            Class.VoegLesOnderwerpToe(VakID, tbNaam.Text);
            MessageBox.Show("Het les onderwerp is toegevoegd aan " + sVakNaam + ".", "Succes!");

            LesOnderwerpCMS form = new LesOnderwerpCMS();
            form.Show();
            this.Close();
        }
    }
}
