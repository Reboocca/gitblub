using System;
using Xamarin.Forms;

namespace UnitTestWalkThroughProject
{
    public partial class MainPage : ContentPage
    {
        BankAccount bankAccount = new BankAccount("Jeroen van Amsterdam",1000000.00);
        public MainPage()
        {
            InitializeComponent();
            Balance.Text = bankAccount.Balance.ToString();
            Name.Text = bankAccount.CustomerName;
        }

        private void Frozen_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if ((sender as Switch).IsToggled) bankAccount.UnfreezeAccount(); else bankAccount.FreezeAccount();
        }

        private void Debit_Clicked(object sender, EventArgs e)
        {
            double a = 0;
            Double.TryParse(Amount.Text, out a);
            bankAccount.Debit(a);
            Balance.Text = bankAccount.Balance.ToString();
        }

        private void Credit_Clicked(object sender, EventArgs e)
        {
            double a = 0;
            Double.TryParse(Amount.Text, out a);
            bankAccount.Credit(a);
            Balance.Text = bankAccount.Balance.ToString();
        }
    }
}
