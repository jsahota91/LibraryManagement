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
using LibraryBusiness;
using LibraryData;

namespace LibraryWPF
{
    /// <summary>
    /// Interaction logic for LPage.xaml
    /// </summary>
    public partial class LPage : Page
    {
        LocationManager _locationManager = new LocationManager();
        public LPage()
        {
            InitializeComponent();
            PopulateListBox();            
        }

        private void PopulateListBox()
        {
            ListBoxLocation.ItemsSource = _locationManager.RetrieveAll();
        }

        private void PopulateLocationFields()
        {
            if (_locationManager.selectedLocation != null)
            {
                id_txt.Text = _locationManager.selectedLocation.LocationId.ToString();
                aName_txt.Text = _locationManager.selectedLocation.AisleName;
                title_txt.Text = "";
                title_txt.Text = _locationManager.displayB[0];
            }
        }

        //Select location item from list
        private void ListBoxAuthor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxLocation.SelectedItem != null)
            {
                _locationManager.SetSelectedLocation(ListBoxLocation.SelectedItem.ToString());
                PopulateLocationFields();
            }
        }

        public void ClearData()
        {
            id_txt.Clear();
            aName_txt.Clear();
            title_txt.Clear();
            ListBoxLocation.SelectedItem = null;
            _locationManager.selectedLocation = null;
        }

        private void HomePgClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Home());
        }

        private void BookPgClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new BPage());
        }

        private void GenrePgClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new GPage());
        }

        private void AuthorPgClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new APage());
        }

        private void RecordsPgClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RecordsPage());
        }

        private void InsertBtn_Click(object sender, RoutedEventArgs e)
        {
            AddL lWindow = new AddL();
            lWindow.Show();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_locationManager.selectedLocation != null)
            {
                _locationManager.Update(_locationManager.selectedLocation.AisleName, aName_txt.Text);
                ListBoxLocation.ItemsSource = null;
                // put back the screen data
                PopulateListBox();
                ListBoxLocation.SelectedItem = _locationManager.selectedLocation;
                PopulateLocationFields();
            }
            else
            {
                MessageBox.Show("You need to select a record from the list.");
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxLocation.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    int id = int.Parse(id_txt.Text);
                    _locationManager.Delete(id);

                    PopulateListBox();
                    ClearData();
                }
            }
            else
            {
                MessageBox.Show("You need to select a record from the list.");
            }
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            ClearData();
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            PopulateListBox();
        }

        private void ListBoxLocation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxLocation.SelectedItem != null)
            {
                _locationManager.SetSelectedLocation(ListBoxLocation.SelectedItem.ToString());
                PopulateLocationFields();
            }
        }
    }
}
