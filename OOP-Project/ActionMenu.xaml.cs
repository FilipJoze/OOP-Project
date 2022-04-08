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
using DAL;
using System.Data;
using System.Data.SqlClient;

namespace OOP_Project
{
    /// <summary>
    /// Interaction logic for ActionMenu.xaml
    /// </summary>
    public partial class ActionMenu : Window
    {
        DAO dao = new DAO();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();

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

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSearch.Text == "")
            {
                PopulateGrid();
            }
            int search = 1;
            if(int.TryParse(txtSearch.Text, out search))
            {
                SearchByAccNum(search);
            }
           
        }

        private void SearchByAccNum(int search)
        {
            da = new SqlDataAdapter();
            dt = new DataTable();
            DataGrid dgv = new DataGrid();

            SqlCommand cmd = dao.OpenCon().CreateCommand();
            cmd.CommandText = "uspSearch";
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@searchacc", search);
            dao.OpenCon();
            da.SelectCommand = cmd;
            da.Fill(dt);
            dgvAccounts.ItemsSource = dt.DefaultView;
            dao.CloseCon();


        }
        
        private void PopulateGrid()
        {
            da = new SqlDataAdapter();
            dt = new DataTable();
            DataGrid dgv = new DataGrid();

            SqlCommand cmd = dao.OpenCon().CreateCommand();
            cmd.CommandText = "uspShowAccounts";
            cmd.CommandType = CommandType.StoredProcedure;


            //cmd.Parameters.AddWithValue("@searchacc", search);
            dao.OpenCon();
            da.SelectCommand = cmd;
            da.Fill(dt);
            dgvAccounts.ItemsSource = dt.DefaultView;
            dao.CloseCon();
        }
        
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateGrid();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            PopulateGrid();
        }

        private void btnSerialiseXML_Click(object sender, RoutedEventArgs e)
        {
            Serialiser sr = new Serialiser();
            sr.ShowDialog();
        }
    }
}
