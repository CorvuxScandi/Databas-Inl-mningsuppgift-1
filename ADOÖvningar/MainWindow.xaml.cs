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

namespace ADOÖvningar
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

        private void searchBar_GotFocus(object sender, RoutedEventArgs e)
        {
            searchBar.Text = "";
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {

        }

        private void categories_GotFocus(object sender, RoutedEventArgs e)
        {
            categories.Text = "";
        }

        private void register_Click(object sender, RoutedEventArgs e)
        {
            MakeNewLogin newLogin = new MakeNewLogin();
        }

        private void logIn_Click(object sender, RoutedEventArgs e)
        {
            loggedIn.Visibility = Visibility.Visible;
            loggedOut.Visibility = Visibility.Hidden;
        }

        private void logOut_Click(object sender, RoutedEventArgs e)
        {
            loggedOut.Visibility = Visibility.Visible;
            loggedIn.Visibility = Visibility.Hidden;
        }

        private void makeNewAd_Click(object sender, RoutedEventArgs e)
        {
            MakeNewAd newAd = new MakeNewAd();
        }
    }
}
