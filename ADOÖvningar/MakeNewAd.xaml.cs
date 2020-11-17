using ADOÖvningar.Classes;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace ADOÖvningar
{
    /// <summary>
    /// Interaction logic for MakeNewAd.xaml
    /// </summary>
    public partial class MakeNewAd : Window
    {
        private int AdID;
        private int currentUserID;

        public MakeNewAd(int userID)
        {
            InitializeComponent();
            currentUserID = userID;
            AdID = 0;
        }
        public MakeNewAd(int adID, string AdTitel, float AdPrice, string AdDescription, object AdCategory, int user)
        {
            InitializeComponent();
            currentUserID = user;
            txtNewTitle.Text = AdTitel;
            txtPrice.Text = AdPrice.ToString();
            txtNewAdText.Text = AdDescription;
            cboCategoriesBox.SelectedItem = AdCategory;
            AdID = adID;
        }


        private void cboCategoriesBox_Loaded(object sender, RoutedEventArgs e)
        {
            cboCategoriesBox.ItemsSource = CategoryRepo.GetAllCatagories().DefaultView;
        }

        private void btnCreateAd_Click(object sender, RoutedEventArgs e)
        {
            if (AdID == 0)
            {
                AdvertRepo.NewAd(txtNewTitle.Text, txtNewAdText.Text, float.Parse(txtPrice.Text),
                Convert.ToInt32(cboCategoriesBox.SelectedValue), currentUserID);
            }
            else
            {
                AdvertRepo.DeleteAd(AdID);
                AdvertRepo.NewAd(txtNewTitle.Text, txtNewAdText.Text, float.Parse(txtPrice.Text),
                Convert.ToInt32(cboCategoriesBox.SelectedValue), currentUserID);
            }
            ((MainWindow)Application.Current.MainWindow).PopulateDataGrid();
            this.Close();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
