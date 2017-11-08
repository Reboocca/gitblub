using System;
using System.Collections.Generic;
using System.Data;
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

namespace Les1_LoginApp_Leerjaar1plus
{
    /// <summary>
    /// Interaction logic for form.xaml
    /// </summary>
    public partial class form : Window
    {
        public form()
        {
            InitializeComponent();
            Loading();
        }

        dbs db = new dbs();

        struct Info
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string Desc { get; set; }
            public string Type { get; set; }
            public string Number { get; set; }
        }

        List<Info> lstInfo = new List<Info>();

        public void Loading()
        {
            DataTable dtInfo = new dbs().Search("pokemon");
            
            int iCounterDatum = 0;

            foreach (DataRow drInfo in dtInfo.Rows)
            {
                lstInfo.Add(new Info() { ID = drInfo[0].ToString(), Name = drInfo[1].ToString(), Desc = drInfo[2].ToString(), Type = drInfo[3].ToString(), Number = drInfo[4].ToString() });
                iCounterDatum++;
            }

            lvInfo.ItemsSource = lstInfo;
        }
    }
}
