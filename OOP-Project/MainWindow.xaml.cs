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
using BIZ;
using DAL;
using System.Data.SqlClient;

namespace OOP_Project
{
    /// <summary>
    /// Interaction logic for UserLogin.xaml
    /// </summary>
    public partial class UserLogin : Window
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        DAO dao = new DAO();
        HashPass hp = new HashPass();
        SqlDataReader dr;

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            ActionMenu am = new ActionMenu();
            am.Owner = this;
            this.Hide();
            am.ShowDialog();

            //string bankuser = txtUsername.Text;
            //string bankpass = hp.PassHash(pbPassword.Password.ToString()); // encryption

            //SqlCommand cmd = dao.OpenCon().CreateCommand();
            //cmd.CommandText = "uspUserLogin";
            //cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("@username", bankuser);
            //cmd.Parameters.AddWithValue("@staffpass", bankpass);

            //dao.OpenCon();
            //dr = cmd.ExecuteReader();
            //if (dr.Read())
            //{
            //    Menu mainmenu = new Menu();
            //    mainmenu.Show();
            //}
            //else
            //{
            //    MessageBox.Show("Incorrect Details", "Login Error", MessageBoxButton.OK);

            //}
            //dao.CloseCon();

        }

        private void btnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            CreateAccount ca = new CreateAccount();
            ca.Owner = this;
            this.Hide();
            ca.ShowDialog();
        }

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
