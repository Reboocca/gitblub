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

namespace GetLocationTest
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


        private void OnMouseDown(object sender, RoutedEventArgs e)
    {
       var element = sender as ContentControl;
       if (element != null)
       {
           ShowLocation(element);
         }
     }
     
    private void ShowLocation(ContentControl element)
    {
       var location = element.PointToScreen(new Point(0, 0));
       MessageBox.Show(string.Format(
                                      "{2}'s location is ({0}, {1})",
                                        location.X,
                                        location.Y,
                                        element.Content));
   }
    }
}
