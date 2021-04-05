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
    /// Interaction logic for RecordsPage.xaml
    /// </summary>
    public partial class RecordsPage : Page
    {
        private BookManager _bookManager = new BookManager();
        private AuthorBookManager _authorBookManager = new AuthorBookManager();
        private BookGenreManager _bookGenreManager = new BookGenreManager();
        int OldGId, NewGId, OldAId, NewAId;
        public RecordsPage()
        {
            InitializeComponent();
            PopulateListBox();
        }

        private void PopulateBookFields()
        {
            if (_bookManager.selectedBook != null)
            {
                List<string> emptyList = new List<string>();
                comboAuthor.ItemsSource = emptyList;
                comboAuthor.ItemsSource = _bookManager.displayA;

                comboGenre.ItemsSource = emptyList;
                comboGenre.ItemsSource = _bookManager.displayG;

                comboNewAuthor.ItemsSource = _bookManager.displayNewA;
                comboNewGenre.ItemsSource = _bookManager.displayNewG;

                location_txt.Text = "";

                for (int i = 1; i < _bookManager.displayL.Count; i++)
                {
                    
                    location_txt.Text = _bookManager.displayL[i];
                }

                id_txt.Text = _bookManager.selectedBook.BookId.ToString();
                title_txt.Text = _bookManager.selectedBook.Title;
                yearPublished_txt.Text = _bookManager.selectedBook.YearPublished.ToString();

            }
        }

        private void PopulateListBox()
        {
            ListBoxRecords.ItemsSource = _bookManager.RetrieveAll();            
        }

        private void ListBoxRecords_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxRecords.SelectedItem != null)
            {
                _bookManager.SetSelectedBook(ListBoxRecords.SelectedItem.ToString());
                PopulateBookFields();
            }
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

        private void LocationPgClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LPage());
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            _bookManager.SetSelectedBook(title_txt.Text + " " + yearPublished_txt.Text);
            PopulateBookFields();           
        }

        private void UpdateABtn_Click(object sender, RoutedEventArgs e)
        {
            if(comboAuthor.SelectedValue != null && comboNewAuthor.SelectedValue != null)
            {
                _authorBookManager.Update(OldAId, _bookManager.selectedBook.BookId, NewAId);
                MessageBox.Show("Click the Refresh Button");
                comboNewAuthor.SelectedValue = "";
            }
        }

        private void UpdateGBtn_Click(object sender, RoutedEventArgs e)
        {
            if (comboGenre.SelectedValue != null && comboNewGenre.SelectedValue != null)
            {
                _bookGenreManager.Update(_bookManager.selectedBook.BookId, OldGId, NewGId);
                MessageBox.Show("Click the Refresh Button");
                comboNewGenre.SelectedValue = "";
            }           
        }

        private void comboSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox selectedBox = (ComboBox)sender;
            using(var db = new LibraryManagementContext())
            {
                if (selectedBox.Name == "comboAuthor" && comboAuthor.SelectedValue != null)
                {
                    var comboAQuery = db.Authors.Where(a => a.FirstName + " " + a.LastName == comboAuthor.SelectedValue.ToString()).FirstOrDefault();
                    OldAId = comboAQuery.AuthorId;
                } 
                else if(selectedBox.Name == "comboNewAuthor" && comboNewAuthor.SelectedValue != null)
                {
                    var comboANewQuery = db.Authors.Where(a => a.FirstName + " " + a.LastName == comboNewAuthor.SelectedValue.ToString()).FirstOrDefault();
                    NewAId = comboANewQuery.AuthorId;
                }
                else if (selectedBox.Name == "comboGenre" && comboGenre.SelectedValue != null)
                {
                    var comboGQuery = db.Genres.Where(g => g.GenreName == comboGenre.SelectedValue.ToString()).FirstOrDefault();
                    OldGId = comboGQuery.GenreId;
                }
                else if (selectedBox.Name == "comboNewGenre" && comboNewGenre.SelectedValue != null)
                {
                    var comboGNewQuery = db.Genres.Where(g => g.GenreName == comboNewGenre.SelectedValue.ToString()).FirstOrDefault();
                    NewGId = comboGNewQuery.GenreId;
                }

            }
            
        }

    }
}
