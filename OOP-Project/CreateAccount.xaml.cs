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
            try
            { 

                string fn = txtFirstName.Text;
                string sn = txtSurname.Text;
                string em = txtEmail.Text;
                string po = txtPhone.Text;
                string add1 = txtAdd1.Text;
                string add2 = txtAdd2.Text;
                string city = cmbCounty.SelectedItem.ToString();
                string cy = txtCity.Text;
                int scode = int.Parse(txtSortCode.Text);
                int iBal = int.Parse(txtBalance.Text);
                

                string accType = null;
                int sc = int.Parse(txtSortCode.Text);


                int ib = int.Parse(txtBalance.Text);
                decimal amount = 0M;
                decimal odraft = 0M;
                //int test2;
                //string Message = "500";
                //bool success = int.TryParse(txtInitialBal.Text, out ib);

                //if(success == true)
                //{
                //    txtInitialBal.Text = ib.ToString();
                //}
                //else
                //{
                //    MessageBox.Show("Incorrect");
                //}

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
                
                upa.UploadBankAccount(fn, sn, em, po, add1, add2, city, cy, accType, scode, iBal, odraft);
                MessageBox.Show("Bank Customer Was Created", "Success", MessageBoxButton.OK);

                txtSortCode.Clear();
                txtBalance.Clear();
                txtOverdraft.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.Close();
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
