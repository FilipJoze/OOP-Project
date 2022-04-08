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
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        Deposit_Withdraw dw = new Deposit_Withdraw();
        FundTransfer ft = new FundTransfer();
        System.Windows.Controls.DataGrid dgv = new System.Windows.Controls.DataGrid();

        private void tabTransfer_Loaded(object sender, RoutedEventArgs e)
        {
            GetAccNoForSenderReciever();
        }

        private void cboFromAccNo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetSenderNames();
        }

        private void cboToAccNo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetRecieverNames();
        }
        private void btnTransfer_Click(object sender, RoutedEventArgs e)
        {

            if (cboFromAccNo.SelectedItem != cboToAccNo.SelectedItem)
            {
                if (int.TryParse(txtTransferAmount.Text, out int test) == true)
                {
                    if(cboFromAccNo.SelectedItem != null && cboToAccNo.SelectedItem != null && txtFromBalance.Text != null
                        && txtTransferAmount.Text != null)
                    {
                        int SenderAccNo = int.Parse(cboFromAccNo.SelectedItem.ToString());
                        decimal SBalance = decimal.Parse(txtFromBalance.Text);
                        decimal ODLimit = decimal.Parse(txtOverdraftLimit.Text);
                        decimal TAmount = decimal.Parse(txtTransferAmount.Text);

                        int RecieverAccNo = int.Parse(cboToAccNo.SelectedItem.ToString());
                        int SortCode = int.Parse(txtRSortCode.Text);


                        string date = DateTime.Now.ToString();

                        Random r = new Random();
                        int RNo = r.Next(1000, 1000000);

                        decimal Limit = SBalance + ODLimit;

                        decimal SavingsDeductingam = SBalance - TAmount;
                        decimal CurrentDeductingam = Limit - TAmount;
                        decimal CurrentRemainingBalance = SBalance - Limit;

                        if (txtAccountType.Text == "Savings Account" && SortCode == 101010)
                        {
                            if (txtAccountType.Text == "Savings Account" && SavingsDeductingam == 0)
                            {
                                DialogResult result = System.Windows.Forms.MessageBox.Show("Your Account Balance will be 0", "Warning", (MessageBoxButtons)MessageBoxButton.OKCancel, (MessageBoxIcon)MessageBoxImage.Information);

                                if (result == System.Windows.Forms.DialogResult.OK)
                                {

                                    SenderTransfer();
                                    RecieverTransfer();
                                    GetSenderNames();

                                    ft.ViewTransactions(SenderAccNo, RecieverAccNo, SortCode, TAmount, RNo, date);
                                    System.Windows.MessageBox.Show("Your Transfer is Successfull", "Success Transfer", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Information);


                                }
                                else
                                {
                                    System.Windows.Forms.MessageBox.Show("Transfer Aborted", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else if (TAmount <= Limit && TAmount > 0)
                            {
                                SenderTransfer();
                                RecieverTransfer();
                                GetSenderNames();

                                ft.ViewTransactions(SenderAccNo, RecieverAccNo, SortCode, TAmount, RNo, date);
                                System.Windows.MessageBox.Show("Your Transfer is Successfull", "Success Transfer", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Information);


                            }
                            else if(TAmount <= 0)
                            {
                                System.Windows.MessageBox.Show($"Amount should be greater than 0", "Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Warning);
                            }
                            else
                            {
                                System.Windows.MessageBox.Show($"The Transfer Limit is {Limit}", "Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Warning);
                            }

                        }
                        else if (txtAccountType.Text == "Current Account" && CurrentDeductingam == 0)
                        {
                            DialogResult result = System.Windows.Forms.MessageBox.Show($"Your Account Balance will be {CurrentRemainingBalance}", "Warning", (MessageBoxButtons)MessageBoxButton.OKCancel, (MessageBoxIcon)MessageBoxImage.Information);

                            if (result == System.Windows.Forms.DialogResult.OK)
                            {

                                SenderTransfer();
                                RecieverTransfer();
                                GetSenderNames();

                                ft.ViewTransactions(SenderAccNo, RecieverAccNo, SortCode, TAmount, RNo, date);
                                System.Windows.MessageBox.Show("Your Transfer is Successfull", "Success Transfer", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Information);


                            }
                            else
                            {
                                System.Windows.Forms.MessageBox.Show("Withdrawal Aborted", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else if (txtAccountType.Text == "Savings Account" && SortCode != 101010)
                        {
                            System.Windows.MessageBox.Show("This Transfer cannot be made as it is a Savings Account", "Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Information); ;
                            txtRSortCode.Clear();
                        }
                        else if (txtAccountType.Text == "Current Account" && TAmount <= Limit && TAmount > 0)
                        {
                            SenderTransfer();
                            RecieverTransfer();
                            GetSenderNames();

                            ft.ViewTransactions(SenderAccNo, RecieverAccNo, SortCode, TAmount, RNo, date);
                            System.Windows.MessageBox.Show("Your Transfer is Successfull", "Success Transfer", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Information);
                        }
                        else if (TAmount > Limit)
                        {
                            System.Windows.MessageBox.Show($"The Transfer Limit is {Limit}", "Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("All fields are mandatory!", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }
                else
                {
                    System.Windows.MessageBox.Show("Invalid Format", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                   
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Cannot transfer to yourself", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                
            }
        }
        private void tabWithdraw_Loaded(object sender, RoutedEventArgs e)
        {
            GetAccNoWithdrawl();
        }

        private void cboAccNoW_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetNamesWithdrawl();
        }


        // This Code is for Withdraw Funds
        private void btnWithdraw_Click(object sender, RoutedEventArgs e)
        {
            

            if (decimal.TryParse(txtWAmount.Text, out decimal test) == true && cboAccNoW.SelectedItem != null)
            {
                int accno = int.Parse(cboAccNoW.SelectedItem.ToString());
                decimal WAmount = decimal.Parse(txtWAmount.Text);
                decimal bal = decimal.Parse(txtbalw.Text);
                decimal newamount = (bal - WAmount) * 100;

                if (WAmount != 0 && WAmount > 0)
                {
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

                            }
                            else
                            {
                                System.Windows.Forms.MessageBox.Show("Withdrawl Aborted", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }
                        else if (newamount != 0)
                        {
                            dw.UpdateDepositDetails(newamount, WAmount, accno);
                            System.Windows.Forms.MessageBox.Show("Withdrawal Successful", "Success", (MessageBoxButtons)MessageBoxButton.OK, (MessageBoxIcon)MessageBoxImage.Information);

                            txtWAmount.Clear();
                            txtbalw.Clear();
                            txtName.Clear();
                            GetNamesWithdrawl();

                        }
                    }
                    else
                    {
                        System.Windows.MessageBox.Show($"Withdrawal Amount cannot excced your balance: {bal} \nPlease Try Again!", "Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
                    }
                }
                else
                {
                    System.Windows.MessageBox.Show($"Withdrawal Amount should be greater than zero", "Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Invalid Format", "Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
            }
        }
        

        // This code is for Deposit Funds
        private void tabDeposit_Loaded(object sender, RoutedEventArgs e)
        {
            GetAccNoDeposit();
        }

        private void cboAccNoD_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetNamesDeposit();
            
        }
        private void btnDeposit_Click(object sender, RoutedEventArgs e)
        {

            if (decimal.TryParse(txtDAmount.Text, out decimal test) == true && cboAccNoD.SelectedItem != null)
            {
                int accno = int.Parse(cboAccNoD.SelectedItem.ToString());
                decimal DAmount = decimal.Parse(txtDAmount.Text);
                decimal bal = decimal.Parse(txtbal.Text);
                decimal newamount = (DAmount + bal) * 100;
                if (DAmount > 0)
                {

                    dw.UpdateDepositDetails(newamount, DAmount, accno);

                    System.Windows.MessageBox.Show("Deposit Successfull", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    txtDAmount.Clear();
                    GetNamesDeposit();
                }
                else 
                {
                    System.Windows.MessageBox.Show("Amount should be greater than zero", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {

                System.Windows.MessageBox.Show("Invalid or Missing Information", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
        /******************************************************************************/


        // This code is for method of Deposit Funds
        void GetAccNoDeposit()
        {
            string select = "SELECT * FROM Accounts";

            SqlCommand cmd = new SqlCommand(select, dao.OpenCon());

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string acc = dr["AccountId"].ToString();
                cboAccNoD.Items.Add(acc);
            }
            dao.CloseCon();
        }

        void GetNamesDeposit()
        {
            string select = "SELECT * FROM Accounts WHERE AccountId = @accno";
            string AcNo = cboAccNoD.SelectedItem.ToString();

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

        /* *********************************************************************** */

        // These are methods for Withdraw Funds

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
                txtbalw.Text = bal.ToString();

            }

            dao.CloseCon();
        }


        /***************************************************************************/


        // These are methods for Transfer Funds

        void SenderTransfer()
        {

            int accno = int.Parse(cboFromAccNo.SelectedItem.ToString());
            decimal TAmount = decimal.Parse(txtTransferAmount.Text);
            decimal bal = decimal.Parse(txtFromBalance.Text);
            decimal newamount = (bal - TAmount) * 100;


            decimal ODLimit = decimal.Parse(txtOverdraftLimit.Text);
            decimal Limit = bal + ODLimit;


            if (TAmount <= Limit)
            {

                ft.UpdateTransferDetails(newamount, TAmount, accno);

            }
            else
            {
                System.Windows.MessageBox.Show($"This Transfer cannot excced your balance: {bal} \nPlease Try Again!", "Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
            }


        }

        void RecieverTransfer()
        {
            int accno = int.Parse(cboToAccNo.SelectedItem.ToString());
            decimal RAmount = decimal.Parse(txtTransferAmount.Text);
            decimal bal = decimal.Parse(txtFromBalance.Text);
            decimal newamount = (GetRecieverBalance(bal) + RAmount) * 100;


            ft.UpdateTransferDetails(newamount, RAmount, accno);

            txtTransferAmount.Clear();
            txtFromBalance.Clear();
            txtToAccName.Clear();
            //cboToAccNo.Text = "";
            txtAccountType.Clear();
            txtRSortCode.Clear();

        }

        void GetAccNoForSenderReciever()
        {
            string select = "SELECT * FROM Accounts";

            SqlCommand cmd = new SqlCommand(select, dao.OpenCon());

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string acc = dr["AccountId"].ToString();
                cboFromAccNo.Items.Add(acc);
                cboToAccNo.Items.Add(acc);
            }
            dao.CloseCon();
        }



        void GetSenderNames()
        {
            string select = "SELECT * FROM Accounts WHERE AccountId = @accno";
            string AcNo = cboFromAccNo.SelectedItem.ToString();

            SqlCommand cmd = new SqlCommand(select, dao.OpenCon());
            cmd.Parameters.AddWithValue("@accno", AcNo);

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string fn = dr["Firstname"].ToString();
                string sn = dr["Surname"].ToString();
                decimal bal = decimal.Parse(dr["InitialBalance"].ToString()) / 100;
                decimal OverDLimit = decimal.Parse(dr["OverdraftLimit"].ToString());
                string AccType = dr["AccountType"].ToString();
                txtFromAccName.Text = fn + " " + sn;
                txtFromBalance.Text = bal.ToString();
                txtOverdraftLimit.Text = OverDLimit.ToString();
                txtAccountType.Text = AccType;

            }

            dao.CloseCon();
        }

        void GetRecieverNames()
        {
            string select = "SELECT * FROM Accounts WHERE AccountId = @accno";
            string AcNo = cboToAccNo.SelectedValue.ToString();

            SqlCommand cmd = new SqlCommand(select, dao.OpenCon());
            cmd.Parameters.AddWithValue("@accno", AcNo);

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string fn = dr["Firstname"].ToString();
                string sn = dr["Surname"].ToString();
               // decimal bal = decimal.Parse(dr["InitialBalance"].ToString()) / 100;
                int SCode = int.Parse(dr["SortCode"].ToString());
                txtToAccName.Text = fn + " " + sn;
                txtRSortCode.Text = SCode.ToString();
            }

            dao.CloseCon();
        }

        public decimal GetRecieverBalance(decimal bal)
        {

            string select = "SELECT * FROM Accounts WHERE AccountId = @accno";
            string AcNo = cboToAccNo.SelectedItem.ToString();

            SqlCommand cmd = new SqlCommand(select, dao.OpenCon());
            cmd.Parameters.AddWithValue("@accno", AcNo);

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                bal = decimal.Parse(dr["InitialBalance"].ToString()) / 100;
                txtFromBalance.Text = bal.ToString();

            }

            dao.CloseCon();

            return bal;
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefreshGrid();
        }

        private void SearchByID(int search)
        {
            da = new SqlDataAdapter();
            dt = new DataTable();
            System.Windows.Controls.DataGrid dgv = new System.Windows.Controls.DataGrid();

            SqlCommand cmd = dao.OpenCon().CreateCommand();
            cmd.CommandText = "uspFetchTransactions";
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@transactionId", search);
            dao.OpenCon();
            da.SelectCommand = cmd;
            da.Fill(dt);
            dgvHistory.ItemsSource = dt.DefaultView;
            dao.CloseCon();


        }

        private void PopulateGrid()
        {
            da = new SqlDataAdapter();
            dt = new DataTable();
            System.Windows.Controls.DataGrid dgv = new System.Windows.Controls.DataGrid();

            SqlCommand cmd = dao.OpenCon().CreateCommand();
            cmd.CommandText = "uspFetchAllTransactions";
            cmd.CommandType = CommandType.StoredProcedure;


            dao.OpenCon();
            da.SelectCommand = cmd;
            da.Fill(dt);
            dgvHistory.ItemsSource = dt.DefaultView;
            dao.CloseCon();
        }

        private void tabHistory_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            if (txtSearch.Text == "")
            {
                PopulateGrid();
            }
            int search = 1;
            if (int.TryParse(txtSearch.Text, out search))
            {
                SearchByID(search);
            }
        }

        //private void cboAccNoW_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        //{

        //}
    }
}
