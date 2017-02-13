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
using System.Windows.Threading;

namespace GreyhoundRace
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DispatcherTimer tm = new DispatcherTimer();

        Junkrat[] Player;
        Random RandomNr = new Random();
        public MainWindow()
        {
            InitializeComponent();
            Player = new Junkrat[4];

            tm.Interval = TimeSpan.FromMilliseconds(30);
            tm.Tick += Tm_Tick;

            Vector vector = VisualTreeHelper.GetOffset(cv_Junkrat1);

            int StartLocation = Convert.ToInt32(vector.X);
            int distance = Convert.ToInt32(cv_Junkrat1.Width - imJunkrat1.Width);
            for (int i = 0; i < 4; i++)
            {
                Player[i] = new Junkrat();
                Player[i].Random = RandomNr;
                Player[i].Racetrack = distance;
                Player[i].Location = Player[i].StartPosition = StartLocation;
                Player[i].Timer = tm;
            }

            Player[0].Junkrats = cv_Junkrat1;
            Player[0].imJunkrat = imJunkrat1;
            Player[1].Junkrats = cv_Junkrat2;
            Player[1].imJunkrat = imJunkrat2;
            Player[2].Junkrats = cv_Junkrat3;
            Player[2].imJunkrat = imJunkrat3;
            Player[3].Junkrats = cv_Junkrat4;
            Player[3].imJunkrat = imJunkrat4;
        }

        private void Tm_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Player.Length; i++)
            {
                Player[i].Move();
            }
        }

        private void btStart_Click(object sender, RoutedEventArgs e)
        {
            tm.Start();
        }
    }
}
