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
        UploadAccount upa = new UploadAccount();

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {

            if (txtFirstName.Text != null && txtSurname.Text != null && txtEmail.Text != null && txtPhone.Text != null &&
                txtAdd1.Text != null && txtAdd2.Text != null && txtCity.Text != null && cmbCounty.SelectedItem != null &&
                txtSortCode.Text != null && txtBalance.Text != null && (rdoCurrent.IsChecked == true || rdoSavings.IsChecked == true) && int.TryParse(txtBalance.Text, out int test) == true && int.TryParse(txtOverdraft.Text, out int test2) == true)
            {
                string fn = txtFirstName.Text;
                string sn = txtSurname.Text;
                string em = txtEmail.Text;
                string po = txtPhone.Text;
                string add1 = txtAdd1.Text;
                string add2 = txtAdd2.Text;
                string city = txtCity.Text;
                string cy = cmbCounty.SelectedItem.ToString();
                int scode = int.Parse(txtSortCode.Text);
                int iBal = int.Parse(txtBalance.Text) * 100;


                string accType = null;
                int sc = int.Parse(txtSortCode.Text);


                int ib = int.Parse(txtBalance.Text);
                decimal amount = 0M;
                decimal odraft = 0M;

                if (rdoSavings.IsChecked == true)
                {
                    accType = "Savings Account";

                    txtOverdraft.Text = odraft.ToString();
                }
                else if (rdoCurrent.IsChecked == true)
                {
                    accType = "Current Account";
                    odraft = decimal.Parse(txtOverdraft.Text);
                }

                upa.UploadBankAccount(fn, sn, em, po, add1, add2, city, cy, accType, scode, iBal, amount, odraft);
                MessageBox.Show("Bank Customer Was Created", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                txtSortCode.Clear();
                txtBalance.Clear();
                txtOverdraft.Clear();
                this.Close();

            }
            else
            {
                MessageBox.Show("Missing Or Invalid Information", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
           
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            cmbCounty.ItemsSource = Enum.GetValues(typeof(Counties));
        }

        private void rdoCurrent_Checked(object sender, RoutedEventArgs e)
        {
            txtOverdraft.IsEnabled = true;
        }

        private void rdoSavings_Checked(object sender, RoutedEventArgs e)
        {
            txtOverdraft.IsEnabled = false;
            txtOverdraft.Text = "0";
        }
    }
}
