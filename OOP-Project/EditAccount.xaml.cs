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

namespace OOP_Project
{
    /// <summary>
    /// Interaction logic for EditAccount.xaml
    /// </summary>
    public partial class EditAccount : Window
    {
        
        public EditAccount()
        {
            InitializeComponent();
        }

        DAO dao = new DAO();
        SearchAccountID sacid = new SearchAccountID();
        SqlDataReader dr;
        

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            string AcNo = txtAccNumber.Text;
            SqlCommand cmd = dao.OpenCon().CreateCommand();
            cmd.CommandText = "uspSearch";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@searchacc", AcNo);

            cmd.ExecuteNonQuery();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string fn = dr["Firstname"].ToString();
                string sn = dr["Surname"].ToString();
                string email = dr["Email"].ToString();
                string ph = dr["Phone"].ToString();
                string add1 = dr["Address1"].ToString();
                string add2 = dr["Address2"].ToString();
                string city = dr["City"].ToString();
                string cy = dr["County"].ToString();
                txtFirstName.Text = fn;
                txtSurname.Text = sn;
                txtEmail.Text = email;
                txtPhone.Text = ph;
                txtAdd1.Text = add1;
                txtAdd2.Text = add2;
                txtCity.Text = city;
                cmbCounty.Text = cy;

            }
            else
            {
                MessageBox.Show("Account not found", "Try Again", MessageBoxButton.OK);
            }

            dao.CloseCon();


        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            cmbCounty.ItemsSource = Enum.GetValues(typeof(Counties));
        }
    }
    }

