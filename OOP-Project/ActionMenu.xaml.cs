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

namespace OOP_Project
{
    /// <summary>
    /// Interaction logic for ActionMenu.xaml
    /// </summary>
    public partial class ActionMenu : Window
    {
        public ActionMenu()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem mi = new MenuItem();
            mi.ContextMenu.IsOpen = true;
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
