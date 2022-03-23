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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OOP_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            UserLogin ul = new UserLogin();
            ul.Owner = this;
            this.Hide();
            ul.ShowDialog();
        }

        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            AdminLogin al = new AdminLogin();
            al.Owner = this;
            this.Hide();
            al.ShowDialog();
        }
    }
}
