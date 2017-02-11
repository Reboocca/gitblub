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

namespace GreyhoundRace
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Junkrat[] Player;

        public MainWindow()
        {
            InitializeComponent();
            Random RandomNr = new Random();

            Player = new Junkrat[4];

            int StartLocation = (int)Canvas.GetTop(cv_Junkrat1);
            int distance = (int)cv_Junkrat1.Width;
            for (int i = 0; i < 4; i++)
            {
                Player[i] = new Junkrat();
                Player[i].Random = RandomNr;
                Player[i].Racetrack = distance;
                Player[i].Location = Player[i].StartPosition = StartLocation;
            }

            Player[0].Junkrats = cv_Junkrat1;
            Player[1].Junkrats = cv_Junkrat2;
            Player[2].Junkrats = cv_Junkrat3;
            Player[3].Junkrats = cv_Junkrat4;
        }

        private void btStart_Click(object sender, RoutedEventArgs e)
        {
            Player[1].Move();
        }
    }
}
