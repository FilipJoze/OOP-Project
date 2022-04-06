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

namespace OOP_Project
{
    /// <summary>
    /// Interaction logic for ActionMenu.xaml
    /// </summary>
    public partial class ActionMenu : Window
    {
        public ActionMenu()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem mi = new MenuItem();
            mi.ContextMenu.IsOpen = true;
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btnTransferFunds_Click(object sender, RoutedEventArgs e)
        {
            FundManager fm = new FundManager();
            fm.tabControlFunds.SelectedItem = fm.tabTransfer;
            fm.ShowDialog();
            
        }

        private void btnWithdrawFunds_Click(object sender, RoutedEventArgs e)
        {
            FundManager fm = new FundManager();
            fm.tabControlFunds.SelectedItem = fm.tabWithdraw;
            fm.ShowDialog();
            
        }

        private void btnDepositFunds_Click(object sender, RoutedEventArgs e)
        {
            FundManager fm = new FundManager();
            fm.tabControlFunds.SelectedItem = fm.tabDeposit;
            fm.ShowDialog();
        }

        private void btnViewTransactionHistory_Click(object sender, RoutedEventArgs e)
        {
            FundManager fm = new FundManager();
            fm.tabControlFunds.SelectedItem = fm.tabHistory;
            fm.ShowDialog();
        }

        private void btnAddAccount_Click(object sender, RoutedEventArgs e)
        {
            CreateAccount ca = new CreateAccount();
            ca.ShowDialog();
        }

        private void btnEditAccount_Click(object sender, RoutedEventArgs e)
        {
            EditAccount ea = new EditAccount();
            ea.ShowDialog();
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            UserLogin ul = new UserLogin();
            ul.Show();
            this.Close();
        }
    }
}
