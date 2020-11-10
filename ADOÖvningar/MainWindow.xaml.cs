using ADOÖvningar.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;

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

        private int CurrentUser;

        private void searchBar_GotFocus(object sender, RoutedEventArgs e)
        {
            searchBar.Text = "";
        } //Färdig

        private void search_Click(object sender, RoutedEventArgs e)
        {
            string option = "AdsSearchOne";
            int catID = Convert.ToInt32(categoriesBox.SelectedValue);

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@SearchWord", searchBar.Text));
            parameters.Add(new SqlParameter("@CatagoryID", catID));
            parameters.Add(new SqlParameter("@Sorting", SearchSort.SelectedValue));

            if(Convert.ToInt32(categoriesBox.SelectedValue) != 5 && searchBar.Text != "" && searchBar.Text != "Sök annons") {
                option = "AdsSearchBoth";
            }

            PopulateDataGrid(DBConnection.GetAds(option, parameters));

            lblShowSelectionID.Content = searchBar.Text;

        } //Färdig

        private void categoriesBox_Loaded(object sender, RoutedEventArgs e)
        {
            categoriesBox.ItemsSource = CategoryRepo.GetAllCatagories().DefaultView;
        } //Färdig

        private void register_Click(object sender, RoutedEventArgs e)
        {
            MakeNewLogin newLogin = new MakeNewLogin();
            newLogin.Show();
        } // Färdig

        private void logIn_Click(object sender, RoutedEventArgs e)
        {
            string username = userName.Text;
            string password = passWord.Password.ToString();

            CurrentUser = UserRepo.UserLogin(username, password);

            if (CurrentUser != 0)
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
        } //Färdig

        private void logOut_Click(object sender, RoutedEventArgs e)
        {
            loggedOut.Visibility = Visibility.Visible;
            loggedIn.Visibility = Visibility.Hidden;
        } //Färdig

        private void makeNewAd_Click(object sender, RoutedEventArgs e)
        {
            MakeNewAd newAd = new MakeNewAd();
            newAd.Show();
        } //Färdig form, se MakeNewAd

        private void categoriesBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            lblShowSelectionID.Content = categoriesBox.SelectedValue.ToString();
        }

        private void advertWindow_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateDataGrid(AdvertRepo.GetAllAds());
        }

        private void PopulateDataGrid(DataTable data)
        {
            advertWindow.ItemsSource = data.DefaultView;
        }

        private void advertWindow_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            DataRowView rowView = dataGrid.SelectedItem as DataRowView;
            string cellValue = rowView.Row[0].ToString();

            lblShowSelectionID.Content = cellValue;
        }

        private void SearchSort_Loaded(object sender, RoutedEventArgs e)
        {
            
            List < SortingStatement > sortings = new List<SortingStatement>
            {
            new SortingStatement{SortingName = "Sortera datum fallande", SortingValue = "AdDate desc" },
            new SortingStatement{SortingName = "Sortera datum stigande", SortingValue = "AdDate asc" },
            new SortingStatement{SortingName = "Sortera pris fallande", SortingValue = "AdPrice desc" },
            new SortingStatement{SortingName = "Sortera pris stigande", SortingValue = "AdPrice asc" },
            };
            SearchSort.ItemsSource = sortings;
        }
    }
}
