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

namespace OOP_Project
{
    /// <summary>
    /// Interaction logic for CreateAccount.xaml
    /// </summary>
    public partial class CreateAccount : Window
    {
       
        public CreateAccount()
        {
            
            //cmbCounty.ItemsSource = Enum.GetNames(typeof(BIZ.Counties));
            //test
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            ////bool for valid password 
            //bool passwordValid = false;

            ////rules for password
            //int minUpper = 1;
            //int minLower;
            //int minLength = 7;
            //string allowedSpecials = "@#/.!";
            ////gap
            ////
            ////
            ////
            ////
            ////

            //string createuser = txtCreateUser.Text;

            //string createpassword = pbCreatePass.Password.ToString();
            //char[] characters = createpassword.ToCharArray();
            ////current variables
            //int upper = 0;
            //int character = 0;
            //int length = createpassword.Length;
            //int illegalCharacters = 0;

            ////checks the password
            //foreach (char enteredCharacters in characters)
            //{
            //    if (char.IsUpper(enteredCharacters))
            //    {
            //        upper = upper + 1;

            //    }
            //    else if (char.IsLower(enteredCharacters))
            //    {

            //    }
            //    else if (allowedSpecials.Contains(enteredCharacters.ToString())) //needs double check
            //    {
            //        character = character + 1;

            //    }
            //    else
            //    {
            //        illegalCharacters = illegalCharacters + 1;

            //    }

            //}
            //if (upper < minUpper || length < minLength || illegalCharacters >= 1)
            //{
            //    MessageBox.Show("Insufficient Password Criteria", "Re-Enter Password", MessageBoxButton.OK);
            //    passwordValid = false;
            //}
            //else
            //{
            //    MessageBox.Show("Password Criteria Met", "Password Choice Good", MessageBoxButton.OK);
            //    passwordValid = true;
            //    createpassword = hp.PassHash(pbCreatePass.Password.ToString()); //encrypts the accepted password under the criterias
            //    SqlCommand cmd = dao.OpenCon().CreateCommand();
            //    cmd.CommandText = "uspCreateUser";
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@bankuser", @createuser);
            //    cmd.Parameters.AddWithValue("@bankpassword", @createpassword);

            //    dao.OpenCon();
            //    cmd.ExecuteNonQuery();
            //    dao.CloseCon();
            //    MessageBox.Show("Admin Created", "Information", MessageBoxButton.OK);

            //    txtCreateUser.Clear();
            //    pbCreatePass.Clear();

            //}
            //if (pbPassCheck.Password.ToString() != "")
            //{
            //    if (passwordValid)
            //    {
            //        statusText.Text = "";

            //    }
            //    else
            //    {
            //        statusText.Text = "Invalid Password";
            //    }
            //}

            this.Close();
        }
    }
}
