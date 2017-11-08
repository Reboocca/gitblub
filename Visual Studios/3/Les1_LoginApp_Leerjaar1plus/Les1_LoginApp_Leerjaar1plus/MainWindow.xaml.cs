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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows;

namespace Les1_LoginApp_Leerjaar1plus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        dbs db = new dbs();


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(cb_Nieuw.IsChecked == true)
            {
                if(tbGebruiker.Text == "" || pbWachtwoord.Password == "")
                {
                    MessageBox.Show("Zorg ervoor dat u beide invoervelden hebt gegevuld.", "Foutmelding");
                }
                else
                {
                    //Maak nieuwe gebruiker aan
                    db.newUser(tbGebruiker.Text, pbWachtwoord.Password);
                }
            }
            else if(cb_Nieuw.IsChecked == false)
            {
                //Check inloggegevens en log in
                db.try_login(tbGebruiker.Text, pbWachtwoord.Password, this);
            }
        }
    }
}
