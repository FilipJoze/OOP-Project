using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using BIZ;
using DAL;
using System.Xml;
using System.Xml.Serialization;

namespace OOP_Project
{
    /// <summary>
    /// Interaction logic for Serialiser.xaml
    /// </summary>
    public partial class Serialiser : Window
    {
        SqlDataReader dr;
        DAO dao = new DAO();

        public Serialiser()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            GetAccNo();
        }

        private void cboAccNo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetDetails();
        }

        private void btnSerialise_Click(object sender, RoutedEventArgs e)
        {
            if (cboAccNo.SelectedItem != null)
            {
                int AccNo = int.Parse(cboAccNo.SelectedItem.ToString());
                string fn = txtfn.Text;
                string sn = txtsn.Text;
                string email = txtemail.Text;
                string ph = txtph.Text;
                string add1 = txtadd1.Text;
                string add2 = txtadd2.Text;
                string city = txtct.Text;
                string cy = txtcy.Text;
                string AccType = txtAccType.Text;
                int SCode = int.Parse(txtSCode.Text);
                int bal = int.Parse(txtBal.Text);
                decimal am = decimal.Parse(txtam.Text);
                decimal ODraft = decimal.Parse(txtODLimit.Text);

                XMLConversion m = new XMLConversion();

                XmlSerializer serialize;
                XmlWriter writer;

                m.AccNo = AccNo;
                m.Firstname = fn;
                m.Surname = sn;
                m.Email = email;
                m.Phone = ph;
                m.Address_1 = add1;
                m.Address_2 = add2;
                m.City = city;
                m.County = cy;
                m.Acc_type = AccType;
                m.SortCode = SCode;
                m.Initial_balance = bal;
                m.Amount = am;
                m.overdraft = ODraft;


                string filepath = @"C:\Users\Filip\source\repos\OOP-Project\OOP-Project\XML\account-" + AccNo + ".xml";

                serialize = new XmlSerializer(typeof(XMLConversion));
                writer = XmlWriter.Create(filepath);
                serialize.Serialize(writer, m);

                writer.Close();

                System.Windows.MessageBox.Show("Serialization Completed Successfully", "Success", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Information);


                txtfn.Text = "";
                txtsn.Text = "";
                txtemail.Text = "";
                txtph.Text = "";
                txtadd1.Text = "";
                txtadd2.Text = "";
                txtct.Text = "";
                txtcy.Text = "";
                txtAccType.Text = "";
                txtSCode.Text = "";
                txtBal.Text = "";
                txtam.Text = "";
                txtODLimit.Text = "";
            }
            else
            {
                System.Windows.MessageBox.Show("Please select an account", "Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Warning);
            }
        }

        void GetDetails()
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
                string email = dr["Email"].ToString();
                string ph = dr["Phone"].ToString();
                string add1 = dr["Address1"].ToString();
                string add2 = dr["Address2"].ToString();
                string city = dr["City"].ToString();
                string cy = dr["County"].ToString();
                string AccType = dr["AccountType"].ToString();
                int SCode = int.Parse(dr["SortCode"].ToString());
                int bal = int.Parse(dr["InitialBalance"].ToString()) / 100;
                decimal am = decimal.Parse(dr["Amount"].ToString());
                decimal ODraft = decimal.Parse(dr["OverdraftLimit"].ToString());


                txtfn.Text = fn;
                txtsn.Text = sn;
                txtemail.Text = email;
                txtph.Text = ph;
                txtadd1.Text = add1;
                txtadd2.Text = add2;
                txtct.Text = city;
                txtcy.Text = cy;
                txtAccType.Text = AccType;
                txtSCode.Text = SCode.ToString();
                txtBal.Text = bal.ToString();
                txtam.Text = am.ToString();
                txtODLimit.Text = ODraft.ToString();

            }

            dao.CloseCon();
        }

        void GetAccNo()
        {

            SqlCommand cmd = dao.OpenCon().CreateCommand();

            cmd.CommandText = "uspShowAccounts";
            cmd.CommandType = CommandType.StoredProcedure;

            dao.OpenCon();

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string acc = dr["AccountId"].ToString();
                cboAccNo.Items.Add(acc);

            }
            dao.CloseCon();
        }

       
    }
}
