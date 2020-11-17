using ADOÖvningar.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            AdvertTable = AdvertRepo.GetAllAds();
        }

        private int CurrentUser;
        private string username;
        private DataTable AdvertTable;

        private void searchBar_GotFocus(object sender, RoutedEventArgs e)
        {
            searchBar.Text = "";
        } //Färdig

        private void advertWindow_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateDataGrid();
        }

        private void categoriesBox_Loaded(object sender, RoutedEventArgs e)
        {
            categoriesBox.ItemsSource = CategoryRepo.GetAllCatagories().DefaultView;
        } //Färdig

        private void SearchSort_Loaded(object sender, RoutedEventArgs e)
        {

            List<SortingStatement> sortings = new List<SortingStatement>
            {
            new SortingStatement{SortingName = "Sortera datum fallande", SortingValue = "AdDate desc" },
            new SortingStatement{SortingName = "Sortera datum stigande", SortingValue = "AdDate asc" },
            new SortingStatement{SortingName = "Sortera pris fallande", SortingValue = "AdPrice desc" },
            new SortingStatement{SortingName = "Sortera pris stigande", SortingValue = "AdPrice asc" },
            };
            SearchSort.ItemsSource = sortings;
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            string option = "AdsSearchOne";
            int catID = Convert.ToInt32(categoriesBox.SelectedValue);

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@SearchWord", searchBar.Text));
            parameters.Add(new SqlParameter("@CatagoryID", catID));
            parameters.Add(new SqlParameter("@Sorting", SearchSort.SelectedValue));

            if (Convert.ToInt32(categoriesBox.SelectedValue) != 5 && searchBar.Text != "" && searchBar.Text != "Sök annons")
            {
                option = "AdsSearchBoth";
            }
            DBConnection.GetAds(option, parameters);
            PopulateDataGrid();

            lblShowSelectionID.Content = searchBar.Text;

        } //Färdig

        private void register_Click(object sender, RoutedEventArgs e)
        {
            MakeNewLogin newLogin = new MakeNewLogin();
            newLogin.Show();
        } // Färdig

        private void logIn_Click(object sender, RoutedEventArgs e)
        {
            username = userName.Text;
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
            MakeNewAd newAd = new MakeNewAd(CurrentUser);
            newAd.Show();
            PopulateDataGrid();
        } //Färdig form, se MakeNewAd

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (advertWindow.SelectedIndex > -1)
            {
                AdvertRepo.EditAd(AdvertTable.Rows[advertWindow.SelectedIndex], CurrentUser);
            }
            PopulateDataGrid();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (advertWindow.SelectedIndex > -1)
            {
                AdvertRepo.DeleteAd(Convert.ToInt32(
                    AdvertTable.Rows[advertWindow.SelectedIndex]["AdID"]));
            }
            PopulateDataGrid();
        }

        private void advertWindow_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            advertWindow.SelectedIndex = -1;
        }

        private void SearchSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataView dv = AdvertTable.DefaultView;
            dv.Sort = SearchSort.SelectedValue.ToString();
            AdvertTable = dv.ToTable();
            advertWindow.ItemsSource = AdvertTable.DefaultView;
        }

        private void advertWindow_RowDetailsVisibilityChanged_1(object sender, DataGridRowDetailsEventArgs e)
        {

            int index = advertWindow.SelectedIndex;
            if (index != -1)
            {
                string AdOwner = AdvertTable.Rows[index]["AdOwner"].ToString();

                if (AdOwner != username)
                {
                    btnDelete.IsEnabled = false;
                    btnEdit.IsEnabled = false;
                }
                else
                {
                    btnDelete.IsEnabled = true;
                    btnEdit.IsEnabled = true;
                }
            }
        }

        public void PopulateDataGrid()
        {
            DataView dv = AdvertRepo.GetAllAds().DefaultView;
            dv.Sort = SearchSort.SelectedValue.ToString();
            AdvertTable = dv.ToTable();
            advertWindow.ItemsSource = AdvertTable.DefaultView;
        }
    }
}
