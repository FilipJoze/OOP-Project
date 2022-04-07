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
using BIZ;
using System.Windows.Forms;


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
        private void tabWithdraw_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void cboAccNoW_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
        private void btnWithdraw_Click(object sender, RoutedEventArgs e)
        {
            int accno = int.Parse(cboAccNo.SelectedItem.ToString());
            decimal WAmount = decimal.Parse(txtWAmount.Text);
            decimal bal = decimal.Parse(txtbalw.Text);
            decimal newamount = (bal - WAmount) * 100;

            if (WAmount <= bal)
            {
                if (newamount == 0)
                {

                    DialogResult result = System.Windows.Forms.MessageBox.Show("Your Account Balance will be 0", "Warning", (MessageBoxButtons)MessageBoxButton.OKCancel, (MessageBoxIcon)MessageBoxImage.Information);

                    if (result == System.Windows.Forms.DialogResult.OK)
                    {

                        dw.UpdateDepositDetails(newamount, WAmount, accno);
                        System.Windows.Forms.MessageBox.Show("Withdrawal Successful", "Success", (MessageBoxButtons)MessageBoxButton.OK, (MessageBoxIcon)MessageBoxImage.Information);

                        txtWAmount.Clear();
                        txtbalw.Text = "";
                        txtbalw.Text = "";
                        cboAccNo.Text = "";
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Withdrawl Aborted", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            else
            {
                System.Windows.MessageBox.Show($"Withdrawl Amount cannot excced your balance: {bal} \nPlease Try Again!", "Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
            }

            dw.UpdateDepositDetails(newamount, WAmount, accno);

            System.Windows.MessageBox.Show("Deposit Successfull", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void tabDeposit_Loaded(object sender, RoutedEventArgs e)
        {
            GetAccNoDeposit();
        }

        private void cboAccNo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetNamesDeposit();
        }
        private void btnDeposit_Click(object sender, RoutedEventArgs e)
        {
            int accno = int.Parse(cboAccNo.SelectedItem.ToString());
            decimal DAmount = decimal.Parse(txtDAmount.Text);
            decimal bal = decimal.Parse(txtbal.Text);
            decimal newamount = (DAmount + bal) * 100;

            dw.UpdateDepositDetails(newamount, DAmount, accno);

            System.Windows.MessageBox.Show("Deposit Successfull", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            txtDAmount.Clear();
            txtAccname.Clear();
            cboAccNo.Text = "";
        }



        void GetAccNoDeposit()
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

        void GetNamesDeposit()
        {
            string select = "SELECT * FROM Accounts WHERE AccountId = @accno";
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


        void GetAccNoWithdrawl()
        {
            string select = "SELECT * FROM Accounts";

            SqlCommand cmd = new SqlCommand(select, dao.OpenCon());

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string acc = dr["AccountId"].ToString();
                cboAccNoW.Items.Add(acc);
            }
            dao.CloseCon();
        }

        void GetNamesWithdrawl()
        {
            string select = "SELECT * FROM Accounts WHERE AccountId = @accno";
            string AcNo = cboAccNoW.SelectedItem.ToString();

            SqlCommand cmd = new SqlCommand(select, dao.OpenCon());
            cmd.Parameters.AddWithValue("@accno", AcNo);

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string fn = dr["Firstname"].ToString();
                string sn = dr["Surname"].ToString();
                decimal bal = decimal.Parse(dr["InitialBalance"].ToString()) / 100;
                txtName.Text = fn + " " + sn;
                txtbal.Text = bal.ToString();

            }

            dao.CloseCon();
        }

    }
}
