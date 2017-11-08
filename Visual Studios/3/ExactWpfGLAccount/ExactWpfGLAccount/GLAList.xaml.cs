using Exact;
using System;
using System.Windows;
using System.Windows.Controls;


namespace ExactWpfGLAccount
{
    public partial class GLAList : Window
    {
        public GLAList()
        {
            InitializeComponent();
        }

        private async void ToonGLAccounts()
        {
            string f = filter.Text.Trim();   
            list.ItemsSource = await Rest.getGLAccounts(f);
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            ToonGLAccounts();
        }

        private void Refresh_Click(object sender, System.Windows.Input.KeyEventArgs e)
        {
            ToonGLAccounts();
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count <= 0) return;
            GLAccount gla = e.AddedItems[0] as GLAccount;
            GLAEdit glaEdit = new GLAEdit();
            glaEdit.glaAccount = gla;
            glaEdit.Show();
        }
    }
}
