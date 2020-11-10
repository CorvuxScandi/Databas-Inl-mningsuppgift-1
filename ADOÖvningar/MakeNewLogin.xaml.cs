using ADOÖvningar.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace ADOÖvningar
{
    /// <summary>
    /// Interaction logic for MakeNewLogin.xaml
    /// </summary>
    public partial class MakeNewLogin : Window
    {
        public MakeNewLogin()
        {
            InitializeComponent();
        }

        private void makeNewUser_Click(object sender, RoutedEventArgs e)
        {
            if(newUsername.Text != "" && newPassword.Password != "")
            {
                if(UserRepo.FindUser(newUsername.Text)[0] != newUsername.Text)
                {
                    UserRepo.RegristerNewUser(newUsername.Text, newPassword.Password);
                    this.Close();
                }
                else
                {
                    txtNewUser.Text = "Detta användarnamn finns redan";
                    txtNewUser.Foreground = new SolidColorBrush(Colors.Red);
                }
            }
            else
            {
                txtNewUser.Text = "Du behöver fylla i båda fälten";
                txtNewUser.Foreground = new SolidColorBrush(Colors.Red);
            }
        }
    }
}
