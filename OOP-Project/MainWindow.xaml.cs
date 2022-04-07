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
using System.Data;
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

        //DAO dao = new DAO();
        HashPass hp = new HashPass();
        Random r = new Random();
        LoginCheck lc = new LoginCheck();
        //SqlDataReader dr;

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            int captchaCode = r.Next(100000, 999999);
            txtCaptcha.Text = captchaCode.ToString();

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            //if (txtCaptchaCheck.Text == txtCaptcha.Text)
            //{
            //    string user = txtUsername.Text;
            //    //string pass = hp.PassHash(pbPassword.Password.ToString()); //encryption --already commented
            //    string pass = pbPassword.Password.ToString();

            //    pass = hp.PassHash(pbPassword.Password.ToString());

            //    bool readSuccess = lc.CheckUserLogin(user, pass);

            //    if (readSuccess)
            //    {
            //        ActionMenu am = new ActionMenu();
            //        am.Owner = this;
            //        am.Show();
            //        this.Hide();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Incorrect Details", "Login Error", MessageBoxButton.OK);
            //        pbPassword.Clear();
            //        txtCaptcha.Clear();
            //        txtCaptchaCheck.Clear();
            //        int captchaCode = r.Next(100000, 999999);
            //        txtCaptcha.Text = captchaCode.ToString();
            //    }
            //}else
            //{
            //    MessageBox.Show("Incorrect Details", "Login Error", MessageBoxButton.OK);
            //    pbPassword.Clear();
            //    txtCaptcha.Clear();
            //    txtCaptchaCheck.Clear();
            //    int captchaCode = r.Next(100000, 999999);
            //    txtCaptcha.Text = captchaCode.ToString();
            //}


            ActionMenu am = new ActionMenu();
            am.Owner = this;
            am.Show();
            this.Hide();
        }

        private void btnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            CreateUser cu = new CreateUser();
            cu.Owner = this;
            cu.ShowDialog();
            //this.Close();
          
        }

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


    }
}
