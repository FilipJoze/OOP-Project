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
using BIZ;

namespace OOP_Project
{
    /// <summary>
    /// Interaction logic for CreateUser.xaml
    /// </summary>
    public partial class CreateUser : Window
    {
        CreateUserAccount cua = new CreateUserAccount();
        HashPass hp = new HashPass();

        public CreateUser()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {

            //bool for valid password 
            bool passwordValid = false;

            //rules for password
            int minUpper = 1;
            int minLower;
            int minLength = 7;
            string allowedSpecials = "@#/.!";
            //

            string createuser = txtUsername.Text;

            string createpassword = pbPassword.Password.ToString();
            char[] characters = createpassword.ToCharArray();
            //current variables
            int upper = 0;
            int character = 0;
            int length = createpassword.Length;
            int illegalCharacters = 0;

            //checks the password
            foreach (char enteredCharacters in characters)
            {
                if (char.IsUpper(enteredCharacters))
                {
                    upper = upper + 1;

                }
                else if (char.IsLower(enteredCharacters))
                {

                }
                else if (allowedSpecials.Contains(enteredCharacters.ToString())) //needs double check
                {
                    character = character + 1;

                }
                else
                {
                    illegalCharacters = illegalCharacters + 1;

                }

            }
            if (upper < minUpper || length < minLength || illegalCharacters >= 1)
            {
                MessageBox.Show("Insufficient Password Criteria", "Re-Enter Password", MessageBoxButton.OK);
                passwordValid = false;
            }
            else
            {
                MessageBox.Show("Password Criteria Met", "Password Choice Good", MessageBoxButton.OK);
                //
                passwordValid = true;
                createpassword = hp.PassHash(pbPassword.Password.ToString()); //encrypts the accepted password under the criterias
                cua.CreateUser(txtUsername.Text, createpassword);

                MessageBox.Show("Admin Created", "Information", MessageBoxButton.OK);

                this.Close();

            }
            if (pbPasswordCheck.Password.ToString() != "")
            {
                if (passwordValid)
                {
                    txtStatus.Text = "";
                    this.Close();
                }
                else
                {
                    txtStatus.Text = "Invalid Password";
                }
            }
        }

        private void pbPasswordCheck_TextInput(object sender, TextCompositionEventArgs e)
        {
         

        }

        private void pbPasswordCheck_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void cbPasswordCheck_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void pbPasswordCheck_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (pbPassword.Password.ToString() != pbPasswordCheck.Password.ToString())
            {

                cbPasswordCheck.IsChecked = false;
                btnCreate.IsEnabled = false;

            }
            else
            {
                btnCreate.IsEnabled = true;
                cbPasswordCheck.IsChecked = true;
            }
        }
    }
}

