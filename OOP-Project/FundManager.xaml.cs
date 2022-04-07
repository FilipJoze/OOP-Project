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
using System.Data;
using System.Data.SqlClient;
using DAL;

namespace OOP_Project
{
    /// <summary>
    /// Interaction logic for FundManager.xaml
    /// </summary>
    public partial class FundManager : Window
    {
        public FundManager()
        {
            InitializeComponent();
        }

        DAO dao = new DAO();
        SqlDataReader dr;
        Deposit_Withdraw dw = new Deposit_Withdraw();
        private void btnTransfer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnWithdraw_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tabDeposit_Loaded(object sender, RoutedEventArgs e)
        {
            GetAccNo();
        }

        private void cboAccNo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetNames();
        }
        private void btnDeposit_Click(object sender, RoutedEventArgs e)
        {
            int accno = int.Parse(cboAccNo.SelectedItem.ToString());
            decimal DAmount = decimal.Parse(txtDAmount.Text);
            decimal bal = decimal.Parse(txtbal.Text);
            decimal newamount = (DAmount + bal) * 100;

            dw.UpdateDepositDetails(newamount, DAmount, accno);

            MessageBox.Show("Deposit Successfull", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            txtDAmount.Clear();
            txtAccname.Clear();
            cboAccNo.Text = "";
        }



        void GetAccNo()
        {
            string select = "SELECT * FROM MyCustomer";

            SqlCommand cmd = new SqlCommand(select, dao.OpenCon());

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string acc = dr["AccountNo"].ToString();
                cboAccNo.Items.Add(acc);
            }
            dao.CloseCon();
        }

        void GetNames()
        {
            string select = "SELECT * FROM MyCustomer WHERE AccountNo = @accno";
            string AcNo = cboAccNo.SelectedItem.ToString();

            SqlCommand cmd = new SqlCommand(select, dao.OpenCon());
            cmd.Parameters.AddWithValue("@accno", AcNo);

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string fn = dr["Firstname"].ToString();
                string sn = dr["Surname"].ToString();
                decimal bal = decimal.Parse(dr["InitialBalance"].ToString()) / 100;
                txtAccname.Text = fn + " " + sn;
                txtbal.Text = bal.ToString();

            }

            dao.CloseCon();
        }

       
    }
}
