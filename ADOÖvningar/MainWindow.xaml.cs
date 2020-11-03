using System.Windows;

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
            string searchstring = searchBar.Text;
            string searchCategory = categories.Text;
        }

        private void categories_GotFocus(object sender, RoutedEventArgs e)
        {
            categories.Text = "";
        }

        private void register_Click(object sender, RoutedEventArgs e)
        {
            MakeNewLogin newLogin = new MakeNewLogin();
            newLogin.Show();
        }

        private void logIn_Click(object sender, RoutedEventArgs e)
        {
            string devUserName = "aaa";
            string devPassword = "111";

            string username = userName.Text;
            string password = passWord.Password.ToString();

            if(username == devUserName && password == devPassword)
            {
                loggedIn.Visibility = Visibility.Visible;
                loggedOut.Visibility = Visibility.Hidden;
                errormessage.Visibility = Visibility.Collapsed;
                userName.Text = "";
                passWord.Password = "";
            }
            else
            {
                errormessage.Text = "Fel lösenord eller användarnamn. Försök igen.";
                errormessage.Visibility = Visibility.Visible;
                passWord.Clear();
                passWord.Focus();
            }
        }

        private void logOut_Click(object sender, RoutedEventArgs e)
        {
            loggedOut.Visibility = Visibility.Visible;
            loggedIn.Visibility = Visibility.Hidden;
        }

        private void makeNewAd_Click(object sender, RoutedEventArgs e)
        {
            MakeNewAd newAd = new MakeNewAd();
            newAd.Show();
        }
    }
}
