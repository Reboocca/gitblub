using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace OP4_WK2_PRG_uitleg_sockets
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StartTCPListener();
        }

        //Dit is een chat-applicatie, client -> server, server -> client
        //server heeft een ip adres + poort

        TcpListener server = null;

        public void StartTCPListener()
        {
            try
            {
                //Port number + IP adress
                int port = 1313;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");

                //Vul de waarder in bij de server
                server = new TcpListener(localAddr, port);

                //Start de server
                server.Start();

                //Grootte bericht + data string
                byte[] bytes = new byte[256];
                string data = null;

                while (true)
                {
                    //Accepteer de client (of maak connectie) IDK WHAT DIS DOES
                    TcpClient client = server.AcceptTcpClient();

                    //Maak de data leeg
                    data = null;

                    //Network stream ophalen (binnenhalen wat de client verstuurd)
                    NetworkStream stream = client.GetStream();

                    int i;

                    //loop om alles op te halen van de client
                    while((i = stream.Read(bytes, 0, bytes.Length))!= 0)
                    {
                        //Vul de data
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);

                        //Zet het bericht om naar hoofdletters
                        data = data.ToUpper();

                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                        //Stuur een bericht terug
                        stream.Write(msg, 0, msg.Length);
                    }

                    //Beëindig de connectie
                    client.Close();
                }

            }
            catch (Exception)
            {
                //Wanneer de code niet werkt
                MessageBox.Show("René kan niet uitleggen", "Er is iets mis gegaan");
            }
            finally
            {
                //Stop de server
                server.Stop();
            }
        }
    }
}
