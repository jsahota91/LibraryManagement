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
using LibraryData;
using LibraryBusiness;
using System.Data;

namespace LibraryWPF
{
    /// <summary>
    /// Interaction logic for GPage.xaml
    /// </summary>
    public partial class GPage : Page
    {
        GenreManager _genreManager = new GenreManager();
        public GPage()
        {
            InitializeComponent();
            PopulateListBox();
        }
        //List box populated
        private void PopulateListBox()
        {
            ListBoxGenre.ItemsSource = _genreManager.GetAll();
        }

        private void PopulateGenreFields()
        {
            if (_genreManager.selectedGenre != null)
            {
                id_txt.Text = _genreManager.selectedGenre.GenreId.ToString();
                gName_txt.Text = _genreManager.selectedGenre.GenreName;
            }
        }
        //Select genre item from list
        private void ListBoxGenre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxGenre.SelectedItem != null)
            {
                _genreManager.SetSelectedGenre(ListBoxGenre.SelectedItem.ToString());
                PopulateGenreFields();
            }
        }
        public void ClearData()
        {
            id_txt.Clear();
            gName_txt.Clear();
            _genreManager.selectedGenre = null;
            ListBoxGenre.SelectedItem = null;
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            ClearData();
        }

        private void HomePgClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Home());
        }

        private void BookPgClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new BPage());
        }

        private void AuthorPgClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new APage());
        }

        private void LocationPgClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LPage());
        }

        private void RecordsPgClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RecordsPage());
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_genreManager.selectedGenre != null)
            {
                _genreManager.Update(_genreManager.selectedGenre.GenreName, gName_txt.Text);
                ListBoxGenre.ItemsSource = null;
                // put back the screen data
                PopulateListBox();
                ListBoxGenre.SelectedItem = _genreManager.selectedGenre;
                PopulateGenreFields();
            }
            else
            {
                MessageBox.Show("You need to select a record from the list.");
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxGenre.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButton.OKCancel);
                if(result == MessageBoxResult.OK)
                {
                    int id = int.Parse(id_txt.Text);
                    _genreManager.Delete(id);

                    PopulateListBox();
                    ClearData();
                }
            }
            else
            {
                MessageBox.Show("You need to select a record from the list.");
            }
        }

        private void InsertBtn_Click(object sender, RoutedEventArgs e)
        {
            AddG gWindow = new AddG();
            gWindow.Show();
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            PopulateListBox();
        }
    }
}
