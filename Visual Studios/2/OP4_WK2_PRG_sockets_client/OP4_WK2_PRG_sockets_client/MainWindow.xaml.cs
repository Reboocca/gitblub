using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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

namespace OP4_WK2_PRG_sockets_client
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

        //Client applicatie chat programma
        string sIPSelected = "127.0.0.1"; //localhost
        int iPort = 1313;

        private void btSend_Click(object sender, RoutedEventArgs e)
        {
            if(tbClient.Text.Trim().Length > 0)
            {
                //voer de functie uit
                connectStream();
            }
        }

        public void connectStream()
        {
            try
            {
                string sMessage = tbClient.Text;

                TcpClient client = new TcpClient(sIPSelected, iPort);

                byte[] data = System.Text.Encoding.ASCII.GetBytes(sMessage);

                //Maak een nieuwe stream
                NetworkStream stream = client.GetStream();

                //Stuur het bericht
                stream.Write(data, 0, data.Length);

                //Client ontvang ook, daarom maken we een data byte aan.
                data = new byte[256];

                string responseData = string.Empty;

                //Stuur de message terug ? ... IDK OKAY?!
                int byes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, data.Length);
                tbServer.Text = responseData;

                //Stop de connectie
                stream.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("René kan niet uitleggen", "Er is IETS mis gegeaan, IDK WAT..");
            }
        }
    }
}
